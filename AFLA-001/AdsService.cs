using TwinCAT.Ads;

namespace AFLA_001
{
	// 管理 PLC 連線、點位 handle 及 ADS 讀寫。
	public static class AdsService
	{
		// 背景 EC 輪詢與其他 ADS 讀寫共用同一把鎖，避免連線或 handle 在使用中被釋放。
		private static readonly object clientLock = new();
		private const int DefaultPort = 851;
		private const int WrLength = 1651;

		// PLC 的 GVL.EC 為 ARRAY[0..461] OF LREAL，CSV 的 Index 直接對應陣列索引。
		internal const int EcLength = 462;
		// 動作命令的 Index 對應 PLC 寫入點位名稱，設定在 ADS 重連時保留。
		private static Dictionary<int, string> actionWriteLabels = new();
		private static AdsClient? ads;
		private static uint diHandle, doHandle, wrHandle;
		// 整組 GVL.EC 共用一個 handle，其有效期與目前的 ADS 連線相同。
		private static uint ecHandle;

		// 保存最近一次讀回的 DI、DO 值，長度需符合 PLC 宣告。
		public static bool[] DI { get; private set; } = new bool[24];
		public static bool[] DO { get; private set; } = new bool[36];

		// 載入 ActionCommands.csv 的動作寫入對應，供 WriteAction 使用。
		internal static void ConfigureActionWrites(IReadOnlyList<Motion> motions)
		{
			var labels = motions.ToDictionary(motion => motion.Index, motion => motion.Writelabel);
			lock (clientLock)
			{
				actionWriteLabels = labels;
			}
		}

		// 建立 ADS 連線與 EC 讀取 handle。
		public static void Connection()
		{
			lock (clientLock)
			{
				if (ads != null)
					throw new InvalidOperationException("ADS 已初始化。");

				var client = new AdsClient();
				try
				{
					string? netId = Environment.GetEnvironmentVariable("PLC_AMS_NET_ID");
					int port = int.TryParse(Environment.GetEnvironmentVariable("PLC_ADS_PORT"), out int configuredPort)
						? configuredPort : DefaultPort;
					if (string.IsNullOrWhiteSpace(netId))
						client.Connect(port);
					else
						client.Connect(netId, port);
					// 建立 EC 讀取 handle。I/O 與 WR 的 handle 在各自首次使用時建立。
					ecHandle = client.CreateVariableHandle("GVL.EC");

					ads = client;
				}
				// 初始化中途失敗時，清理已建立的 handle 和連線。
				catch
				{
					Release(client);
					throw;
				}
			}
		}

		// 整組讀取 WR。PLC INT 對應 C# short
		public static short[] ReadAction()
		{
			lock (clientLock)
			{
				var client = GetClient();
				if (wrHandle == 0)
					wrHandle = client.CreateVariableHandle("GVL.WR");

				return (short[])client.ReadAny(
					wrHandle, typeof(short[]), new[] { WrLength });
			}
		}

		//讀回.1的bool陣列,所有動作中的狀態
		public static bool[] ReadMotionStates()
		{
			short[] wr = ReadAction(); // ADS 只讀一次，取得整組 WR
			var states = new bool[wr.Length];

			const int motionBit = 1 << 1; // PLC 的 .1

			for (int index = 0; index < wr.Length; index++)
			{
				states[index] = (wr[index] & motionBit) != 0;
			}

			return states;
		}
		// 依 Index 找到「PC寫入」點位，每次按下都送出 TRUE。
		public static void WriteAction(int index)
		{
			lock (clientLock)
			{
				if (!actionWriteLabels.TryGetValue(index, out string? writeLabel))
					throw new ArgumentOutOfRangeException(nameof(index), index, "找不到 CSV 命令索引。");

				//WriteValue:用名稱指定目標,原先使用WriteAny(handle, true) 是用 handle 指定目標
				GetClient().WriteValue(writeLabel, true);
			}
		}

		/// <summary>
		/// 透過 ecHandle 一次讀取整組 GVL.EC。PLC 的 LREAL 對應 C# double。
		/// </summary>
		/// <returns>本次讀取的陣列快照，供 Manual 按 CSV Index 顯示。</returns>
		public static double[] ReadEc()
		{
			lock (clientLock)
			{
				return (double[])GetClient().ReadAny(
					ecHandle, typeof(double[]), new[] { EcLength });
			}
		}

		// 每次輪詢都先確認連線；讀取失敗時釋放舊 handle，讓下次輪詢重新連線。
		internal static double[] PollEc()
		{
			lock (clientLock)
			{
				if (ads == null)
					Connection();

				try
				{
					return ReadEc();
				}
				catch
				{
					Shutdown();
					throw;
				}
			}
		}

		// Manual 依 CSV Index 取得寫入符號。寫入目標是 PLC 參數符號，畫面值由後續 EC 輪詢取得。
		internal static void WriteManualValue(ECclass point, int value)
		{
			lock (clientLock)
			{
				// 使用符號型別封送數值，EC 的 LREAL 型別只適用於讀取陣列。
				GetClient().WriteValue(point.WriteEC, (object)value);
			}
		}

		// 讀回 DI、DO 陣列供 I/O 畫面使用。
		public static void Read()
		{
			lock (clientLock)
			{
				var client = GetClient();
				if (diHandle == 0)
					diHandle = client.CreateVariableHandle("GVL_IO.DI");
				if (doHandle == 0)
					doHandle = client.CreateVariableHandle("GVL_IO.DOO");

				DI = (bool[])client.ReadAny(diHandle, typeof(bool[]), new[] { DI.Length });
				DO = (bool[])client.ReadAny(doHandle, typeof(bool[]), new[] { DO.Length });
			}
		}

		// 先讀整組 DO，修改指定元素後再整組寫回。
		public static void Write(int index, bool value)
		{
			lock (clientLock)
			{
				if (index < 0 || index >= DO.Length)
					throw new ArgumentOutOfRangeException(nameof(index));

				var client = GetClient();
				if (doHandle == 0)
					doHandle = client.CreateVariableHandle("GVL_IO.DOO");

				var outputs = (bool[])client.ReadAny(doHandle, typeof(bool[]), new[] { DO.Length });
				outputs[index] = value;
				client.WriteAny(doHandle, outputs);
				DO = outputs;
			}
		}

		// 程式結束時釋放本次連線的 ADS 資源。
		public static void Shutdown()
		{
			lock (clientLock)
			{
				if (ads is AdsClient client)
				{
					ads = null;
					Release(client);
				}
			}
		}

		// 讀寫前確認 ADS 已完成初始化。
		private static AdsClient GetClient()
		{
			return ads ?? throw new InvalidOperationException("請先初始化 ADS 連線。");
		}

		// 釋放已建立的 handle 並關閉 ADS client。
		private static void Release(AdsClient client)
		{
			try
			{
				// 先釋放 EC 的 PLC handle，再關閉 ADS 連線。
				if (ecHandle != 0) client.TryDeleteVariableHandle(ecHandle);
				if (wrHandle != 0) client.TryDeleteVariableHandle(wrHandle);
				if (doHandle != 0) client.TryDeleteVariableHandle(doHandle);
				if (diHandle != 0) client.TryDeleteVariableHandle(diHandle);
			}
			finally
			{
				diHandle = doHandle = wrHandle = 0;
				ecHandle = 0; // 下次連線須重新取得 EC handle。
				client.Dispose();
			}
		}
	}
}

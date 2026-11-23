namespace AFLA_001
{
	public class ECclass
	{
		// ADS 寫入使用的 PLC 變數名稱。
		public string WriteEC { get; init; } = string.Empty;
		// CSV 提供的讀取名稱。實際讀取整組 GVL.EC 後，以 Index 取值。
		public string ReadEC { get; init; } = string.Empty;
		public int Index { get; init; }
	}
}

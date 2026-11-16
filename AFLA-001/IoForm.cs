using PathDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFLA_001
{
	public partial class IoForm : Form
	{
		private List<IOModel> iolist = new List<IOModel>();

		
		public IoForm()
		{
			InitializeComponent();
			Load += IoForm_Load;
		}

		private void IoForm_Load(object sender, EventArgs e)
		{
			////當excel打開時無法使用
			try
			{
				//AppContext.BaseDirectory:E\ALFA-Winform\AFLA-001\bin\Debug\net8.0-windows內:與exe同位置
				//@"..\..\..\ (@是逐字字串讓反斜線 \ 不會被當成跳脫字元)
				//往上三層在E:\AFLA-001_Winform\AFLA-001
				string path = Path.Combine(AppContext.BaseDirectory, @"..\..\..\IO_test.xlsx");
				ExcelHelper excel = new ExcelHelper();
				iolist = excel.LoadIO(path);
				MessageBox.Show($"成功讀取{iolist.Count}筆");//目前成功讀取
				try 
				{
					DisplayIo();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());					
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex.ToString()}");
			}
		}
		public IndicatorLightControl SetIO(IOModel model)
		{
			IndicatorLightControl iocontrol = new IndicatorLightControl();
			iocontrol.DisplayName = model.IOname ;
			iocontrol.IONumber = model.IOnumber;
			iocontrol.LightColor = model.PLCStatus ? Color.LimeGreen : Color.DimGray;
			iocontrol.Width = 260;
			iocontrol.Height = 56;
			iocontrol.Margin = new Padding(8);
			iocontrol.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold);
			return iocontrol;
		}
		public void DisplayIo()
		{
			foreach (IOModel io in iolist)
			{
				IndicatorLightControl item = SetIO(io);
				
				if (io.IOnumber.StartsWith("DI"))
					DiPanel.Controls.Add(item);
				else if (io.IOnumber.StartsWith("DO"))
					DoPanel.Controls.Add(item);
			}
		}
	}
}

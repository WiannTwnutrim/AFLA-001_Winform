using DocumentFormat.OpenXml.EMMA;
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

            AdsService.Read();
            IoLoad();
            iotimer.Tick += iotimer_Tick;
            iotimer.Start();
        }

        private void IoLoad()
        {
            try
            {
                //AppContext.BaseDirectory:E\ALFA-Winform\AFLA-001\bin\Debug\net8.0-windows內:與exe同位置
                //@"..\..\..\ (@是逐字字串讓反斜線 \ 不會被當成跳脫字元)
                //往上三層在E:\AFLA-001_Winform\AFLA-001
                string path = Path.Combine(AppContext.BaseDirectory, @"..\..\..\IO_test.csv");
                ExcelHelper excel = new ExcelHelper();
                iolist = excel.LoadIO(path);
                //MessageBox.Show($"成功讀取{iolist.Count}筆");//目前成功讀取
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
                Loghelper.Error(ex.ToString());
                //MessageBox.Show($"{ex.ToString()}");
            }
        }
        public void UpdateIO(IndicatorLightControl light)
        {
            if (light.Tag is not IOModel model) return;

            if (model.PlcPonit.StartsWith("DI["))
            {
                model.PLCStatus = AdsService.DI[model.Index];
            }
            else if (model.PlcPonit.StartsWith("DO["))
            {
                model.PLCStatus = AdsService.DO[model.Index];
            }
            light.LightColor = model.PLCStatus ? Color.LimeGreen : Color.DimGray;
        }

        public IndicatorLightControl SetIO(IOModel model)
        {
            IndicatorLightControl iocontrol = new IndicatorLightControl();

            iocontrol.DisplayName = model.IOname;
            iocontrol.IONumber = model.IOnumber;

            iocontrol.Width = 260;
            iocontrol.Height = 56;
            iocontrol.Margin = new Padding(8);
            iocontrol.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold);
            iocontrol.Tag = model;
            UpdateIO(iocontrol);
            iocontrol.Click += IOControl_Click;
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
        private void IOControl_Click(object? sender, EventArgs e)
        {
            if (sender is not IndicatorLightControl light)
                return;

            if (light.Tag is not IOModel model)
                return;
            if (string.IsNullOrEmpty(model.Variable))
                return;

            MessageBox.Show(model.Variable);
            if (model.PLCStatus)
            {
                AdsService.Write(model.Index, false);
            }
            else
            {
                AdsService.Write(model.Index, true);

            }
            light.LightColor = model.PLCStatus ? Color.LimeGreen : Color.DimGray;


        }

        private void iotimer_Tick(object sender, EventArgs e)
        {
            try
            {
                AdsService.Read();
                foreach (var light in DiPanel.Controls.OfType<IndicatorLightControl>())
                    UpdateIO(light);
                foreach (var light in DoPanel.Controls.OfType<IndicatorLightControl>())
                    UpdateIO(light);
            }
            catch(Exception ex)
            {
                Loghelper.Error($"PLC 讀取失敗：{ex.Message}"); 
            }
            

        }
    }
}

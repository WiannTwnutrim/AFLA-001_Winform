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
        private bool reading;
        private bool readFailed;
        private bool writing;
        private List<IOModel> iolist = new List<IOModel>();


        public IoForm()
        {
            InitializeComponent();

            //AdsService.Read();
            IoLoad();
            VisibleChanged += (_, _) => iotimer.Enabled = Visible;
        }

        private void IoLoad()
        {
            try
            {
                //AppContext.BaseDirectory:E\ALFA-Winform\AFLA-001\bin\Debug\net8.0-windows內:與exe同位置
                //@"..\..\..\ (@是逐字字串讓反斜線 \ 不會被當成跳脫字元)
                //若往上三層在E:\AFLA-001_Winform\AFLA-001
                string path = Path.Combine(AppContext.BaseDirectory, "IO_test.csv");
                ExcelHelper excel = new ExcelHelper();
                if (!excel.TryLoadIO(path, out var loadedIo, out var error))
                {
                    Loghelper.Error($"無法載入 IO 點位：{error}");
                    return;
                }

                iolist = loadedIo;
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
            if (light.Tag is not IOModel model)
                return;
            try
            {
                var wrBits = AdsService.LatestWrBits;
                if (wrBits == null || model.Index < 0 || model.Index >= wrBits.Length)
                    return;
                model.PLCStatus = wrBits[model.Index][3];
                light.LightColor = model.PLCStatus ? Color.LimeGreen : Color.DimGray;
            }
            catch (Exception ex)
            {
                Loghelper.Error($"更新 IO {model.IOnumber}（WR[{model.Index}].3）失敗：{ex}");
            }
        }
        /// <summary>
        /// 設定單顆io資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicatorLightControl SetIO(IOModel model)
        {
            IndicatorLightControl iocontrol = new IndicatorLightControl();

            iocontrol.DisplayName = model.IOname;
            iocontrol.IONumber = model.IOnumber;

            iocontrol.Width = 260;
            iocontrol.Height = 56;
            iocontrol.Margin = new Padding(8);
            iocontrol.Font = new Font("Microsoft JhengHei UI", 13F, FontStyle.Bold);
            iocontrol.ForeColor = Color.White;
            iocontrol.Tag = model;
            UpdateIO(iocontrol);
            //iocontrol.Click += IOControl_Click;
            return iocontrol;
        }
        /// <summary>
        /// io分頁
        /// </summary>
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
        private async void IOControl_Click(object? sender, EventArgs e)
        {
            //    if (sender is not IndicatorLightControl light)
            //        return;

            //    if (light.Tag is not IOModel model)
            //        return;
            //    if (string.IsNullOrEmpty(model.Variable))
            //        return;

            //    if (writing)
            //        return;

            //    writing = true;
            //    try
            //    {
            //        MessageBox.Show(this, model.Variable);
            //        int index = model.Index;
            //        bool value = !model.PLCStatus;
            //        if (await Task.Run(() => AdsService.Write(index, value)) && !IsDisposed)
            //            UpdateIO(light);
            //    }
            //    catch (Exception ex)
            //    {
            //        Loghelper.Error(ex.ToString());
            //    }
            //    finally
            //    {
            //        writing = false;
            //    }
        }

        private async void iotimer_Tick(object sender, EventArgs e)
        {
            if (!Visible)
                return;

            foreach (var light in DiPanel.Controls.OfType<IndicatorLightControl>())
                UpdateIO(light);

            foreach (var light in DoPanel.Controls.OfType<IndicatorLightControl>())
                UpdateIO(light);
        }
    }
}

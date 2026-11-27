using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.PlcOpen;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace AFLA_001
{
    public partial class AlarmForm : Form
    {
        private Sqllite _db = new Sqllite();
        DataTable data;
        public AlarmForm()
        {
            InitializeComponent();


        }
        //DataTable data = new DataTable();
        public void loadAlarm()
        {

            //alarmData.Columns["Alarm"].Width = 200;
            try
            {
                data = ReadAlarm();

                alarmData.DataSource = data;
            }
            catch (Exception ex)
            {
                Loghelper.Error($"錯誤:{ex.ToString()}");
            }

        }
        public DataTable ReadAlarm()
        {
            DataTable data = _db.LoadAlarm(10);
            return data;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Export.ExportCSV(alarmData, "Alarm");
            Loghelper.Userlog(UserSession.LoginUser, "輸出alarm表");
        }
        //停在警報頁：每次 Tick 都呼叫 loadAlarm()。
        private void loadalarmtimer_Tick(object sender, EventArgs e)
        {
            loadAlarm();
        }

        private void AlarmForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                loadAlarm();
                loadalarmtimer.Start();
            }
            else
            {
                loadalarmtimer.Stop();
            }
        }
        //恢復表格,並開始計最新狀態
        private void livebtn_Click(object sender, EventArgs e)
        {
            loadAlarm();
            loadalarmtimer.Start();
            Loghelper.Userlog(UserSession.LoginUser, "恢復alarm表");
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            Loghelper.Userlog(UserSession.LoginUser, "搜尋alarm");
            string startDate = dateTimePickerup.Value.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            string endDate = dateTimePickerdown.Value.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

            if (dateTimePickerup.Value.Date > dateTimePickerdown.Value.Date)
            {
                MessageBox.Show(this, "起始日期不能晚於結束日期。");
                return;
            }

            try
            {
                data = _db.SearchAlarmData(startDate, endDate);
                loadalarmtimer.Stop();
                alarmData.DataSource = data;
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show(this, "這段日期內沒有警報紀錄。");
                }
            }
            catch (Exception ex)
            {
                Loghelper.Error(ex.ToString());
                MessageBox.Show(this, "警報搜尋失敗，請查看日誌。");
            }
        }
    }
}

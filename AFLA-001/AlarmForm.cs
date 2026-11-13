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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace AFLA_001
{
    public partial class AlarmForm : Form
    {
        private Sqllite _db = new Sqllite();
        public event EventHandler<DataTransferEventArgs> transferData;
        public AlarmForm()
        {
            InitializeComponent();

        }
        DataTable data = new DataTable();
        public void loadAlarm()
        {
            data = _db.LoadAlarm();

            alarmData.DataSource = data;
            alarmData.Columns["Alarm"].Width = 200;
            try
            {
                string? alarmevent = data.Rows.Count == 0 ? "" : Convert.ToString(data.Rows[0]["Alarm"]);
                string? alarmtime = data.Rows.Count == 0 ? "" : Convert.ToString(data.Rows[0]["TriggerTime"]);
                transferData?.Invoke(this, new DataTransferEventArgs { alarm = alarmevent , alarmTime =alarmtime});
            }
            catch (Exception ex)
            {
                Loghelper.Error($"錯誤:{ex.ToString()}");
            }

        }

        private void alarmtestbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_db.TriggerAlarm())
                {
                    loadAlarm();
                }
                else
                {
                    MessageBox.Show("新增失敗");
                }

            }
            catch
            {
                MessageBox.Show("新增失敗");
            }


        }

        private void alaemResetbtn_Click(object sender, EventArgs e)
        {
            if (_db.ResetAlarm())
            {
                _db.AddNoError();
                loadAlarm();
                MessageBox.Show("Reset成功");
            }
            else
            {
                MessageBox.Show("Reset失敗");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export.ExportCSV(alarmData, "Alarm");
        }
    }
}

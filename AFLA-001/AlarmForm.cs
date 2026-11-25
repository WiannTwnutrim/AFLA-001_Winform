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
        ExcelHelper hp = new ExcelHelper();
        public AlarmForm()
        {
            InitializeComponent();
            loadAlarm();

        }
        //DataTable data = new DataTable();
        public void loadAlarm()
        {
            
            //alarmData.Columns["Alarm"].Width = 200;
            try
            {
                DataTable data = ReadAlarm();

                alarmData.DataSource = data;
            }
            catch (Exception ex)
            {
                Loghelper.Error($"錯誤:{ex.ToString()}");
            }

        }
        public DataTable ReadAlarm()
        {
            DataTable data = _db.LoadAlarm();
            return data;
        }


        private void alarmResult()
        {
            int num = 0;
            bool[] alarm = AdsService.ReadAlarm();
            
            foreach(bool value in alarm)
            {
                //TryGetValue:bool 查看csv內是否有此index
                if (value && hp.AlarmMessages.TryGetValue(num,out var alarmname))
                {
                    _db.AddAlarm(alarmname);
                    int index =num;
                }
                num++;
            }
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Export.ExportCSV(alarmData, "Alarm");
        }
    }
}

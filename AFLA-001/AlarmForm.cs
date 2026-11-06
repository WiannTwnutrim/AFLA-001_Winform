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
    public partial class AlarmForm : Form
    {
        private Sqllite _db = new Sqllite();
        private Export export = new Export(); 
        public AlarmForm()
        {
            InitializeComponent();
            loadAlarm();

        }
        DataTable data = new DataTable();
        public void loadAlarm()
        {

            data = _db.LoadAlarm();
            alarmData.DataSource = data;
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
            export.ExportCSV(alarmData);
        }
    }
}

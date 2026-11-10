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
    public partial class HistoryForm : Form
    {
        private Sqllite _db = new Sqllite();
        DataTable dt = new DataTable();
        public HistoryForm()
        {
            InitializeComponent();
            LoadHistory();
        }


        public void LoadHistory()
        {
            dt.Clear();
            dt = _db.LoadHistory();
            historydataGridView.DataSource = dt;
        }

        private void stabtn_Click(object sender, EventArgs e)
        {
            SaveStation("A", 45, "2:40");
        }

        private void stbbtn_Click(object sender, EventArgs e)
        {
            SaveStation("B", 80, "7:10");
        }

        private void stcbtn_Click(object sender, EventArgs e)
        {
            SaveStation("C", 30, "2:10");
        }

        private void SaveStation(string stationName, int temperature, string pickAt)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "請輸入產品編號。同一產品的各站請使用相同編號。", $"{stationName} 站");
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int productId))
            {
                MessageBox.Show("請輸入有效的整數產品編號。");
                return;
            }

            if (!_db.AddHistoryStation(productId, stationName, UserSession.WritedRecipe, temperature, pickAt))
            {
                MessageBox.Show($"{stationName} 站歷史寫入失敗，請查看log");
                return;
            }

            LoadHistory();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Export.ExportCSV(historydataGridView, "HistoryData");
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string startDate = dateTimePickerup.Value.ToString("yyyy/MM/dd");
            string endDate = dateTimePickerdown.Value.ToString("yyyy/MM/dd");
            dt.Clear();
            try
            {
                dt = _db.SearchData(startDate, endDate);
                historydataGridView.DataSource = dt;
            }
            catch(Exception ex)
            {
                Loghelper.Error(ex.ToString());
            }
        }
    }
}

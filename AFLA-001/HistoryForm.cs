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
            //try
            //{
            //    if (!_db.AddHistoryStation("A", "2:40", 45, UserSession.WritedRecipe))
            //    {
            //        MessageBox.Show("A 站歷史新增失敗，請查看日誌");
            //    }
            //    LoadHistory();
            //}
            //catch (Exception ex)
            //{
            //    Loghelper.Error($"錯誤：{ex.ToString()}");

            //}

        }

        private void stbbtn_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!_db.AddHistoryStation("B", "7:10", 80, UserSession.WritedRecipe))
            //    {
            //        MessageBox.Show("B 站歷史新增失敗，請查看日誌");
            //    }
            //    LoadHistory();
            //}
            //catch (Exception ex)
            //{
            //    Loghelper.Error($"錯誤：{ex.ToString()}");

            //}
        }

        private void stcbtn_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!_db.AddHistoryStation("C", "2:10", 30, UserSession.WritedRecipe))
            //    {
            //        MessageBox.Show("C 站歷史新增失敗，請查看日誌");
            //    }
            //    LoadHistory();
            //}
            //catch (Exception ex)
            //{
            //    Loghelper.Error($"錯誤：{ex.ToString()}");

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export.ExportCSV(historydataGridView, "HistoryData");
        }
    }
}

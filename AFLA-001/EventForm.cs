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
	public partial class EventForm : Form
	{
		private Sqllite _db = new Sqllite();
		public EventForm()
		{
			InitializeComponent();
			LoadEvent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Export.ExportCSV(EventdataGridView, "EventData");
		}

		public void LoadEvent()
		{
			try
			{
				DataTable dt = _db.LoadEvent();
				if (dt.Rows.Count == 0)
				{
					Loghelper.Error("查無事件表");

				}
				else
				{
					EventdataGridView.DataSource = dt;
					EventdataGridView.Columns["Event"].Width = 200;

                }
			}

			catch (Exception ex)
			{
				Loghelper.Error(ex.ToString());
			}
		}

		private void addeventbtn_Click(object sender, EventArgs e)
		{
			try
			{
				_db.AddEvent("Arm1Rotate:Axis StandBy motion");
				LoadEvent();
			}
			catch (Exception ex) 
			{
				Loghelper.Error(ex.ToString());
			}
		}
	}
}

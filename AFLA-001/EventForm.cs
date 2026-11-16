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
		public event EventHandler<DataTransferEventArgs> transferevent;
		public EventForm()
		{
			InitializeComponent();
			//LoadEvent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Export.ExportCSV(EventdataGridView, "EventData");
		}

		async public void LoadEvent()
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
                    //EventdataGridView.Columns["Event"].Width = 200;
                    
					try
					{
						for (int i =0; i<5;i++)
						{
                            transferevent?.Invoke(this, new DataTransferEventArgs 
							{ eventitem = Convert.ToString(dt.Rows[0]["Event"]), 
							eventtime = Convert.ToString(dt.Rows[0]["TriggerTime"])});
                            if (i < 5)
                                await Task.Delay(2000);
                        }    
                    }
                    catch (Exception ex)
                    {
                        Loghelper.Error($"錯誤:{ex.ToString()}");
                    }
                    

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

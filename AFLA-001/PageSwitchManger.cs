using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace AFLA_001
{
    public static class PageSwitchManger
    {

		/// <summary>
		/// 切換指定 Panel 中顯示的 UserControl 頁面
		/// </summary>
		/// <param name="panel">要顯示頁面的目標 Panel 控制項</param>
		/// <param name="form">要切換並顯示的 form 頁面</param>
		public static void ShowPage(Panel panel, Form form)
        {
            // 隱藏目前顯示的子頁面，保留原本輸入資料
            foreach (Control control in panel.Controls)
            {
                control.Hide();
            }

            form.TopLevel = false;// 設為 false，讓 Form 可以嵌入 Panel
            form.Dock = DockStyle.Fill;//填滿panel
            // 如果子 Form 尚未加入 Panel，才加入
            if (!panel.Controls.Contains(form))
            {
                panel.Controls.Add(form);
            }
            form.Show();
            form.BringToFront();
        }


		private static Button lastbutton;
        /// <summary>
        /// 點擊button變色,沒點到回到原色
        /// </summary>
        /// <param name="activebutton">點到的button</param>
        public static void ActiveButton(Button activebutton)
        {
            if (lastbutton != null)
            {
                lastbutton.BackColor = System.Drawing.SystemColors.ActiveCaption;
                activebutton.BackColor = Color.Green;
            }
            //把點到設為上一個button
            lastbutton = activebutton;
        }
        
    }
}

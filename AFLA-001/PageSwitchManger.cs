using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AFLA_001
{
    public static class PageSwitchManger
    {
      

        /// <summary>
        /// 切換指定 Panel 中顯示的 UserControl 頁面
        /// </summary>
        /// <param name="panel">要顯示頁面的目標 Panel 控制項</param>
        /// <param name="page">要切換並顯示的 UserControl 頁面</param>
        public static void ShowPage(Panel panel, UserControl page)
        {
            panel.Controls.Clear();// 清除原本顯示的頁面
            page.Dock = DockStyle.Fill;// 新頁面填滿 Panel
            panel.Controls.Add(page);// 加入並顯示新頁面
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

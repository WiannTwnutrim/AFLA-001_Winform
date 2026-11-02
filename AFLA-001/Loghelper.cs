using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    public static class Loghelper
    {
        public static void Error(string errormessage)
        {
            try
            {
                //log產生位置:bin\Debug\<目標框架>\Logs
                string folder = Path.Combine(AppContext.BaseDirectory, "Logs");

                //建立資料夾,如果不存在建立,包括中間的 ALFA-Winform 資料夾
                //已存在也不會清空報錯
                Directory.CreateDirectory(folder);

                DateTime now = DateTime.Now;

                //產生當日路徑
                string path = Path.Combine(folder, $"{now:yyyy-MM-dd}.txt");

                //將內容附加到 TXT,File.AppendAllText(檔案路徑, 寫入內容, 文字編碼);
                File.AppendAllText(
                path,
                $"[{now:yyyy-MM-dd HH:mm:ss}]{errormessage}\r\n\r\n",Encoding.UTF8);

            }
            catch (Exception logEx)
            {
                //寫入檔案也可能失敗，例如沒有寫入權限、磁碟空間不足或檔案被占用
                System.Diagnostics.Debug.WriteLine(logEx);
            }
            
            
        }
    }
}

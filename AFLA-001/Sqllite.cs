using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AFLA_001
{
    public class Sqllite
    {
        private readonly string connectionString;

        public Sqllite()
        {
            //AppContext.BaseDirectory：程式執行檔所在的目錄
            //Combine:將路徑與檔案名稱組合
            string dbPath = Path.Combine(AppContext.BaseDirectory,
                "ALFA001.db");
            //告訴 SQLite 要連接哪個資料庫檔案。
            connectionString = $"Data Source={dbPath}";
        }

        /// <summary>
        /// 取得Sqllite Users表內Account資料
        /// </summary>
        /// <returns></returns>
        public List<string> GetAccount()
        {
            //建空list
            List<string> accounts = new List<string>();
            //建立連線物件,using 代表使用完後會自動釋放連線物件的資源
            using SqliteConnection connection =
                new SqliteConnection(connectionString);
            //連線開啟
            connection.Open();
            //找User表內的Account欄位並依據ID排序ASC小到大
            string sql = "SELECT Account FROM Users ORDER BY ID";
            //SqliteCommand:準備要執行的 SQL 指令,參數意義(要執行的 SQL 語法,使用哪個資料庫連線)
            using SqliteCommand command = new SqliteCommand(sql, connection);
            //ExecuteReader() 會執行 SQL，並回傳 SqliteDataReader
            using SqliteDataReader reader = command.ExecuteReader();

            //Read:將讀取位置移動到下一筆資料,回傳 bool，表示是否成功讀取下一筆資料
            while (reader.Read())
            {   //取得account欄位並轉成字串加入list尾端
                accounts.Add(reader["Account"].ToString()!);
            }

            return accounts;
        }

        public bool LoginCheck(string account,string password)
        {
            using SqliteConnection connection =
               new SqliteConnection(connectionString);

            connection.Open();

            string sql = $"SELECT COUNT(*) FROM Users WHERE Account = '{account}' " +
                $"AND Password = '{password}'";
                
          
          
            
            using SqliteCommand command = new SqliteCommand(sql, connection);

            long count = (long)command.ExecuteScalar();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

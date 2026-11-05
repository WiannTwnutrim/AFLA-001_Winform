using System;
using System.Collections.Generic;
using System.Data;
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
            string dbPath = GetDatabasePath();
            connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = dbPath,
                // A missing seed database should fail instead of creating an empty DB.
                Mode = SqliteOpenMode.ReadWrite
            }.ToString();
        }

        private static string GetDatabasePath()
        {
#if DEBUG
            // Local builds share the tracked DB, so edits appear in Git changes.
            for (DirectoryInfo? directory = new DirectoryInfo(AppContext.BaseDirectory);
                 directory != null;
                 directory = directory.Parent)
            {
                if (File.Exists(Path.Combine(directory.FullName, "AFLA-001.csproj")))
                {
                    return Path.Combine(directory.FullName, "ALFA001.db");
                }
            }
#endif
            // Published/standalone builds use the DB beside the executable.
            return Path.Combine(AppContext.BaseDirectory, "ALFA001.db");
        }

        /// <summary>
        /// 取得Sqllite Users表內Account資料
        /// </summary>
        /// <returns></returns>
        public List<string> GetAccount()
        {
            //建空list
            List<string> accounts = new List<string>();
            //建立資料庫連線物件,using 代表使用完後會自動釋放連線物件的資源
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
            
            //reader是用來讀取sql查詢結果的物件
            //Read:將讀取位置移動到下一筆資料,回傳 bool，表示是否成功讀取下一筆資料(要呼叫才會讀取一次)
            while (reader.Read())
            {   //取得account欄位並轉成字串加入list尾端
                accounts.Add(reader["Account"].ToString());
            }

            return accounts;
        }

        /// <summary>
        /// 登入檢查
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginCheck(string account,string password)
        {
            try
            {
            using SqliteConnection connection =
               new SqliteConnection(connectionString);

            connection.Open();

            string sql = $"SELECT COUNT(*) FROM Users WHERE Account = @account " +
                $"AND Password = @password";

			using SqliteCommand command = new SqliteCommand(sql, connection);

			//@是作為標示命名參數用,將 C# 變數的值綁定到 SQL 指定參數，進行參數化查詢
			command.Parameters.AddWithValue("@account", account);
			command.Parameters.AddWithValue("@password", password);

			long count = (long)command.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                Loghelper.Error($"登入失敗：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 修改權限
        /// </summary>
        /// <param name="account"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public bool AlterAccess(string account,int access)
        {            
            try
            {
            using SqliteConnection conn = new SqliteConnection(connectionString);
            conn.Open();
            string sql = 
                "UPDATE Users SET RoleLevel=@access WHERE Account=@account";
            using SqliteCommand command = new SqliteCommand(sql, conn);

            command.Parameters.AddWithValue("@access", access);
            command.Parameters.AddWithValue("@account", account);

            return command.ExecuteNonQuery() > 0;
            }
            catch(Exception ex)
            {                
                Loghelper.Error(
            $"修改權限失敗：帳號 [{account}]\r\n{ex}");
				return false;
			}                       
        }
        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AlterPassword(string account,string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("請輸入密碼");
                }
                using SqliteConnection conn = new SqliteConnection(connectionString);
                conn.Open();
                string sql = "Update Users Set password=@password WHERE Account=@account ";
                using SqliteCommand command = new SqliteCommand(sql, conn);
                command.Parameters.AddWithValue("@account", account);
                command.Parameters.AddWithValue("@password",password);
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Loghelper.Error($"修改失敗：{ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool DeleteAccount(string account)
        {
            try
            {
            using SqliteConnection conn = new SqliteConnection(connectionString);
            conn.Open();

            string sql = "DELETE FROM Users WHERE Account=@account";

            using SqliteCommand command = new SqliteCommand(sql, conn);

            command.Parameters.AddWithValue("@account", account);
            return command.ExecuteNonQuery() > 0;
            }
            catch(Exception ex)
            {
                Loghelper.Error($"刪除失敗：{ex.Message}");
                return false;
            }
            
        }

        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public bool AddUser(string account,string password,int access)
        {
            try
            {
                SqliteConnection conn = new SqliteConnection(connectionString);
                conn.Open();
                string sql = "Insert Into Users(account,password,rolelevel) Values(@account,@password,@access)";
                SqliteCommand command = new SqliteCommand(sql, conn);
                command.Parameters.AddWithValue("@account", account);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@access", access);
                return command.ExecuteNonQuery()>0;
                
            }
            catch(Exception ex)
            {
                Loghelper.Error($"錯誤：{ex.Message}");
                return false;
            }
            

            
        }

        /// <summary>
        /// 檢查權限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public int? CheckRole(string account)
        {
            try
            {
            using SqliteConnection conn = new SqliteConnection(connectionString);
            conn.Open();
            string sql = "Select RoleLevel From Users Where Account=@account";
            using SqliteCommand command = new SqliteCommand(sql, conn);
            command.Parameters.AddWithValue("@account", account);
            var count =command.ExecuteScalar();
            int result = Convert.ToInt32(count);
                if (result < 0)
                {
                    Loghelper.Error("查詢權限失敗");
                    return null;
                }
                else
                {
                    return result;
                }

            }
            
            catch(Exception ex)
            {
                Loghelper.Error(ex.Message);
                throw;
            }
        }
        public bool CheckLevel(int? num)
        {
            if (num<2||num ==null)
            {
                MessageBox.Show("權限等級不夠");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 取得配方名稱
        /// </summary>
        /// <returns></returns>
        public List<string> GetRecipe()
        {
            try
            {
            List<string> recipeName = new List<string>();
            using SqliteConnection conn = new SqliteConnection(connectionString);
            conn.Open();
            string sql = "Select RecipeName From Recipe";
            using SqliteCommand command = new SqliteCommand(sql, conn);

            using SqliteDataReader reader = command.ExecuteReader();

            //reader是用來讀取sql查詢結果的物件
            //Read:將讀取位置移動到下一筆資料,回傳 bool，表示是否成功讀取下一筆資料(要呼叫才會讀取一次)
            while (reader.Read())
            {   //取得account欄位並轉成字串加入list尾端
                recipeName.Add(reader["RecipeName"].ToString());
            }

            return recipeName;
            }
            catch(Exception ex)
            {
                Loghelper.Error(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// 先找到配方再找出他所有步驟
        /// </summary>
        /// <param name="recipeName"></param>
        public DataTable? LoadRecipeData(string recipeName)
        {
            try
            {
                using SqliteConnection conn = new SqliteConnection(connectionString);
                conn.Open();
                string sql = "SELECT s.*,r.Size AS Size FROM RecipeStep AS s " +
                    "INNER JOIN Recipe AS r  ON s.RecipeID = r.RecipeID " +
                    "WHERE r.RecipeName = @recipeName Order By s.StepID"  ;
                
               
                using SqliteCommand command = new SqliteCommand(sql, conn);
                command.Parameters.AddWithValue("@recipeName", recipeName);
                //取得多筆資料
                using SqliteDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
    
                return dataTable;
            }
            catch
            {
                return null;
            }
           
            

        }

        /// <summary>
        /// 儲存配方
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="size"></param>
        /// <param name="recipeId"></param>
        /// <param name="recipeName"></param>
        public void SaveRecipe(DataTable dt,string size,int recipeId,string recipeName)
        {
            if (string.IsNullOrEmpty(recipeName))
            {
            Loghelper.Error("沒輸入配方名稱存檔");
            MessageBox.Show("沒輸入配方名稱存檔");
            return;
            }               
            try
            {              
                using (SqliteConnection conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    using (SqliteTransaction transaction = conn.BeginTransaction())
                    {
                        using SqliteCommand command = conn.CreateCommand();
                        command.Transaction = transaction;
                        // 先建立命令，再指定 SQL
                        command.CommandText = "Update Recipe Set Size=@size,RecipeName=@recipeName Where RecipeId =@recipeID";
                        command.Parameters.AddWithValue("@recipeID", recipeId);
                        command.Parameters.AddWithValue("@size", size);
                        command.Parameters.AddWithValue("@recipeName", recipeName);

                        command.ExecuteNonQuery();

                        foreach(DataRow row in dt.Rows)
                        {
                            int step = Convert.ToBoolean(row["Step"]) ? 1 : 0;
                            int bsoil = Convert.ToBoolean(row["BSOIL"]) ? 1 : 0;
                            int bsair = Convert.ToBoolean(row["BSAIR"]) ? 1 : 0;
                            int ipa = Convert.ToBoolean(row["IPA"]) ? 1 : 0;
                            int oil = Convert.ToBoolean(row["OIL"]) ? 1 : 0;
                            int glue = Convert.ToBoolean(row["GLUE"]) ? 1 : 0;
                            //decimal start = Convert.ToDecimal(row["START"]);
                            using SqliteCommand stepcommand = conn.CreateCommand();
                            stepcommand.Transaction = transaction;
                            stepcommand.CommandText = "Update RecipeStep Set Step=@Step," +
                                "BSOIL=@bsoil,BSAIR=@bsair,IPA=@ipa," +
                                "OIL=@oil,GLUE=@glue,START=@start,END=@end,"  +
                                "SPEED=@speed,RPM=@rpm,ACC=@acc,TIME=@time"+
                                " WHERE RecipeID = @recipeId AND StepID = @stepId";
                            stepcommand.Parameters.AddWithValue("@Step", step);
                            stepcommand.Parameters.AddWithValue("@bsoil", bsoil);
                            stepcommand.Parameters.AddWithValue("@bsair", bsair);
                            stepcommand.Parameters.AddWithValue("@ipa", ipa);
                            stepcommand.Parameters.AddWithValue("@oil", oil);
                            stepcommand.Parameters.AddWithValue("@glue", glue);
                            stepcommand.Parameters.AddWithValue("@start", row["START"]);
                            stepcommand.Parameters.AddWithValue("@recipeId", recipeId);
                            stepcommand.Parameters.AddWithValue("@stepId", row["StepID"]);
							stepcommand.Parameters.AddWithValue("@end", row["END"]);
							stepcommand.Parameters.AddWithValue("@speed", row["SPEED"]);
							stepcommand.Parameters.AddWithValue("@rpm", row["RPM"]);
							stepcommand.Parameters.AddWithValue("@acc", row["ACC"]);
							stepcommand.Parameters.AddWithValue("@time", row["TIME"]);

							stepcommand.ExecuteNonQuery();

                            if (stepcommand.ExecuteNonQuery() != 1)
                                MessageBox.Show($"無法更新步驟 {row["StepID"]}。");                            
                        }
                        transaction.Commit();
                    }
                }
            }
            catch(Exception ex)
            {
               Loghelper.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 載入alarm表
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAlarm()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using(SqliteConnection conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "Select * From Alarm";
                    using (SqliteCommand command = new SqliteCommand(sql, conn))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            
                            dataTable.Load(reader);
                        }

                    }
                    return dataTable;
                }
            }
            catch(Exception ex)
            {
                Loghelper.Error(ex.Message);
                return dataTable;
            }
        }

        public bool TriggerAlarm()
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy/MM/dd");
            string time = now.ToString("HH:mm:ss");
            string alarmEvent = "觸發警告測試";
            try
            {
                using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "Insert Into Alarm(觸發日期,觸發時間,訊息) Values(@date,@time,@alarmEvent)";
                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@date",date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@alarmEvent", alarmEvent);
                    
                 if (command.ExecuteNonQuery() < 1)
                        {
                          return false;
                        }
                        return true;

                }

               } 
            }
            catch (Exception ex)
            {
                Loghelper.Error($"錯誤：{ex.Message}");
                return false;
                
            }

        }
    }
}

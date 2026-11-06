using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    /// <summary>
    /// 紀錄
    /// </summary>
    public static class UserSession
    {
        public static string LoginUser { get;private set; } = "";

        public static string WritedRecipe { get; set; } = "";

        public static void LoadRecipe(string recipeName)
        {
            WritedRecipe = recipeName;
        }

        public static void Login(string loginuser)
        {
            LoginUser = loginuser;
            
        }

        public static void Logout()
        {
            LoginUser = "";
            WritedRecipe = "";//登出也把配方清除
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    /// <summary>
    /// 紀錄登入者
    /// </summary>
    public static class UserSession
    {
        public static string LoginUser { get;private set; } = "";

        public static void Login(string loginuser)
        {
            LoginUser = loginuser;
            
        }

        public static void Logout()
        {
            LoginUser = "";
        }
    }
}

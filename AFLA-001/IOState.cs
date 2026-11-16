using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    public static class IOState
    {
        public static bool[] DI { get; } = new bool[24];
        public static bool[] DO { get; set; } = new bool[36];

        static IOState()
        {
            // 只設定需要為 true 的點位
            DI[0] = true;
            DI[3] = true;

            DO[0] = true;
            DO[5] = true;
        }
    }
}

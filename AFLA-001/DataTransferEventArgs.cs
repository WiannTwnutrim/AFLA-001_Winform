using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    public class DataTransferEventArgs : EventArgs
    {
        public string? alarm { get; set; }
        public string? alarmTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    public class RecipeAppliedEventArgs : EventArgs
    {
        public string Size { get; }
        public double Rpm { get; }

        public int Bsair { get; }
        public int Bsoil { get; }
        public int Time { get; }
        public RecipeAppliedEventArgs(string size, double rpm, int bsair, int bsoil, int time)
        {
            Size = size;
            Rpm = rpm;
            Bsair = bsair;
            Bsoil = bsoil;
            Time = time;
        }
    }
}

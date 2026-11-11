using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    public class LanguageManger
    {
        public string English { get; set; }
        public string Taiwan { get; set; }

        public LanguageManger(string taiwan, string english)
        {
            English = english;
            Taiwan = taiwan;
        }

    }
}

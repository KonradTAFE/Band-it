using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band_it.Modules
{
    class Band
    {
        public string Color { get; set; }
        public int Resistance { get; set; }

        public Band() { }
        public Band(string color, int resistance)
        {
            Color = color;
            Resistance = resistance;
        }
    }
}

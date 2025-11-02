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

        Dictionary<string, int> Bands = new Dictionary<string, int>()
        {
            {"red", 10},
            {"orange", 25 },
            {"black", 40 },
            {"purple", 55 },
            {"green", 70 }
        };

 

        //Band red = new Band("Red", 10);
        //Band orange = new Band("Orange", 25);
        //Band black = new Band("Black", 40);
        //Band purple = new Band("Purple", 55);
        //Band green = new Band("Green", 70);
        //public List<Band> bands = new List<Band>();
    }

}

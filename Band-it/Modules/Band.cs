using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace Band_it.Modules
{

    class Band
    {
        public string Color { get; set; }
        public int Resistance { get; set; }
        //public Color Color => Name?.ToLower() switch
        //{
        //    "red" => Colors.Red,
        //    "orange" => Color.FromRgb(255, 165, 0),
        //    "black" => Colors.Black,
        //    "purple" => Color.FromRgb(128, 0, 128),
        //    "green" => Colors.Green,
        //    _ => Colors.Gray
        //};

        public Band() { }
        public Band(string color, int resistance)
        {
            Color = color;
            Resistance = resistance;
        }
    }

}

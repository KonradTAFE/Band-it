using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Band_it.Services;

namespace Band_it.Modules
{
    public class Set
    {
        public int Id { get; set; }
        public int Reps {  get; set; }
        public string BandColor { get; set; }        

        public Set() { }
        public Set(int id, int reps, string color)
        {
            Id = id;
            Reps = reps;
            BandColor = color;
        }
    }
}

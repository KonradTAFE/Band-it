using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band_it.Modules
{
    class Set
    {
        public int Id { get; set; }
        public int Reps {  get; set; }
        public string Color { get; set; }

        public Set() { }
        public Set(int id, int reps, string color)
        {
            Id = id;
            Reps = reps;
            Color = color;
        }
    }
}

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
        public Band Band { get; set; }

        public Set() { }
        public Set(int id, int reps, Band band)
        {
            Id = id;
            Reps = reps;
            Band = band;
        }
    }
}

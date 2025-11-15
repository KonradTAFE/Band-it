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
        public string Color { get; set; }
        public List<string> colors { get; set; }

        public List<string> ActiveColors()
        {
            BandPreferences bands = new BandPreferences();
            List<string> colors = new List<string>();
            ObservableCollection<Band> AllBands = bands.GetBands();
            foreach (Band band in AllBands)
            {
                colors.Add(band.Color);
            }
            return colors;
        }

        public Set() { }
        public Set(int id, int reps, string color)
        {
            Id = id;
            Reps = reps;
            Color = color;
            colors = ActiveColors();
        }
    }
}

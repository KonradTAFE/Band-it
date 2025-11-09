using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Band_it.Modules;

namespace Band_it.Services
{
    internal class BandPreferences
    {
        public ObservableCollection<Band> GetBands()
        {
            ObservableCollection<Band> bands = new ObservableCollection<Band>();
            int count = Preferences.Get("BandCount", 0);
            for (int i = 0; i < count; i++)
            {
                string color = Preferences.Get($"Band_{i}_Name", "");
                int resistance = Preferences.Get($"Band_{i}_Resistance", 0);
                if (color != "" && resistance > 0)
                {
                    bands.Add(new Band(color, resistance));
                }
            }
            return bands;
        }

        public void SaveBands(ObservableCollection<Band> bands) 
        {
            Preferences.Set("BandCount", bands.Count);
            for (int i = 0; i < bands.Count; i++)
            {
                Preferences.Set($"Band_{i}_Name", bands[i].Color);
                Preferences.Set($"Band_{i}_Resistance", bands[i].Resistance);
            }
        }

        public void LoadDefaultBands()
        {
            ObservableCollection<Band> defaults = new ObservableCollection<Band>
        {
            new Band("red", 10),
            new Band("orange", 25),
            new Band("black", 40),
            new Band("purple", 55),
            new Band("green", 70)
        };

            SaveBands(defaults);
        }
    }
}

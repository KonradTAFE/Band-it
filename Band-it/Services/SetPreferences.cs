using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Band_it.Modules;

namespace Band_it.Services
{
    internal class SetPreferences
    {
        public ObservableCollection<Set> GetDefault()
        {
            ObservableCollection<Set> sets = new ObservableCollection<Set>();
            int count = Preferences.Get("SetCount", 0);
            for (int i= 0; i < count; i++)
            {
                int id = Preferences.Get($"Set_{i}_Id", 0);
                int reps = Preferences.Get($"Set_{i}_Reps", 0);
                string color = Preferences.Get($"Set{i}_Color", "");
                if (reps != 0 && reps != 0)
                {
                    sets.Add(new Set(id, reps, color));
                }
            }
            return sets;

        }

        public void SaveDefaults(ObservableCollection<Set> sets)
        {
            Preferences.Set("SetCount", sets.Count);
            for (int i = 0; i < sets.Count; i++)
            {
                Preferences.Set($"Set_{i}_Id", sets[i].Color);
                Preferences.Set($"Set_{i}_Reps", sets[i].Reps);
                Preferences.Set($"Set_{i}_Color", sets[i].Color);
            }
        }

        public void AddSet(int id, int reps, string color)
        {
            int index = Preferences.Get("SetCount", 0);
            Preferences.Set("SetCount", index + 1);
            Preferences.Set($"Set_{index}_Id", color);
            Preferences.Set($"Set_{index}_Reps", reps);
            Preferences.Set($"Set_{index}_Color", color);
        }
    }
}

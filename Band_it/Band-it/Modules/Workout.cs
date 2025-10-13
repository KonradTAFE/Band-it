using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band_it.Modules
{
    class Workout
    {
        public int ID { get; set; }
        public DateTime WorkoutDate { get; set; }
        public List<Exercise> ExerciseList { get; set; }
    }
}

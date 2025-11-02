using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band_it.Modules
{
    class Workout
    {
        public int ID { get; set; }
        public DateTime WorkoutDate { get; set; }

// {"exercise_id": [reps/color]}
        public Dictionary<string, List<Set>> ExerciseList { get; set; }

        public Workout() { }
        public Workout(int id, DateTime date, Dictionary<string, List<Set>> exercises)
        {
            ID = id;
            WorkoutDate = date;
            ExerciseList = exercises;
        }
    }

    
}

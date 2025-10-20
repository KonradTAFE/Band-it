using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Band_it.Modules
{
    public class Exercise
    {
        [JsonProperty("exerciseId")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string ExerciseName { get ; set; }

        [JsonProperty("gifUrl")]
        public string Gif { get; set; }

        [JsonProperty("targetMuscles")]
        public string[] PrimaryMuscle {  get; set; }

        [JsonProperty("bodyParts")]
        public string[] BodyParts { get; set; }

        //[JsonProperty("equipments")]
        //public string equipment {  get; set; }

        [JsonProperty("secondaryMuscles")]
        public string[] SecondaryMuscle { get; set; }

        [JsonProperty("instructions")]
        public string[] Description { get; set; }


        public Exercise() { }
        public Exercise(string id, string name, string gif, string[] primary, string[] bodyPart, string[] secondary, string[] desc) 
        {
            Id = id;
            ExerciseName = name;
            Gif = gif;
            PrimaryMuscle = primary;
            BodyParts = bodyPart;
            SecondaryMuscle = secondary;
            Description = desc;
        }


    }
 
}

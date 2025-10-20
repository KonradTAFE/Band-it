using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Band_it.Modules;
using Newtonsoft.Json.Linq;


namespace Band_it.Services
{
    class ApiService
    {
        const string baseURL = "https://www.exercisedb.dev/api/v1/equipments/band/exercises?offset=0&limit=100";

        //Fetch multiple options of exercises
        public async Task<List<Exercise>> GetAllExercises()
        {
            // building request
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new(HttpMethod.Get, baseURL);

            // sending the request
            HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                //TODO: Add exception 
            }
            ;

            //get body response as string (Content)
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            // get json string as C# object
            APISymbolResponse? symbolResponse = JsonConvert.DeserializeObject<APISymbolResponse>(responseString);


            List<Exercise> exercises = new List<Exercise>();

            //for (int i = 0; i < symbolResponse.data.Count; i++)
            //{
            //    Dictionary<string, object> exerciseData = symbolResponse.data[i];
            //    string id = (string)exerciseData["exerciseId"];
            //    string name = (string)exerciseData["name"];
            //    string gif = (string)exerciseData["gifUrl"];
            //    JArray targetMuscles = (JArray)exerciseData["targetMuscles"];
            //    string primary = targetMuscles[0].ToString();
            //    JArray bodyParts = (JArray)exerciseData["bodyParts"];
            //    string body = bodyParts[0].ToString();
            //    JArray secondaryMuscles = (JArray)exerciseData["secondaryMuscles"];
            //    string secondary = secondaryMuscles[0].ToString();
            //    JArray instructions = (JArray)exerciseData["instructions"];
            //    string description = instructions.ToString();

            //    Exercise exercise = new Exercise(id, name, gif, primary, body, secondary, description);
            //    exercises.Add(exercise);
            //}


            if (symbolResponse == null)
            {
                //TODO: Add exception 
            }
;
            return symbolResponse.data.ToList();
        }

        public async Task<List<Exercise>> SearchByName(string name)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new(HttpMethod.Get, baseURL);

            // sending the request
            HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                //TODO: Add exception 
            }
            ;

            //get body response as string (Content)
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            // get json string as C# object
            APISymbolResponse? symbolResponse = JsonConvert.DeserializeObject<APISymbolResponse>(responseString);
            List<Exercise> exercises = new List<Exercise>();
            foreach (Exercise exercise in symbolResponse.data)
            {
                if (exercise.ExerciseName.Contains(name))
                {
                    exercises.Add(exercise);
                }
            }
            return exercises;
        }

        public async Task<List<Exercise>> SearchByMuscle(string muscle)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new(HttpMethod.Get, baseURL);

            // sending the request
            HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                //TODO: Add exception 
            }
            ;

            //get body response as string (Content)
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            // get json string as C# object
            APISymbolResponse? symbolResponse = JsonConvert.DeserializeObject<APISymbolResponse>(responseString);
            List<Exercise> exercises = new List<Exercise>();
            foreach (Exercise exercise in symbolResponse.data)
            {
                if (exercise.PrimaryMuscle.Contains(muscle))
                {
                    exercises.Add(exercise);
                }
            }
            return exercises;

        }
    }
}

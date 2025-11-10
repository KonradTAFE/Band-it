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
        List<Exercise> exerciseList = new List<Exercise>();
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


            if (symbolResponse == null)
            {
                //TODO: Add exception 
            }
;
            return symbolResponse.data.ToList();
        }

        public async Task<List<Exercise>> SearchByName(string name)
        {
            exerciseList.Clear();
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
            
            foreach (Exercise exercise in symbolResponse.data)
            {
                if (exercise.ExerciseName.Contains(name))
                {
                    exerciseList.Add(exercise);
                }
            }
            return exerciseList;
        }

        public async Task<List<Exercise>> SearchByMuscle(string muscle)
        {
            exerciseList.Clear();
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
            
            foreach (Exercise exercise in symbolResponse.data)
            {
                if (exercise.PrimaryMuscle.Contains(muscle))
                {
                    exerciseList.Add(exercise);
                }
            }
            return exerciseList;

        }
    }
}

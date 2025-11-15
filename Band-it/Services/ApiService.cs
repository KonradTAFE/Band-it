using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Band_it.Modules;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;


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
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            // sending the request
            try
            {
                httpResponse = await httpClient.SendAsync(request);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Check internet connection");
                return exerciseList;
            }

            
        

            if (!httpResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"API error: {httpResponse.ToString()}");
                return exerciseList;
            }
            ;

            //get body response as string (Content)
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            // get json string as C# object
            APISymbolResponse? symbolResponse = JsonConvert.DeserializeObject<APISymbolResponse>(responseString);
;
            return symbolResponse.data.ToList();
        }

        public async Task<List<Exercise>> SearchByName(string name)
        {
            exerciseList.Clear();
            List<Exercise> symbolResponse = await GetAllExercises();


            foreach (Exercise exercise in symbolResponse)
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
            List<Exercise> symbolResponse = await GetAllExercises();

            foreach (Exercise exercise in symbolResponse)
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

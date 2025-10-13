using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Band_it.Services
{
    internal class QuotesAPI
    {
        // Ninja key: Ju0z2e5BXp9GVD4x6dZTqw==N2Iqd9zl9C2ooRa6
        const string baseURL = "https://api.api-ninjas.com/v1/quotes";
        const string APIkey = "Ju0z2e5BXp9GVD4x6dZTqw";
        public async Task<List<string>> GetQuotes()
        {
            // building request
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new(HttpMethod.Get, baseURL);
            request.Headers.Add("key", APIkey);

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


            List<string> quotes = new List<string>();

          

            if (quotes == null)
            {
                //TODO: Add exception 
            }
;
            return quotes;
        }
    }
}

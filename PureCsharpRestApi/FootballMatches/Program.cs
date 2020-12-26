using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FootballMatches
{
    public class PageResponse
    {
        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public IEnumerable<FootballMatch> Data { get; set; }
    }

    public class FootballMatch
    {
        [JsonProperty("competition")]
        public string Competition { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("team1")]
        public string Team1 { get; set; }

        [JsonProperty("team2")]
        public string Team2 { get; set; }

        [JsonProperty("team1goals")]
        public string Team1Goals { get; set; }

        [JsonProperty("team2goals")]
        public string Team2Goals { get; set; }
    }

    class Program
    {
        public static async Task<int> getNumDrawsAsync(int year)
        {
            int res = 0;

            //Hardcoded parameters
            var url = "https://jsonmock.hackerrank.com/api/football_matches?team1goals=1&team2goals=1&year=2011&page=1";

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var pageResponse = JsonConvert.DeserializeObject<PageResponse>(json);

                    if (pageResponse != null && pageResponse.Data.Any())
                    {

                    }
                    else
                    {
                        //break; // or throw exception
                    }
                }
                else
                {
                    //break; // or throw exception
                }
            }

            //https://jsonmock.hackerrank.com/api/football_matches?team1goals=1&team2goals=1&year=2011&page=1
            return res;
        }

        static void Main(string[] args)
        {
            int numDraws = getNumDrawsAsync(2011).Result;
            Console.WriteLine("Num Draws: " + numDraws);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
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
        public int Year { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("team1")]
        public int Team1 { get; set; }

        [JsonProperty("team2")]
        public int Team2 { get; set; }

        [JsonProperty("team1goals")]
        public int Team1Goals { get; set; }

        [JsonProperty("team2goals")]
        public int Team2Goals { get; set; }
    }

    class Program
    {
        public static int getNumDraws(int year)
        {
            int res = 0;
            //https://jsonmock.hackerrank.com/api/football_matches?year=2016&page=100
            //https://jsonmock.hackerrank.com/api/football_matches?team1goals=1&team2goals=1&year=2011&page=1
            return res;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

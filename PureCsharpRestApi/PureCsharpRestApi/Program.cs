using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PureCsharpRestApi
{
    public class PageResponse
    {
        public string Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public IEnumerable<Movie> Data { get; set; }
    }

    public class Movie
    {
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
    }

    class Program
    {
        public static async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = new List<Movie>();
            var url = "http://jsonmock.hackerrank.com/api/movies/search/?Title=spiderman";
            int currentPage = 1;
            int totalPages = 0;
            var nextUrl = $"{url}&page={currentPage}";

            using (var httpClient = new HttpClient())
            {
                do
                {
                    HttpResponseMessage response = await httpClient.GetAsync(nextUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var pageResponse = JsonConvert.DeserializeObject<PageResponse>(json);

                        if (pageResponse != null && pageResponse.Data.Any())
                        {
                            movies.AddRange(pageResponse.Data);
                            totalPages = pageResponse.TotalPages;

                            currentPage++;
                            nextUrl = $"{url}&page={currentPage}";
                        }
                        else
                        {
                            break; // or throw exception
                        }
                    }
                    else
                    {
                        break; // or throw exception
                    }
                } while (currentPage < totalPages);
            }

            return movies;
        }

        public static int getNumDraws(int year)
        {
            int res = 0;
            //https://jsonmock.hackerrank.com/api/football_matches?year=2016&page=100
            //https://jsonmock.hackerrank.com/api/football_matches?team1goals=1&team2goals=2&year=2011&page=1
            return res;
        }

        static void Main(string[] args)
        {
            IEnumerable<Movie> movies = GetMoviesAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Retrieved {movies.Count()} movies.");

            Console.ReadKey();
        }
    }
}

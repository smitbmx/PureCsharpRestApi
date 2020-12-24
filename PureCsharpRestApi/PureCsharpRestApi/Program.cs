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

namespace PureCsharpRestApi
{
    class Program
    {
        public static int getNumDraws(int year)
        {
            int res = 0;
            //https://jsonmock.hackerrank.com/api/football_matches?year=2016&page=100
            //https://jsonmock.hackerrank.com/api/football_matches?team1goals=1&team2goals=2&year=2011&page=1
            return res;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

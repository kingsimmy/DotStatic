using DotStatic.Core;
using Newtonsoft.Json;
using System;

namespace DotStatic.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("Arguments should contain the path to a .sln file or space separated paths for multiple .sln files.");
                Environment.Exit(1);
            }
            ProjectsData data = CSharpAnalyser.AnalyseSolutions(args);
            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            Console.WriteLine();
        }
    }
}

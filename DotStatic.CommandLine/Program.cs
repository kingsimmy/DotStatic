using DotStatic.Core;
using System;

namespace DotStatic.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("First argument should be a solutionpath.");
                Environment.Exit(1);
            }
            ProjectsData data = CSharpAnalyser.AnalyseSolution(args[0]);
            Console.ReadLine();
        }
    }
}

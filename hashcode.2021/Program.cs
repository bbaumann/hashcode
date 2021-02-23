using hashcode._2021.Models;
using hashcode._2021.Solvers;
using hashcode.tools;
using System;
using System.Collections.Generic;

namespace hashcode._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> entries = new List<string>() {
                @"data\" // TODO complete the list of files with the ones from competition. Don't forget to configure the Copy to output directory so that we can run the program
            };
            
            SolutionFinder<Solution, State>.launchOnSeveralFiles(entries, new StateFactory(), new SolverFactory());

            string dummy = Console.ReadLine();

        }
    }
}

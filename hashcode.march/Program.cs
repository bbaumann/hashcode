using System.Collections.Generic;
using System;
using hashcode.march.Models;
using hashcode.tools;
using hashcode.march.Solvers;

namespace hashcode.march
{
    class Program
    {
        public static void ConsoleLog(string inMsg) {
            Console.WriteLine(inMsg);
        }
        

        static void Main(string[] args)
        {
        //    List<string> entries = new List<string>() { "a_example", "b_should_be_easy", "c_no_hurry", "d_metropolis", "e_high_bonus" };

            List<string> entries = new List<string>() { "b_should_be_easy", "d_metropolis" };

            //SolutionFinder<Solution, State> finder = new SolutionFinder<Solution, State>("a_example", new StateFactory(), new DumbSolver());

            SolutionFinder<Solution, State>.launchOnSeveralFiles(entries, new StateFactory(), new SolverFactory());

              string dummy = Console.ReadLine();

        }

    }
}

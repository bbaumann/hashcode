using hashcode._2020.Models;
using hashcode._2020.Solvers;
using hashcode.tools;
using System;
using System.Collections.Generic;

namespace hashcode._2020
{
    class Program
    {
        static void Main(string[] args)// C:\fpeltier\hashcode\hashacode_20
        {
            List<string> entries = new List<string>() { "d_metropolis" };
            //Use only one solver
            SolutionFinder<Solution, State> finder = new SolutionFinder<Solution, State>(@"data\a_example.txt", new StateFactory(), new DumbSolver(true));

            //Mix solvers
            //SolutionMixer mixer = new SolutionMixer("e_high_bonus", new StateFactory(), new SolverFactory().GetAllSolvers());
            //mixer.CreateAndRunMixedSolution();

            //SolutionFinder<Solution, State>.launchOnSeveralFiles(entries, new StateFactory(), new SolverFactory());

            string dummy = Console.ReadLine();

        }
    }
}

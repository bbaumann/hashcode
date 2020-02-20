using hashcode._2020.Models;
using hashcode._2020.Solvers;
using hashcode.tools;
using System;
using System.Collections.Generic;

namespace hashcode._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> entries = new List<string>() {
                @"data\a_example.txt",
                @"data\b_read_on.txt",
                @"data\c_incunabula.txt",
                @"data\d_tough_choices.txt",
                @"data\e_so_many_books.txt",
                @"data\f_libraries_of_the_world.txt"
            };
            //Use only one solver
            var thresholdFactorValues = new[] { 1d }; // 0.3d
            var weightValues = new []{ 10d };
            foreach (var thresholdFactorValue in thresholdFactorValues)
            {
                foreach (var weightValue in weightValues)
                {
                    foreach (var entry in entries)
                    {
                        SolutionFinder<Solution, State> finder = new SolutionFinder<Solution, State>(entry, new StateFactory(), new RecomputeScoreSolver(true, thresholdFactorValue, weightValue));
                        finder.SetPostfix($"W{weightValue}_T{thresholdFactorValue}");
                        finder.Run();
                    }
                }
            }

            //Mix solvers
            //SolutionMixer mixer = new SolutionMixer("e_high_bonus", new StateFactory(), new SolverFactory().GetAllSolvers());
            //mixer.CreateAndRunMixedSolution();

            //SolutionFinder<Solution, State>.launchOnSeveralFiles(entries, new StateFactory(), new SolverFactory());

            string dummy = Console.ReadLine();

        }
    }
}

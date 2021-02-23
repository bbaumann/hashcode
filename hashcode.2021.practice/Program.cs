using hashcode._2021.practice.Models;
using hashcode._2021.practice.Solvers;
using hashcode.tools;
using System;
using System.Collections.Generic;

namespace hashcode._2021.practice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> entries = new List<string>() {
                @"data\a_example.in",
                @"data\b_little_bit_of_everything.in",
                @"data\c_many_ingredients.in",
                @"data\d_many_pizzas.in",
                @"data\e_many_teams.in"
            };
            
            SolutionFinder<Solution, State>.launchOnSeveralFiles(entries, new StateFactory(), new SolverFactory());

            string dummy = Console.ReadLine();

        }
    }
}

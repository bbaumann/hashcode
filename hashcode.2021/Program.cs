﻿using hashcode._2021.Models;
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
                @"data\a.txt",
                @"data\b.txt",
                @"data\c.txt",
                @"data\d.txt",
                @"data\e.txt",
                @"data\f.txt"
            };
            
            SolutionFinder<Solution, State>.launchOnSeveralFiles(entries, new StateFactory(), new SolverFactory());

            string dummy = Console.ReadLine();

        }
    }
}

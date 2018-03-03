using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march.Solvers
{
    public class SolverFactory : ISolverFactory<State, Solution>
    {
        public ISolver<State, Solution> newInstance()
        {
            return new MostAveragePointsSolver();
        }
    }
}

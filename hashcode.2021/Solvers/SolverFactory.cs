using hashcode._2021.Models;
using hashcode.tools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2021.Solvers
{
    public class SolverFactory : ISolverFactory<State, Solution>
    {
        public List<ISolver<State, Solution>> GetAllBaseSolvers()
        {
            throw new NotImplementedException();
        }

        public List<BaseSolver> GetAllSolvers()
        {
            throw new NotImplementedException();
        }

        public List<ISolver<State, Solution>> GetAllSolversWithFallback()
        {
            throw new NotImplementedException();
        }
        public ISolver<State, Solution> newInstance()
        {
            return new DumbSolver(true);
        }
    }
}

using hashcode._2022.Models;
using hashcode.tools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2022.Solvers
{
    public class SolverFactory : ISolverFactory<State, Solution>
    {
        public List<ISolver<State, Solution>> GetAllBaseSolvers()
        {
            throw new NotImplementedException();
        }

        public List<ISolver<State, Solution>> GetAllSolversWithFallback()
        {
            throw new NotImplementedException();
        }
        public ISolver<State, Solution> newInstance()
        {
            //TODO logic on how to instantiate solvers goes here (can be called several times to run in parallel)
            return new DumbSolver(true);
        }
    }
}

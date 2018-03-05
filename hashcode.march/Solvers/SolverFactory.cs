using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march.Solvers
{
    public class SolverFactory : ISolverFactory<State, Solution>
    {
        public List<ISolver<State, Solution>> GetAllBaseSolvers()
        {
            return new List<ISolver<State, Solution>>()
            {
                new DumbSolver(),
                new RandomSolver(),
                new MostAveragePointsSolver()
            };
        }

        public List<ISolver<State, Solution>> GetAllSolversWithFallback()
        {
            return new List<ISolver<State, Solution>>()
            {
                new BonusHunterSolver(new DumbRideChooser()),
                new BonusHunterSolver(new RandomRideChooser()),
                new BonusHunterSolver(new MostAveragePointRideChooser())
            };
        }

        public List<BaseSolver> GetAllSolvers()
        {

            return new List<BaseSolver>()
            {
                new DumbSolver(),
                new RandomSolver(),
                new MostAveragePointsSolver(),
                new BonusHunterCarSolver(new RandomRideChooser()),
                new BonusHunterCarSolver(new MostAveragePointRideChooser())
            };
        }

        public List<BaseSolver> GetLimitedBonusHunters()
        {
            return new List<BaseSolver>()
            {
                new BonusHunterCarSolver(new MostAveragePointRideChooser()),
                new BonusHunterCarLimitSolver(500),
                new BonusHunterCarLimitSolver(1000),
                new BonusHunterCarLimitSolver(5000)
            };
        }

        public ISolver<State, Solution> newInstance()
        {
            return new DumbSolver();
        }
    }
}

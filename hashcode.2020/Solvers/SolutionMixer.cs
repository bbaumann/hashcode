using hashcode.tools;
using System;
using System.Linq;
using System.Collections.Generic;
using hashcode._2020.Solvers;
using hashcode._2020.Models;

namespace hashcode._2020.Solvers
{
    public class SolutionMixer : SolutionFinder<Solution, State>
    {
        private List<BaseSolver> solvers;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile">Name of the problem data file</param>
        /// <param name="factory">state factory used to build the initial state from inputFile</param>
        /// <param name="solvers">List of solvers we want to try/mix</param>
        public SolutionMixer(string inputFile, IStateFactory<State> factory, List<BaseSolver> solvers) : base(inputFile, factory, solvers[0])
        {
            this.solvers = solvers;
        }

        public void CreateAndRunMixedSolution()
        {
            //Call once every solver
            var evaluatedSolvers = CompareSolvers().OrderByDescending(s => s.Item2);
            //On selectionne le meilleur algo, et ceux qui sont à  >best-20%
            var toKeep = evaluatedSolvers.Where(s => (bestValue - s.Item2) / bestValue <= 0.2).ToList();
            List<Tuple<BaseSolver, int>> mixedStrategyWithWeight = new List<Tuple<BaseSolver, int>>();
            mixedStrategyWithWeight.Add(new Tuple<BaseSolver, int>(toKeep[0].Item1, 94));
            if (toKeep.Count > 1)
                mixedStrategyWithWeight.Add(new Tuple<BaseSolver, int>(toKeep[1].Item1, 4));
            if (toKeep.Count > 2)
                mixedStrategyWithWeight.Add(new Tuple<BaseSolver, int>(toKeep[2].Item1, 2));
            //mixedStrategy.Add(new Tuple<BaseSolver, int>(new RandomSolver(), 1));

            this.solver = new MixedSolver(mixedStrategyWithWeight);

            //Run forever with the indicated weight
            RunParallel(8);
        }


        public List<Tuple<BaseSolver, double>> CompareSolvers()
        {
            best = default(Solution);
            bestValue = Double.MinValue;
            List<Tuple<BaseSolver, double>> solversWithScores = new List<Tuple<BaseSolver, double>>();
            foreach (var solver in solvers)
            {
                try
                {
                    Solution sol = solver.Solve(s);
                    double score = sol.Value(s);
                    solversWithScores.Add(new Tuple<BaseSolver, double>(solver, score));
                    if (score > bestValue)
                    {
                        bestSolutionCount++;
                        bestValue = score;
                        best = sol;
                        Console.WriteLine("New solution found for " + inputFile + " with score:" + score + " and algo " + solver.GetType().Name);
                        writeSolution();
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(e);
                }
            }

            return solversWithScores;
        }

    }
}

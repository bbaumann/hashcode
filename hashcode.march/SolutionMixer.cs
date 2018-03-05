using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Solvers;

namespace hashcode.march
{
    public class SolutionMixer : SolutionFinder<Solution, State>
    {
        private List<BaseSolver> solvers;

        public SolutionMixer(string inputFile, IStateFactory<State> factory, List<BaseSolver> solvers) : base(inputFile, factory, solvers[0])
        {
            this.solvers = solvers;
        }

        public void CreateAndRunMixedSolution()
        {
            var evaluatedSolvers = CompareSolvers().OrderByDescending(s => s.Item2);
            //On selectionne le meilleur algo, et ceux qui sont à  >best-30%
            //On prend toujours aussi un peu de hasard
            var toKeep = evaluatedSolvers.Where(s => (bestValue - s.Item2) / bestValue <= 0.2).ToList();
            List<Tuple<BaseSolver, int>> mixedStrategy = new List<Tuple<BaseSolver, int>>();
            mixedStrategy.Add(new Tuple<BaseSolver, int>(toKeep[0].Item1, 94));
            if (toKeep.Count > 1)
                mixedStrategy.Add(new Tuple<BaseSolver, int>(toKeep[1].Item1, 3));
            if (toKeep.Count > 2)
                mixedStrategy.Add(new Tuple<BaseSolver, int>(toKeep[2].Item1, 2));
            //mixedStrategy.Add(new Tuple<BaseSolver, int>(new RandomSolver(), 1));

            this.generator = new MixedSolver(mixedStrategy);

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

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace hashcode.tools
{
    public class SolutionFinder<Solution, State> where Solution : ISolution<State>
    {

        private static Object mutex = new object();
        protected readonly State s;
        protected readonly String inputFile;
        protected ISolver<State, Solution> solver;

        private int iteration = 0;
        protected int bestSolutionCount = 0;
        protected double bestValue;
        protected Solution best;
        private string _postfix = "";

        public SolutionFinder(String inputFile, IStateFactory<State> factory,
        ISolver<State, Solution> solver) {
            this.solver = solver;
            s = factory.fromString(hashcode.tools.FileHelper.ReadFileContent(inputFile));
            this.inputFile = inputFile;
        }

        public void SetPostfix(string postfix)
        {
            _postfix = postfix;
        }

        public void Run()
        {
            best = default(Solution);
            bestValue = Double.MinValue;
            while (true){
                try{
                    iteration++;
                    if (iteration % 10 == 0)
                        Logger.Log(iteration.ToString());
                    //System.out.println(iteration);
                    Solution next = solver.Solve(s);
                    if (next == null)
                    {
                        return;
                    }
                    double score = next.Value(s);
                    if (score > bestValue){
                        bestSolutionCount++;
                        bestValue = score;
                        best = next;
                        Console.WriteLine("New solution found for "+inputFile+" with score:"+score);
                        writeSolution(_postfix);
                    }
                }
                catch (Exception e){
                    Logger.Log(e);
                }
            }
        }

        public void RunParallel(int nbTasks)
        {
            best = default(Solution);
            bestValue = Double.MinValue;

            Action run = () =>
            {
                while (true)
                {
                    try
                    {
                        lock (mutex)
                        {
                            iteration++;
                            if (iteration % 10 == 0)
                                Logger.Log(iteration.ToString());
                            //System.out.println(iteration);
                        }
                        Solution next = solver.Solve(s);
                        if (next == null)
                            break;
                        double score = next.Value(s);
                        lock (mutex)
                        {
                            if (score > bestValue)
                            {
                                bestSolutionCount++;
                                bestValue = score;
                                best = next;
                                Console.WriteLine("New solution found for " + inputFile + " with score:" + score);
                                writeSolution();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Log(e);
                    }
                }
            };
            List<Action> toRun = new List<Action>();
            for (int i = 0; i < nbTasks; i++)
            {
                toRun.Add(run);
            }
            Parallel.Invoke(toRun.ToArray());
        }

        protected void writeSolution(string postfix = "") {
            FileHelper.WriteFileContent(inputFile+"_"+bestValue+"_"+bestSolutionCount+postfix+".out", best.ToOutputFormat(), false);
        }

        public static void launchOnSeveralFiles(List<String> filenames, IStateFactory<State> factory,
        ISolverFactory<State, Solution> generatorFactory){
            IEnumerable<SolutionFinder<Solution,State>> finders = filenames.Select(f =>
                new SolutionFinder<Solution,State>(f,factory,generatorFactory.newInstance()));

            Parallel.Invoke(finders.Select(f => new Action(f.Run)).ToArray());
        }
    }
}

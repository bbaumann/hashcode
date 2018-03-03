using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace hashcode.tools
{
    public class SolutionFinder<Solution, State> where Solution : ISolution<State>
    {
        private readonly State s;
        private readonly String inputFile;
        private readonly ISolver<State, Solution> generator;
        
        private int iteration = 0;
        private int bestSolutionCount = 0;
        private double bestValue;
        private Solution best;
        
        public SolutionFinder(String inputFile, IStateFactory<State> factory,
        ISolver<State, Solution> generator) {
            this.generator = generator;
            s = factory.fromString(hashcode.tools.FîleHelper.ReadFileContent(inputFile+".in"));
            this.inputFile = inputFile;
        }
        
        public void Run(){
            best = default(Solution);
            bestValue = Double.MinValue;
            while (iteration++ <1){
                try{
                    iteration++;
                    //System.out.println(iteration);
                    Solution next = generator.Solve(s);
                    double score = next.Value(s);
                    if (score > bestValue){
                        bestSolutionCount++;
                        bestValue = score;
                        best = next;
                        Console.WriteLine("New solution found for "+inputFile+" with score:"+score);
                        writeSolution();
                    }
                }
                catch (Exception e){
                    Logger.Log(e);
                }
            }
        }

        private void writeSolution() {
            FîleHelper.WriteFileContent(inputFile+"_"+bestValue+"_"+bestSolutionCount+".out", best.ToOutputFormat(), false);
        }
        
        public static void launchOnSeveralFiles(List<String> filenames, IStateFactory<State> factory,
        ISolverFactory<State, Solution> generatorFactory){
            IEnumerable<SolutionFinder<Solution,State>> finders = filenames.Select(f =>
                new SolutionFinder<Solution,State>(f,factory,generatorFactory.newInstance()));
            
            Parallel.Invoke(finders.Select(f => new Action(f.Run)).ToArray());
            //foreach (var finder in finders)
            //{
            //    Task.Run(new Action(finder.Run));
            //}
        }
    }
}

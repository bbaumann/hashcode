using hashcode._2020.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2020.Solvers
{
    public abstract class BaseSolver : ISolver<State, Solution>
    {
        public virtual bool IsDeterministic { get; }
        protected virtual int ExecutionCount { get; set; } = 0;
        public BaseSolver(bool isDeterministic)
        {
            IsDeterministic = isDeterministic;
        }

        public Solution Solve(State state)
        {
            if (IsDeterministic && ExecutionCount > 0)
                return null;
            //Real stuff happens here
            //We have an initial state, we should return a solution to this problem (state)
            Solution res = new Solution(state);
            //Update res with whatever is the solution

            ExecutionCount++;
            return res;
        }
    }
}

using hashcode._2022.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2022.Solvers
{
    public abstract class BaseSolver : ISolver<State, Solution>
    {
        public virtual bool IsDeterministic { get; }
        protected virtual int ExecutionCount { get; set; } = 0;

        protected virtual State State { get; private set; }

        public BaseSolver(bool isDeterministic)
        {
            IsDeterministic = isDeterministic;
        }

        public Solution Solve(State state)
        {
            State = state;
            if (IsDeterministic && ExecutionCount > 0)
                return null;
            //Real stuff happens here
            //We have an initial state, we should return a solution to this problem (state)
            Solution res = new Solution(state);
            //Update res with whatever is the solution

            DoSolve(res);

            ExecutionCount++;
            return res;
        }

        protected abstract void DoSolve(Solution res);
    }
}

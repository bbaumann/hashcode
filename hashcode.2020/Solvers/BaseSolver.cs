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
        public BaseSolver()
        {
        }

        public Solution Solve(State state)
        {
            //Real stuff happens here
            //We have an initial state, we should return a solution to this problem (state)
            Solution res = new Solution(state);
            //Update res with whatever is the solution
            
            return res;
        }
    }
}

using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hashcode._2021.Models
{
    public class Solution : ISolution<State>
    {
        State state = null;
        List<Schedule> Schedules = new List<Schedule>();

        public Solution(State state)
        {
            this.state = state;
        }

        /// <summary>
        /// Returns a string that can be submitted to the Oracle
        /// </summary>
        /// <returns></returns>
        public string ToOutputFormat()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }

        /// <summary>
        /// Returns the score of the solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double Value(State s)
        {
            return 0;
        }
    }
}

using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hashcode._2021.practice.Models
{
    public class Solution : ISolution<State>
    {
        State state = null;

        public List<Delivery> Deliveries = new List<Delivery>();

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
            sb.AppendLine(Deliveries.Count.ToString());
            foreach (Delivery d in Deliveries) {
                sb.AppendLine(d.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the score of the solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double Value(State s)
        {
            return Deliveries.Sum(d => d.Score());
        }
    }
}

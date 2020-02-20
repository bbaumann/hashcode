using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hashcode._2020.Models
{
    public class Solution : ISolution<State>
    {
        State state = null;

        /// <summary>
        /// Ordered Libraries by signup date
        /// </summary>
        public List<WorkingLibrary> Libraries { get; set; }

        public Solution(State state)
        {
            this.state = state;
            Libraries = new List<WorkingLibrary>();
        }

        /// <summary>
        /// Returns a string that can be submitted to the Oracle
        /// </summary>
        /// <returns></returns>
        public string ToOutputFormat()
        {
            var libToOutput = Libraries.Where(l => l.OrderedBooksToScan.Any()).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(libToOutput.Count.ToString());
            foreach (var library in libToOutput)
            {
                sb.AppendLine($"{library.Id} {library.OrderedBooksToScan.Count}");
                sb.AppendLine(String.Join(' ', library.OrderedBooksToScan.Select(b => b.Id.ToString())));
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
            ///TODO affiner pour savoir si le livre sera vraiment scanné ou pas
            return Libraries
                .SelectMany(l => l.OrderedBooksToScan)
                .Distinct()
                .Sum(b => b.Score);
        }
    }
}

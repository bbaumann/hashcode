
using System.Collections.Generic;

namespace hashcode._2021.Models
{
    /// <summary>
    /// Model the problem. Contains only the input, nothing about the solution.
    /// </summary>
    public class State
    {
        public List<Street> Streets { get; set; }

        public List<Car> Cars { get; set; }

        public State()
        {
        }
    }
}

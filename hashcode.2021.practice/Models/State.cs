
using System.Collections.Generic;

namespace hashcode._2021.practice.Models
{
    /// <summary>
    /// Model the problem. Contains only the input, nothing about the solution.
    /// </summary>
    public class State
    {
        public int[] teamsCount = new [] {0,0,0,0,0};
        public List<Pizza> pizzas = new List<Pizza>();

        public State()
        {
        }
    }
}

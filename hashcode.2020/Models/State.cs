
using System.Collections.Generic;

namespace hashcode._2020.Models
{
    /// <summary>
    /// Model the problem. Contains only the input, nothing about the solution.
    /// </summary>
    public class State
    {
        public int NbBooks { get; set; }

        public int NbLibraries { get; set; }

        public int NbDays { get; set; }

        public Dictionary<int, int> ScoreByBookId { get; set; } = new Dictionary<int, int>();

        public List<Library> Libraries { get; set; } = new List<Library>();

        public State()
        {
        }
    }
}

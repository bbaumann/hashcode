
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

        public Dictionary<int,int> ScoreByBookId { get; set; }

        public List<Library> Libraries { get; set; }

        public State()
        {
        }        
    }
}


using System;
using System.Linq;
using System.Collections.Generic;

namespace hashcode._2022.Models
{
    /// <summary>
    /// Model the problem. Contains only the input, nothing about the solution.
    /// </summary>
    public class State
    {
        public List<Project> Projects { get; init; }
        public List<Contributor> Contributors { get; init; }

        public State()
        {
            Contributors = new List<Contributor>();
            Projects = new List<Project>();
        }

    }
}

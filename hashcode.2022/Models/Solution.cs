using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hashcode._2022.Models
{
    public class Solution : ISolution<State>
    {
        public class ProjectDone
        {
            public Project _proj;
            public int _startDate = -1;
            public Dictionary<string, Contributor> _contributor = new Dictionary<string, Contributor>();
        }


        public class ContributorAffected
        {
            public Contributor _contrib;

            public int _availableDate = 0;

            public Dictionary<Project, string> _affectedRole = new Dictionary<Project, string>();

        }

        public List<ContributorAffected> _affectContr = new List<ContributorAffected>();
        public List<ProjectDone> _projectDone = new List<ProjectDone> ();

        State state = null;
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
            sb.AppendLine(_projectDone.Count.ToString());

            foreach (var project in _projectDone)
            {
                var contrib = new List<string>();
                project._proj.OrderedRoles.ForEach(r => contrib.Add(project._contributor[r].Name);
                sb.AppendLine(string.Join(' ', contrib));
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
            int score = 0;
            foreach(var projDone in _projectDone)
            {
                int endDate = projDone._startDate + projDone._proj.Duration;
                int malus = Math.Max(endDate - projDone._proj.BestBefore, 0);
                score += Math.Max(projDone._proj.Score - malus, 0);
            }

            return score;
        }
    }
}

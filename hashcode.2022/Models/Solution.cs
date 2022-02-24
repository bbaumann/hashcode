using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static hashcode._2022.Models.Project;

namespace hashcode._2022.Models
{
    public class Solution : ISolution<State>
    {
        public ContributorRepository ContributorRepository { get; init; }
        public ProjectRepository ProjectRepository { get; init; }


        private List<ProjectDone> _projectDone = new List<ProjectDone> ();

        State state = null;
        public Solution(State state)
        {
            this.state = state;
            ContributorRepository = new ContributorRepository();
            foreach (var contributor in state.Contributors)
            {
                ContributorRepository.AddContributor(contributor);
            }

            ProjectRepository = new ProjectRepository(state.Projects);

        }

        public void DoProject(ProjectDone project)
        {
            project._startDate = project.ContributorByRole.Max( tup => tup.Item2._availableDate);

            foreach (var (role, contributor) in project.ContributorByRole)
            {
                contributor._availableDate = project._startDate + project._proj.Duration;
                contributor._contrib.IncreaseSkillIfNeeded(role);
            }

            _projectDone.Add(project);
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
                sb.AppendLine(project._proj.Name);
                //project._proj.RequiredRoles.ForEach(r => contrib.Add(project.ContributorByRole[r]._contrib.Name));
                sb.AppendLine(string.Join(' ', project.ContributorByRole.Select(tup => tup.Item2._contrib.Name)));
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
                score += projDone.getScoreWithStartDate(projDone._startDate);
            }

            return score;
        }
    }
}

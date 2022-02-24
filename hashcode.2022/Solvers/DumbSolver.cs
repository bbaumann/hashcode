using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hashcode._2022.Models;
using static hashcode._2022.Models.Project;
using static hashcode._2022.Models.Solution;

namespace hashcode._2022.Solvers
{
    public class DumbSolver : BaseSolver
    {
        public DumbSolver(bool isDeterministic) : base(isDeterministic)
        {
        }

        protected override void DoSolve(Solution res)
        {
            var proj = res.ProjectRepository.GetNext();

            while (proj != null)
            {
                var projectDone = new ProjectDone()
                {
                    _proj = proj
                };

                bool canDoProject = true;

                foreach (var role in proj.RequiredRoles)
                {
                    var candidates =
                        res.ContributorRepository
                            .FindContributors(role.Key, role.Value)
                            .Except(projectDone.ContributorByRole.Values)
                            .ToList();

                    var winner = candidates.FirstOrDefault();
                    if (winner == null)
                    {
                        canDoProject = false;
                        break;
                    }
                    projectDone.ContributorByRole[role.Key] = winner;
                }

                if (!canDoProject)
                {
                    proj = res.ProjectRepository.GetNext();
                    continue;
                }

                projectDone._startDate = projectDone.ContributorByRole.Values.Max(contrib => contrib._availableDate);

                foreach (var (role,contributor) in projectDone.ContributorByRole)
                {
                    contributor._availableDate = projectDone._startDate + projectDone._proj.Duration;
                    contributor._contrib.IncreaseSkillIfNeeded(role, projectDone._proj.RequiredRoles[role]);
                }

                res._projectDone.Add(projectDone);

                proj = res.ProjectRepository.GetNext();
            }
        }
    }
}

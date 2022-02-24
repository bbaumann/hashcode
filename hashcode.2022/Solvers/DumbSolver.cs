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

            //go back to project available
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

                    //TODO choix du winner
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
                    //TODO choix du projet
                    proj = res.ProjectRepository.GetNext();
                    continue;
                }

                res.DoProject(projectDone);

                //TODO choix du projet
                proj = res.ProjectRepository.GetNext();
            }
        }
    }
}

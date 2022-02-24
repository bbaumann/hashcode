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

            int nbFailsInARow = 0;

            //go back to project available
            while (proj != null && nbFailsInARow <= res.ProjectRepository.NbProjects)
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
                    int scoreMax = 0;
                    int skillLevel = 1000000000;
                    ContributorAffected winner = null;
                    foreach (var candidate in candidates)
                    {
                        int scoreWithCandidate = projectDone.getScoreWithStartDate(candidate._availableDate);
                        if(scoreMax < scoreWithCandidate)
                        {
                            scoreMax = scoreWithCandidate;
                            winner = candidate;
                            skillLevel = candidate._contrib.Skills[role.Key];
                        } else if(scoreMax == scoreWithCandidate && skillLevel > candidate._contrib.Skills[role.Key]) // todo only less skilled candidate
                        {
                            scoreMax = scoreWithCandidate;
                            winner = candidate;
                            skillLevel = candidate._contrib.Skills[role.Key];
                        }
                    }
                    
                    if (winner == null)
                    {
                        canDoProject = false;
                        break;
                    }
                    projectDone.ContributorByRole[role.Key] = winner;
                }

                if (!canDoProject)
                {
                    nbFailsInARow++;
                    res.ProjectRepository.AddProject(proj);
                    //TODO choix du projet
                    proj = res.ProjectRepository.GetNext();
                    continue;
                }

                nbFailsInARow = 0;

                res.DoProject(projectDone);

                //TODO choix du projet
                proj = res.ProjectRepository.GetNext();
            }
        }
    }
}

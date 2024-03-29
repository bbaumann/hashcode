﻿using System;
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
                    var realLevel = new Role { Level = role.Level, Name = role.Name };
                    if (projectDone.ContributorByRole.Any(tup => tup.Item2._contrib.HasSkill(role.Name, role.Level)))
                    {
                        realLevel.Level--;
                    }

                    var candidates =
                        res.ContributorRepository
                            .FindContributors(realLevel)
                            .Except(projectDone.ContributorByRole.Select( tup => tup.Item2))
                            .ToList();

                    //TODO choix du winner
                    int scoreMax = 0;
                    int skillLevel = 1000000000;
                    ContributorAffected winner = null;
                    foreach (var candidate in candidates)
                    {
                        int scoreWithCandidate = projectDone.getScoreWithStartDate(candidate._availableDate);
                        if ( 
                            (scoreMax < scoreWithCandidate)
                            //|| (scoreMax == scoreWithCandidate && skillLevel == 0)
                            || (scoreMax == scoreWithCandidate && skillLevel > candidate._contrib.GetSkillLevel(role.Name))
                            )
                        {
                            scoreMax = scoreWithCandidate;
                            winner = candidate;
                            skillLevel = candidate._contrib.GetSkillLevel(role.Name);
                        }
                    }
                    
                    if (winner == null)
                    {
                        canDoProject = false;
                        break;
                    }

                    projectDone.ContributorByRole.Add((role,winner));
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

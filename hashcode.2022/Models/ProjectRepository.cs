﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode._2022.Models
{
    public class ProjectRepository
    {
        public ProjectRepository(List<Project> projects)
        {
            Projects = projects;
        }

        private List<Project> Projects { get; }

        public Project GetNext()
        {
            var res = Projects.FirstOrDefault();
            if (res != null)
                Projects.Remove(res);
            return res;
        }


        public void AddProject(Project project) => Projects.Add(project);

        public int NbProjects => Projects.Count;

        public Project GetNextBestScore()
        {
            int score = 0;
            Project bestProj = null;
            foreach(var p in Projects)
            {
                if(p.Score > score )
                {
                    bestProj = p;
                    score = p.Score;
                }
            }
            if (bestProj != null)
                Projects.Remove(bestProj);
            return bestProj;
        }

    }
}

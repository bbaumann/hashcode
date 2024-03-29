﻿using System;
using System.Collections.Generic;


namespace hashcode._2022.Models
{
    public class Project
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Score { get; set; }
        public int BestBefore { get; set; }

        public List<Role> RequiredRoles { get; init; }

        public Project()
        {
            RequiredRoles = new List<Role>();
        }

        public void AddRequiredRole(string role, int level)
        {
            RequiredRoles.Add(new Role { Name = role, Level = level });
        }


        public class ProjectDone
        {
            public Project _proj;
            public int _startDate = -1;

            public int getScoreWithStartDate(int sd)
            {
                int score = 0;
                int endDate = sd + _proj.Duration;
                int malus = Math.Max(endDate - _proj.BestBefore, 0);
                score = Math.Max(_proj.Score - malus, 0);
                return score;
            }

            public List<(Role, ContributorAffected)> ContributorByRole = new List<(Role, ContributorAffected)>();
        }

        public class Role
        {
            public string Name { get; set; }
            public int Level { get; set; }

            public bool _isUpdated = false;
        }
    }
}

using System.Collections.Generic;

namespace hashcode._2022.Models
{
    public class Project
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Score { get; set; }
        public int BestBefore { get; set; }

        public Dictionary<string, int> RequiredRoles { get; init; }

        public List<string> OrderedRoles { get; init; }

        public Project()
        {
            RequiredRoles = new Dictionary<string, int>();
            OrderedRoles = new List<string>();
        }

        public void AddRequiredRole(string role, int level)
        {
            RequiredRoles[role] = level;
            OrderedRoles.Add(role);
        }


        public class ProjectDone
        {
            public Project _proj;
            public int _startDate = -1;
            public Dictionary<string, ContributorAffected> ContributorByRole = new Dictionary<string, ContributorAffected>();
        }
    }
}

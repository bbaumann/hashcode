using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode._2022.Models
{
    public class Project
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Score { get; set; }
        public int BestBefore { get; set; }

        public Dictionary<string,int> RequiredRoles { get; init; }

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
    }
}

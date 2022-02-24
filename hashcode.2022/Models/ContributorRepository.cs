using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hashcode._2022.Models.Project;

namespace hashcode._2022.Models
{
    public class ContributorRepository
    {
        private List<ContributorAffected> contributors = new List<ContributorAffected>();

        public void AddContributor(Contributor c) => contributors.Add(
            new ContributorAffected
            {
                _contrib = new Contributor(c)
            });

        public List<ContributorAffected> FindContributors(Role role)
            => contributors.Where(c => c._contrib.HasSkill(role.Name, role.Level)).ToList();

        public List<ContributorAffected> FindAvailableContributors(string skill, int level, int date)
            => contributors.Where(c => c._contrib.HasSkill(skill, level) && c._availableDate <= date).ToList();

    }
}

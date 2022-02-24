using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<ContributorAffected> FindContributors(string skill, int level)
            => contributors.Where(c => c._contrib.HasSkill(skill, level)).ToList();

        public List<ContributorAffected> FindAvailableContributors(string skill, int level, int date)
            => contributors.Where(c => c._contrib.HasSkill(skill, level) && c._availableDate < date).ToList();
    }
}

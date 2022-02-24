using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode._2022.Models
{
    public class ContributorRepository
    {
        private List<Contributor> contributors = new List<Contributor>();

        public void AddContributor(Contributor c) => contributors.Add(c);

        public List<Contributor> FindContributors(string skill, int level)
            => contributors.Where(c => c.HasSkill(skill, level)).ToList();
    }
}

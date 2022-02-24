using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode._2022.Models
{
    class Contributor
    {
        public string Name { get; set; }

        public Dictionary<string,int> Skills { get; init; }

        public void AddSkill(string skill, int level)
        {
            Skills[skill] = level;
        }

        public void IncreaseSkill(string skill)
        {
            if (Skills.ContainsKey(skill))
                Skills[skill]++;
            else
                Skills[skill] = 1;
        }
    }
}

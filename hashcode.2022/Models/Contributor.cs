using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hashcode._2022.Models.Project;

namespace hashcode._2022.Models
{
    public class Contributor
    {
        public string Name { get; set; }

        public Dictionary<string,int> Skills { get; init; }

        public void AddSkill(string skill, int level)
        {
            Skills[skill] = level;
        }

        public bool HasSkill(string skill, int level)
        {
            if (level == 0) return true;
            return Skills.TryGetValue(skill, out var value) && value >= level;
        }

        public bool HasExactSkill(string skill, int level)
        {
            if (level == 0) return !Skills.ContainsKey(skill);
            return Skills.TryGetValue(skill, out var value) && value == level;
        }

        public void IncreaseSkill(string skill)
        {
            if (Skills.ContainsKey(skill))
                Skills[skill]++;
            else
                Skills[skill] = 1;
        }

        public void IncreaseSkillIfNeeded(Role role)
        {
            var skill = role.Name;
            var expectedLevel = role.Level;
            if (!HasSkill(skill, expectedLevel))
                IncreaseSkill(skill);
            if (HasExactSkill(skill, expectedLevel))
                IncreaseSkill(skill);
        }

        public Contributor()
        {
            Skills = new Dictionary<string, int>();
        }

        public Contributor(Contributor other)
        {
            Name = other.Name;
            Skills = new Dictionary<string,int>(other.Skills);
        }
    }

    public class ContributorAffected
    {
        public Contributor _contrib;

        public int _availableDate = 0;

        public Dictionary<Project, string> _affectedRole = new Dictionary<Project, string>();
    }
}

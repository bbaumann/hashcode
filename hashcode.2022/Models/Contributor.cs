﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

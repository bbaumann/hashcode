using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2022.Models
{
    public class StateFactory : IStateFactory<State>
    {
        /// <summary>
        /// Parse the problem input and returns a State modelizing it
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public State fromString(string s)
        {
            int lineIndex = 0;

            State state = new State();
            string[] lines = s.Split('\n');
            string[] inputs = lines[lineIndex].Trim().Split(' ');
            //Parse the first line here here

            var nbContrib = int.Parse(inputs[0]);
            var nbProjects = int.Parse(inputs[1]); //ids from 0 to I-1

            lineIndex++;

            for (int contribIndex = 0; contribIndex < nbContrib ; contribIndex++)
            {
                var line = lines[lineIndex];
                var input = line.Trim().Split(' ');
                var contributor = new Contributor();
                contributor.Name = input[0];
                var nbSkills = int.Parse(input[1]);
                
                lineIndex++;
                
                for (int j = 0; j < nbSkills; j++)
                {
                    var skillLine = lines[lineIndex];
                    var skillInput = skillLine.Trim().Split(' ');
                    contributor.AddSkill(skillInput[0], int.Parse(skillInput[1]));
                    
                    lineIndex++;
                }

                state.Contributors.Add(contributor);
            }

            for (int projectIndex = 0; projectIndex < nbProjects; projectIndex++)
            {
                var line = lines[lineIndex];
                var input = line.Trim().Split(' ');
                var project = new Project()
                {
                    Name = input[0],
                    Duration = int.Parse(input[1]),
                    Score = int.Parse(input[2]),
                    BestBefore = int.Parse(input[3])
                };

                var nbRoles = int.Parse(input[4]);

                lineIndex++;

                for (int rolesIndex = 0; rolesIndex < nbRoles; rolesIndex++)
                {
                    var roleLine = lines[lineIndex];
                    var roleInput = roleLine.Trim().Split(' ');

                    project.AddRequiredRole(roleInput[0], int.Parse(roleInput[1]));

                    lineIndex++;
                }

                state.Projects.Add(project);
            }

            return state;
        }
    }
}

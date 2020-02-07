using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2020.Models
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
            State state = new State();
            string[] lines = s.Split('\n');
            string[] inputs = lines[0].Split(' ');
            //Parse the first line here here
            
            for (int lineIndex = 1; lineIndex < lines.Length; lineIndex++)
            {
                inputs = lines[lineIndex].Split(' ');
                //Parse the line here
            }

            return state;
        }
    }
}

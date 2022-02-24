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


            int i = 0;

            State state = new State();
            string[] lines = s.Split('\n');
            string[] inputs = lines[i].Trim().Split(' ');
            //Parse the first line here here

            var simulationDuration = int.Parse(inputs[0]);
            var nbIntersections = int.Parse(inputs[1]); //ids from 0 to I-1
            var nbStreets = int.Parse(inputs[2]);
            var nbCars = int.Parse(inputs[3]);
            var bonusPoint = int.Parse(inputs[4]);

            return state;
        }
    }
}

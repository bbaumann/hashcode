using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2021.practice.Models
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
            var state = new State();

            var lines = s.Split('\n');
            var input = lines[0].TrimEnd().Split(' ');

            var pizzaCount = int.Parse(input[0]);
            state.teamsCount = new[] {0, 0, int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3])};

            for (var pizzaId = 0; pizzaId < pizzaCount; ++pizzaId)
            {
                input = lines[1 + pizzaId].TrimEnd().Split(' ');
                state.pizzas.Add(new Pizza
                {
                    Id = pizzaId,
                    Ingredients = input.Skip(1).ToList()
                });
            }

            return state;
        }
    }
}

using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hashcode.march.Models
{
    public class Solution : ISolution<State>
    {
        State state = null;

        public List<Car> Cars { get; private set; }

        public Solution(State state)
        {
            this.state = state;
            this.Cars = new List<Car>(state.CarsCount);
            for (int carIndex = 0; carIndex < state.CarsCount; ++carIndex)
            {
                Cars.Add(new Car(state.StartOnTimeBonus, state.StepCount));
            }
        }

        public string ToOutputFormat()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var car in this.Cars)
            {
                sb.AppendLine(car.DumpRides());
            }
            return sb.ToString();
        }

        public double Value(State s)
        {
            return this.Cars.Sum(car => car.Score);
        }
    }
}

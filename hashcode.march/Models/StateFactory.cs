using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march.Models
{
    public class StateFactory : IStateFactory<State>
    {
        public State fromString(string s)
        {
            State state = new State();
            string[] lines = s.Split('\n');
            string[] inputs = lines[0].Split(' ');
            int index = 0;
            state.RowCount = int.Parse(inputs[index++]);
            state.ColCount = int.Parse(inputs[index++]);
            state.CarsCount = int.Parse(inputs[index++]);
            state.RidesCount = int.Parse(inputs[index++]);
            state.StartOnTimeBonus = int.Parse(inputs[index++]);
            state.StepCount = int.Parse(inputs[index++]);

            for (int rideIndex = 0; rideIndex < state.RidesCount; ++rideIndex)
            {
                inputs = lines[rideIndex+1].Split(' ');
                state.Rides.Add(new Ride(state.StartOnTimeBonus, state.StepCount)
                {
                    StartingPoint = new Coord(int.Parse(inputs[0]), int.Parse(inputs[1])),
                    FinishPoint = new Coord(int.Parse(inputs[2]), int.Parse(inputs[3])),
                    EarliestStart = int.Parse(inputs[4]),
                    LatestFinish = int.Parse(inputs[5]),
                    Id = rideIndex
                });
            }

            return state;
        }
    }
}

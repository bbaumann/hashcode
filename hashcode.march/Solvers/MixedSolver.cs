using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class MixedSolver : ISolver<State, Solution>
    {
        private IRideChooser randomRideChooser = new RandomRideChooser();
        private IRideChooser mostAveragePointRideChooser = new MostAveragePointRideChooser();

        private Random rand = new Random();

        public Solution Solve(State state)
        {
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            List<Ride> toRemove = new List<Ride>();
            Solution res = new Solution(state);

            foreach (var car in res.Cars)
            {
                bool again = true;
                while (again)
                {
                    double r = rand.NextDouble();
                    if (r <=0.9)
                    {
                        again = mostAveragePointRideChooser.ChooseRide(car, remainingRides);
                    }
                    else
                    {
                        again = randomRideChooser.ChooseRide(car, remainingRides);
                    }
                }
            }
            return res;
        }
    }
}

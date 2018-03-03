using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class MostAveragePointsSolver : ISolver<State, Solution>
    {
        private IRideChooser rideChooser = new MostAveragePointRideChooser();

        public Solution Solve(State state)
        {
            Solution res = new Solution(state);
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            foreach (var car in res.Cars)
            {
                while (rideChooser.ChooseRide(car,remainingRides))
                {
                    
                }
            }
            return res;
        }
    }
}

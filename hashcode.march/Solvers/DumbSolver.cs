using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class DumbSolver : ISolver<State, Solution>
    {
        private IRideChooser rideChooser = new DumbRideChooser();

        public Solution Solve(State state)
        {
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            List<Ride> toRemove = new List<Ride>();
            Solution res = new Solution(state);

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

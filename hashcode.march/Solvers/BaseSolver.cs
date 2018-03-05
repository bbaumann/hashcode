using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public abstract class BaseSolver : ISolver<State, Solution>
    {
        public IRideChooser rideChooser = new DumbRideChooser();

        public BaseSolver(IRideChooser rideChooser)
        {
            this.rideChooser = rideChooser;
        }

        public Solution Solve(State state)
        {
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            List<Ride> toRemove = new List<Ride>();
            Solution res = new Solution(state);

            rideChooser.Init();

            while (remainingRides.Any() && res.Cars.Any(c => !c.ServiceEnded))
            {
                rideChooser.ChooseRide(res.Cars, remainingRides);
            }
            Logger.Log($"{remainingRides.Count} remaining rides, {res.Cars.Count(c => !c.ServiceEnded)} cars left");
            return res;
        }
    }
}

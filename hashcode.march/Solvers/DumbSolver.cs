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
        public Solution Solve(State state)
        {
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            List<Ride> toRemove = new List<Ride>();
            Solution res = new Solution(state);

            for (int step = 0; step < state.StepCount; step++)
            {
                toRemove.Clear();
                if (!remainingRides.Any())
                {
                    break;
                }
                foreach (var ride in remainingRides)
                {
                    if (!ride.IsOk())
                    {
                        continue;
                    }
                    foreach (var car in res.Cars)
                    {
                        if (car.IsAvailable(step) && car.CanDoRide(ride).Item1)
                        {
                            car.DoRide(ride);
                            toRemove.Add(ride);
                            break;
                        }
                    }
                }

                if (toRemove.Any())
                {
                    remainingRides.RemoveAll(r => toRemove.Contains(r));
                }
            }
            return res;
        }
    }
}

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
        public Solution Solve(State state)
        {
            Solution res = new Solution(state);
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            foreach (var car in res.Cars)
            {
                while (!car.ServiceEnded)
                {
                    var orderedRides = remainingRides.OrderByDescending(r => car.AverageScoreForRide(r));
                    if (!orderedRides.Any() || car.AverageScoreForRide(orderedRides.First()) == 0d)
                    {
                        car.ServiceEnded = true;
                        break;
                    }
                    Ride toRemove = null;
                    foreach (var ride in orderedRides)
                    {
                        if (car.CanDoRide(ride).Item1)
                        {
                            car.DoRide(ride);
                            toRemove = ride;
                            break;
                        }
                    }
                    if (toRemove != null)
                    {
                        remainingRides.Remove(toRemove);
                    }
                    else
                    {
                        car.ServiceEnded = true;
                    }
                }
            }
            return res;
        }
    }
}

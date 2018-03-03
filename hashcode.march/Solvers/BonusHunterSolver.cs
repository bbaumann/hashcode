using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class BonusHunterSolver : ISolver<State, Solution>
    {
        public Solution Solve(State state)
        {
            bool allBonusTaken = false;
            Solution res = new Solution(state);
            List<Ride> remainingRides = new List<Ride>(state.Rides);
            foreach (var car in res.Cars)
            {
                while (!car.ServiceEnded)
                {
                    if (!allBonusTaken)
                    {
                        var orderedRides = remainingRides.OrderBy(r => car.WaitTimeToRideStart(r));
                        if (!orderedRides.Any())
                        {
                            car.ServiceEnded = true;
                            break;
                        }
                        Ride toRemove = null;
                        foreach (var ride in orderedRides)
                        {
                            if (car.CanDoRide(ride).Item2)
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
                            if (car.RideHistory.Count == 0)
                            {
                                allBonusTaken = true;
                            }
                            else
                            {
                                car.ServiceEnded = true;
                            }
                        }
                    }
                    if (allBonusTaken)
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
            }
            return res;
        }
    }
}

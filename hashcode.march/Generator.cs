using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;
using System.Linq;

namespace hashcode.march
{
    interface IGenerator
    {
        bool CalcOrders(int step, State state, List<Car> cars);

        bool CalcOrders(State state, List<Car> cars);
    }

    class MostPointGenerator : IGenerator
    {
        public bool CalcOrders(int step, State state, List<Car> cars)
        {
           
            return true;
        }

        public bool CalcOrders(State state, List<Car> cars)
        {
            foreach (var car in cars)
            {
                while (!car.ServiceEnded)
                {
                    var orderedRides = state.Rides.OrderByDescending(r => car.AverageScoreForRide(r));
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
                        state.Rides.Remove(toRemove);
                    }
                    else
                    {
                        car.ServiceEnded = true;
                    }
                }
            }
            return true;
        }
    }


    class MinWaitTimeGenerator : IGenerator
    {
        public bool CalcOrders(int step, State state, List<Car> cars)
        {
            return true;
        }

        public bool CalcOrders(State state, List<Car> cars)
        {
            foreach (var car in cars)
            {
                while (!car.ServiceEnded)
                {
                    var orderedRides = state.Rides.OrderBy(r => car.WaitTimeToRideStart(r));
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
                        state.Rides.Remove(toRemove);
                    }
                    else
                    {
                        car.ServiceEnded = true;
                    }
                }
            }
            return true;
        }
    }

    class StartOnTimeGenerator : IGenerator
    {
        public bool CalcOrders(int step, State state, List<Car> cars)
        {
            return true;
        }

        public bool CalcOrders(State state, List<Car> cars)
        {
            foreach (var car in cars)
            {
                while (!car.ServiceEnded)
                {
                    var orderedRides = state.Rides.OrderBy(r => car.WaitTimeToRideStart(r));
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
                        state.Rides.Remove(toRemove);
                    }
                    else
                    {
                        car.ServiceEnded = true;
                    }
                }
            }
            return true;
        }
    }
}

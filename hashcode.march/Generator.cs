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

    class Generator : IGenerator
    {
        public bool CalcOrders(int step, State state, List<Car> cars)
        {
            List<Models.Ride> toRemove = new List<Models.Ride>();

            foreach (var ride in state.rides)
            {
                if (!ride.IsOk())
                {
                    continue;
                }
                foreach (var car in cars)
                {
                    if (car.IsAvailable(step) && car.CanDoRide(ride).Item1)
                    {
                        car.DoRide(ride);
                        toRemove.Add(ride);
                        break;
                    }
                }
            }
            foreach (var ride in toRemove)
            {
                state.rides.Remove(ride);
            }
            return true;
        }

        public bool CalcOrders(State state, List<Car> cars)
        {
            throw new NotImplementedException();
        }
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
                    var orderedRides = state.rides.OrderByDescending(r => car.AverageScoreForRide(r));
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
                        state.rides.Remove(toRemove);
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

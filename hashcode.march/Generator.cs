using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march
{
    interface IGenerator
    {
        bool CalcOrders(int step, State state, Models.Car[] car);
    }

    class Generator : IGenerator
    {
        public bool CalcOrders(int step, State state, Models.Car[] cars)
        {
            List<Models.Ride> toRemove = new List<Models.Ride>();

            foreach (var ride in state.rides)
            {
                if (!ride.IsOk())
                {
                    continue;
                }
                for (int carIndex = 0; carIndex < state.fleetCount; ++carIndex)
                {
                    if (cars[carIndex].IsAvailable(step))
                    {
                        cars[carIndex].DoRide(ride);
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
    }
}

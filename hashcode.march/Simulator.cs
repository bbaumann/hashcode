using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march
{
    class Simulator
    {
        // return the score
        int Simulate(State state, Generator generator)
        {
            Models.Car[] cars = new Models.Car[state.fleetCount];
 
            for (int step = 0; step < state.stepCount; ++step)
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
            }

            for (int carIndex = 0; carIndex < state.fleetCount; ++carIndex)
            {
                cars[carIndex].DumpRides();
            }

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;
using System.Linq;

namespace hashcode.march.Solvers
{
    public class BonusHunterCarLimitedRideChooser : IRideChooser
    {
        private IRideChooser fallback;
        private List<Car> earliestStartMissed = new List<Car>();

        private int maxWaitTime = 10;

        public BonusHunterCarLimitedRideChooser(IRideChooser fallback, int maxWaitTime)
        {
            this.fallback = fallback;
            this.maxWaitTime = maxWaitTime;
        }

        public bool ChooseRide(IList<Car> cars, IList<Ride> remainingRides)
        {
            Ride toRemove = null;
            foreach (var car in cars)
            {
                if (!earliestStartMissed.Contains(car))
                {
                    var orderedRides = remainingRides.OrderBy(r => car.WaitTimeToRideStart(r) + r.Distance);
                    var earliestRide = orderedRides.FirstOrDefault(r => car.CanDoRide(r).Item1);
                    if (earliestRide != null && car.WaitTimeToRideStart(earliestRide) > maxWaitTime)
                    {
                        earliestRide = null;
                    }
                    foreach (var ride in orderedRides)
                    {
                        if (car.WaitTimeToRideStart(ride) > maxWaitTime && earliestRide != null)
                        {
                            car.DoRide(earliestRide);
                            toRemove = earliestRide;
                            break;
                        }
                        if (car.CanDoRide(ride).Item2)
                        {
                            car.DoRide(ride);
                            toRemove = ride;
                            break;
                        }
                    }
                    if (toRemove != null)
                    {
                        break;
                    }
                    else
                    {
                        earliestStartMissed.Add(car);
                    }
                }
            }
            if (toRemove != null)
            {
                remainingRides.Remove(toRemove);
                return true;
            }
            //Aucun trajet ne peut récupérer le bonus, on utilise un autre solver
            return fallback.ChooseRide(cars.Reverse().ToList(), remainingRides);
        }

        public void Init()
        {
            earliestStartMissed = new List<Car>();
        }
    }
}

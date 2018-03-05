using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;
using System.Linq;

namespace hashcode.march.Solvers
{
    public class BonusHunterRideChooser : IRideChooser
    {
        private IRideChooser fallback;
        private List<Ride> earliestStartMissed = new List<Ride>();

        public BonusHunterRideChooser(IRideChooser fallback)
        {
            this.fallback = fallback;
        }

        public bool ChooseRide(IList<Car> cars, IList<Ride> remainingRides)
        {
            Ride toRemove = null;
            foreach (var ride in remainingRides)
            {
                if (!earliestStartMissed.Contains(ride))
                {
                    var orderedCars = cars.OrderBy(c => c.WaitTimeToRideStart(ride));
                    foreach (var car in orderedCars)
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
                        break;
                    }
                    else
                    {
                        earliestStartMissed.Add(ride);
                    }
                }
            }
            if (toRemove != null)
            {
                remainingRides.Remove(toRemove);
                return true;
            }
            //Aucun trajet ne peut récupérer le bonus, on utilise un autre solver
            return fallback.ChooseRide(cars, remainingRides);
        }

        public void Init()
        {
            earliestStartMissed = new List<Ride>();
        }
    }
}

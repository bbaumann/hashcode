using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using hashcode.march.Models;

namespace hashcode.march.Solvers
{
    public class DumbRideChooser : IRideChooser
    {

        public bool ChooseRide(IList<Car> cars, IList<Ride> remainingRides)
        {
            var car = cars.First(c => !c.ServiceEnded);
            Ride toRemove = null;
            foreach (var ride in remainingRides)
            {
                if (!ride.IsOk())
                {
                    continue;
                }
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
                return true;
            }
            car.ServiceEnded = true;
            return false;
        }

        public void Init()
        {
        }
    }
}

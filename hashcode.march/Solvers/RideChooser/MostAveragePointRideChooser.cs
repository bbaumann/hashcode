using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;
using System.Linq;

namespace hashcode.march.Solvers
{
    public class MostAveragePointRideChooser : IRideChooser
    {
        public bool ChooseRide(IList<Car> cars, IList<Ride> remainingRides)
        {
            var car = cars.First(c => !c.ServiceEnded);
            var orderedRides = remainingRides.OrderByDescending(r => car.AverageScoreForRide(r));
            if (!orderedRides.Any() || car.AverageScoreForRide(orderedRides.First()) == 0d)
            {
                car.ServiceEnded = true;
                return false;
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

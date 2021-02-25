using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hashcode._2021.Models;

namespace hashcode._2021.Solvers
{
    public class IntersectionIncomingCarsSolver : BaseSolver
    {
        Dictionary<Intersection, Dictionary<Street, int>> IncomingCarsCountPerStreet = new Dictionary<Intersection, Dictionary<Street, int>>();

        public IntersectionIncomingCarsSolver() : base(true)
        {
        }

        protected override void DoSolve(Solution res)
        {
            foreach (Car car in State.Cars)
            {
                foreach (Street street in car.Steps)
                {
                    if (!IncomingCarsCountPerStreet.ContainsKey(street.Destination))
                    {
                        IncomingCarsCountPerStreet.Add(street.Destination, new Dictionary<Street, int>());
                    }
                    Dictionary<Street, int> incomingCarsCount = IncomingCarsCountPerStreet[street.Destination];
                    if (!incomingCarsCount.ContainsKey(street))
                    {
                        incomingCarsCount.Add(street, 1);
                    }
                    else
                    {
                        incomingCarsCount[street] = incomingCarsCount[street] + 1;
                    }
                }
            }

            // Define the schedule
            foreach (Intersection intersection in IncomingCarsCountPerStreet.Keys)
            {
                Dictionary<Street, int> incomingCarsCount = IncomingCarsCountPerStreet[intersection];

                res.Schedules.Add(new Schedule
                {
                    Intersection = intersection,
                    GreenDurationByStreetName = incomingCarsCount.Keys.Select(street => new Tuple<string, int>(street.Name, incomingCarsCount[street])).ToList()
                });
            }
        }
    }
}

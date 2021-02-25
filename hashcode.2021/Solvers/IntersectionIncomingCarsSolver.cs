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
        Dictionary<Intersection, Dictionary<Street, Dictionary<int,int>>> IncomingCarsPassTimeIfAllGreen = new Dictionary<Intersection, Dictionary<Street, Dictionary<int, int>>>();
        Dictionary<Street, int> AverageModulo = new Dictionary<Street, int>();

        public IntersectionIncomingCarsSolver() : base(true)
        {
        }

        protected override void DoSolve(Solution res)
        {
            foreach (Car car in State.Cars)
            {
                if (car.StepsTravelTime<=State.SimulationDuration)
                {
                    long duration = 0-car.Steps[0].TravelTime;
                    foreach (Street street in car.Steps)
                    {
                        duration += street.TravelTime;
                        if (!IncomingCarsCountPerStreet.ContainsKey(street.Destination))
                        {
                            IncomingCarsCountPerStreet.Add(street.Destination, new Dictionary<Street, int>());
                            IncomingCarsPassTimeIfAllGreen.Add(street.Destination, new Dictionary<Street, Dictionary<int, int>>());
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

                        Dictionary<Street, Dictionary<int, int>> IncomingCarsPassTime = IncomingCarsPassTimeIfAllGreen[street.Destination];
                        if (!IncomingCarsPassTime.ContainsKey(street))
                        {
                            IncomingCarsPassTime.Add(street, new Dictionary<int, int>());
                        }

                        int durationModulo = (int)(duration % street.Destination.IncomingStreetNames.Count);
                        if (!IncomingCarsPassTime[street].ContainsKey(durationModulo))
                        {
                            IncomingCarsPassTime[street].Add(durationModulo, 1);
                        } else
                        {
                            IncomingCarsPassTime[street].Add(durationModulo, IncomingCarsPassTime[street][durationModulo] +1);
                        }
                    }
                }
            }
            

            // Define the schedule
            foreach (Intersection intersection in IncomingCarsCountPerStreet.Keys)
            {
                Dictionary<Street, int> incomingCarsCount = IncomingCarsCountPerStreet[intersection];

                int totalCarsPassingThrough = incomingCarsCount.Values.Sum();
                double average = totalCarsPassingThrough * 1.0/ incomingCarsCount.Count;
                double stdDev = incomingCarsCount.Values.Select(v => (average - v) * (average - v)).Sum() / incomingCarsCount.Count;

                if (incomingCarsCount.Count > 10 || stdDev<2)
                {
                    // We have to rotate fast to avoid long rotations
                    res.Schedules.Add(new Schedule
                    {
                        Intersection = intersection,
                        GreenDurationByStreetName = incomingCarsCount.Keys.Select(street => new Tuple<string, int>(street.Name, 1)).ToList()
                    });
                } else if (totalCarsPassingThrough>3* incomingCarsCount.Count)
                {
                    // We have to lower the numbers that are dispatched in order to avoid too long rotations while still preserving a 1 second minimum and try to still have a notion of proportion
                    int averageTarget = Math.Min(totalCarsPassingThrough / 5, Math.Min(incomingCarsCount.Count,4));
                    res.Schedules.Add(new Schedule
                    {
                        Intersection = intersection,
                        GreenDurationByStreetName = incomingCarsCount.Keys.Select(street => new Tuple<string, int>(street.Name,
                        Math.Max(1, averageTarget*incomingCarsCount[street]* incomingCarsCount.Count/ totalCarsPassingThrough)
                        )).ToList()
                    });
                } else
                {
                    res.Schedules.Add(new Schedule
                    {
                        Intersection = intersection,
                        GreenDurationByStreetName = incomingCarsCount.Keys.Select(street => new Tuple<string, int>(street.Name, incomingCarsCount[street])).ToList()
                    });
                }
            }
        }
    }
}

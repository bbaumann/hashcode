using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hashcode._2021.Models;

namespace hashcode._2021.Solvers
{
    public class PrivilegeShortestSolver : BaseSolver
    {
        public double Threshold = 0.5;

        public PrivilegeShortestSolver(bool isDeterministic) : base(isDeterministic)
        {
        }

        protected override void DoSolve(Solution res)
        {
            var sortedCarsByStepsLength = State.Cars.OrderBy(car => car.Steps.Count).ToList();

            var carsToOptimize = sortedCarsByStepsLength.Take((int) (sortedCarsByStepsLength.Count * Threshold)).ToList();

            var stepsToOptimize = carsToOptimize.SelectMany(car => car.Steps).ToList();

            var countByStreet = stepsToOptimize.GroupBy(street => street).ToDictionary(group => group.Key, group => new Tuple<Street, int>(group.Key, group.Count()));
            
            res.Schedules = countByStreet.Values.GroupBy(tuple => tuple.Item1.Destination)
                .Select(group => new Schedule
                {
                    Intersection = group.Key,
                    GreenDurationByStreetName = group.Select(tuple => new Tuple<string, int>(tuple.Item1.Name, tuple.Item2)).ToList()
                })
                .ToList();
        }
    }
}
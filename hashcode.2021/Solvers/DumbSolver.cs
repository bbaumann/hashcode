using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hashcode._2021.Models;

namespace hashcode._2021.Solvers
{
    public class DumbSolver : BaseSolver
    {
        public DumbSolver(bool isDeterministic) : base(isDeterministic)
        {
        }

        protected override void DoSolve(Solution res)
        {
            res.Schedules = State.Streets.GroupBy(street => street.Destination)
                .Select(group => new Schedule
                {
                    Intersection = group.Key,
                    GreenDurationByStreetName = group.Select(street => new Tuple<string, int>(street.Name, 1)).ToList()
                })
                .ToList();
        }
    }
}

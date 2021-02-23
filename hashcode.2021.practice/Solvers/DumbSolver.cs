using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hashcode._2021.practice.Models;

namespace hashcode._2021.practice.Solvers
{
    public class DumbSolver : BaseSolver
    {
        public DumbSolver(bool isDeterministic) : base(isDeterministic)
        {
        }

        protected override void DoSolve(Solution res)
        {
            res.Deliveries.AddRange(CreateDeliveriesForTeamOfSize(2));
            res.Deliveries.AddRange(CreateDeliveriesForTeamOfSize(3));
            res.Deliveries.AddRange(CreateDeliveriesForTeamOfSize(4));
        }

        private List<Delivery> CreateDeliveriesForTeamOfSize(int size)
        {
            var deliveries = new List<Delivery>();
            for (var i = 0; i < State.teamsCount[size]; ++i)
            {
                var pizzasToDeliver = State.pizzas.Take(size).ToList();
                if (pizzasToDeliver.Count == size)
                {
                    deliveries.Add(new Delivery
                    {
                        Pizzas = pizzasToDeliver
                    });
                }
                else
                {
                    return deliveries;
                }
            }

            return deliveries;
        }
    }
}

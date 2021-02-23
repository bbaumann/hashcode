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
            res.Deliveries.AddRange(CreateDeliveriesForTeamOfSize(2, 0, out var end));
            res.Deliveries.AddRange(CreateDeliveriesForTeamOfSize(3, end, out end));
            res.Deliveries.AddRange(CreateDeliveriesForTeamOfSize(4, end, out end));
        }

        private List<Delivery> CreateDeliveriesForTeamOfSize(int size, int start, out int end)
        {
            var deliveries = new List<Delivery>();
            int i;
            for (i = 0; i < State.teamsCount[size]; i += size)
            {
                var pizzasToDeliver = State.pizzas.Skip(start + i).Take(size).ToList();
                if (pizzasToDeliver.Count == size)
                {
                    deliveries.Add(new Delivery
                    {
                        Pizzas = pizzasToDeliver
                    });
                }
                else
                {
                    end = start + i;
                    return deliveries;
                }
            }

            end = start + i + size;
            return deliveries;
        }
    }
}

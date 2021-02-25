
using System;
using System.Linq;
using System.Collections.Generic;

namespace hashcode._2021.Models
{
    /// <summary>
    /// Model the problem. Contains only the input, nothing about the solution.
    /// </summary>
    public class State
    {
        public List<Street> Streets { get; }

        public List<Car> Cars { get; }

        public int BonusPoint { get; set; }

        public int SimulationDuration { get; set; }

        public State()
        {
            Streets = new List<Street>();
            Cars = new List<Car>();
        }

        public void AddStreet(Street s) => Streets.Add(s);

        public void AddCar(Car car) => Cars.Add(car);

        public long GetScore()
        {
            for (int time = 0; time < SimulationDuration; time++)
            {
                foreach (var street in Streets)
                {
                    if (street.IsGreen(time))
                    {
                        var hasMoved = street.MoveCar(time);
                        int i = 3;
                    }
                }
            }

            return Cars.Sum(c => c.GetScore(BonusPoint,SimulationDuration));
        }

        internal void ClearSchedules()
        {
            foreach (var street in Streets)
            {
                street.Destination.Schedule = new Schedule();
                street.Source.Schedule = new Schedule();
            }
        }
    }
}

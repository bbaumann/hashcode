
using System;
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

        public State()
        {
            Streets = new List<Street>();
            Cars = new List<Car>();
        }

        public void AddStreet(Street s) => Streets.Add(s);

        public void AddCar(Car car) => Cars.Add(car);
    }
}

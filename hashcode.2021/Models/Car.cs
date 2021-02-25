using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace hashcode._2021.Models
{
    public class Car
    {
        //note immutable
        public List<Street> Steps { get; }

        public long StepsTravelTime { get; private set; }

        public Car()
        {
            Steps = new List<Street>();
        }

        public void AddStep(Street s)
        {
            Steps.Add(s);
            StepsTravelTime += s.TravelTime;
        }
    }
}

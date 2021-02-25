using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2021.Models
{
    public class Street
    {
        public string Name { get; set; }

        public long TravelTime { get; set; }

        //TODO check if needed here or in the edge to avoid circular references
        public Intersection Source { get; set; }

        public Intersection Destination { get; set; }

        public TrafficLight TrafficLight { get; }

        public Queue<Car> Cars { get; }

        public Street()
        {
            Cars = new Queue<Car>();
            TrafficLight = new TrafficLight();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2021.Models
{
    public enum TrafficLightState { Red, Green };
    public class TrafficLight
    {
        public TrafficLightState State { get; set; }

        public TrafficLight()
        {
            State = TrafficLightState.Red;
        }
    }
}

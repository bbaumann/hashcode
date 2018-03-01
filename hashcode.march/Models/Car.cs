using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march.Models
{
    public class Car
    {
        public Coord CurrentCoord { get; set; }

        public int CurrentStep { get; set; }

        public List<Ride> RideHistory { get; private set; }

        public Car()
        {
            this.RideHistory = new List<Ride>();
        }

        public int DoRide(Ride r)
        {
            return 0;
        }
    }
}

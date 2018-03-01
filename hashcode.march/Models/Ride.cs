using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march.Models
{
    public class Ride
    {
        public Coord StartingPoint { get; set; }

        public Coord FinishPoint { get; set; }

        public int EarliestStart { get; set; }

        public int LatestFinish { get; set; }


    }
}

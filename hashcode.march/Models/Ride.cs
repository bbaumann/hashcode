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

        public Ride(Coord start, Coord finish, int earliestStart, int latestFinish)
        {
            this.StartingPoint = start;
            this.FinishPoint = finish;
            this.EarliestStart = earliestStart;
            this.LatestFinish = latestFinish;
        }

        public int GetPointsAwarded(int startStep, int finishStep)
        {
            int res = 0;
            if (finishStep <= this.LatestFinish)
            {
                res += 
            }
        }


    }
}

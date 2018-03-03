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

        public int Id { get; set; }

        public int Distance
        {
            get
            {
                return StartingPoint.ComputeDistance(FinishPoint);
            }
        }

        private int startOnTimeBonus = 0;
        private int maxStep = 0;

        public Ride(int startOnTimeBonus, int maxStep)
        {
            this.startOnTimeBonus = startOnTimeBonus;
            this.maxStep = maxStep;
        }

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
            if (finishStep <= Math.Min(this.LatestFinish, maxStep))
            {
                res += Distance;
                if (startStep == EarliestStart)
                {
                    res += startOnTimeBonus;
                }
            }
            return res;
        }


        public bool IsOk()
        {
            return EarliestStart + Distance < Math.Min(LatestFinish, maxStep);
        }
    }
}

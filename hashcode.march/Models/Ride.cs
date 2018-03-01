﻿using System;
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

        public Ride()
        {

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
            if (finishStep < Math.Min(this.LatestFinish, Settings.MaxStep))
            {
                res += Distance;
                if (startStep == EarliestStart)
                {
                    res += Settings.BonusPointForStartingOnTime;
                }
            }
            return res;
        }

        public double GetPointsAwardedAverage(int startStep, int finishStep)
        {
            double res = 0;
            if (finishStep < Math.Min(this.LatestFinish, Settings.MaxStep))
            {
                res += Distance;
                if (startStep == EarliestStart)
                {
                    res += Settings.BonusPointForStartingOnTime;
                }
                res = (double)res / (double)(finishStep - startStep);
            }
            return res;
        }



        public bool IsOk()
        {
            return EarliestStart + Distance < Math.Min(LatestFinish, Settings.MaxStep);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            this.CurrentCoord = new Coord(0, 0);
            this.ServiceEnded = false;
        }

        public void MoveTo(Coord destination)
        {
            int distance = this.CurrentCoord.ComputeDistance(destination);
            this.CurrentStep += distance;
            this.CurrentCoord = destination;
        }

        /// <summary>
        /// returns points awarded
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int DoRide(Ride r)
        {
            this.MoveTo(r.StartingPoint);
            if (this.CurrentStep <= r.EarliestStart)
            {
                this.CurrentStep = r.EarliestStart;
            }
            int startStep = this.CurrentStep;
            this.MoveTo(r.FinishPoint);
            this.DropPassenger();
            int finishStep = this.CurrentStep;
            RideHistory.Add(r);
            return r.GetPointsAwarded(startStep, finishStep);
        }

        private void DropPassenger()
        {
            CurrentStep++;
        }

        public Tuple<bool, bool> CanDoRide(Ride r)
        {
            bool canHavebonus = false;
            bool canFinishOnTime = false;

            int distanceToStart = this.CurrentCoord.ComputeDistance(r.StartingPoint);

            canFinishOnTime = ((this.CurrentStep + distanceToStart + r.Distance) < Math.Min(r.LatestFinish,Settings.MaxStep));
            canHavebonus = canFinishOnTime && ((this.CurrentStep + distanceToStart) <= r.EarliestStart);
            
            return new Tuple<bool, bool>(canFinishOnTime, canHavebonus);
        }

        public int WaitTimeToRideStart(Ride r)
        {
            int distanceToStart = this.CurrentCoord.ComputeDistance(r.StartingPoint);
            int res = distanceToStart;
            int minStart = r.EarliestStart;
            if (this.CurrentStep + distanceToStart < r.EarliestStart)
                res += r.EarliestStart - this.CurrentStep - distanceToStart;

            return res;
        }
        
        public double AverageScoreForRide(Ride r)
        {
            int distanceToStart = this.CurrentCoord.ComputeDistance(r.StartingPoint);

            int minCarFinish = this.CurrentStep + distanceToStart + r.Distance;
            bool canFinishOnTime = (minCarFinish < Math.Min(r.LatestFinish, Settings.MaxStep));
            bool canHavebonus = canFinishOnTime && ((this.CurrentStep + distanceToStart) <= r.EarliestStart);

            double res = 0;
            int points = 0;
            if (canFinishOnTime)
            {
                points += r.Distance;
                if (canHavebonus)
                {
                    points += Settings.BonusPointForStartingOnTime;
                }
                res = ((double)points) / (double)(minCarFinish - this.CurrentStep);
            }
            return res;
        }

        public bool IsAvailable(int step)
        {
            return !this.ServiceEnded && this.CurrentStep <= step;
        }

        public bool ServiceEnded { get; set; }

        public string DumpRides()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(RideHistory.Count);
            sb.Append(" ");
            sb.Append(String.Join(' ', RideHistory.Select(r => r.Id.ToString())));
            return sb.ToString();
        }

    }
}

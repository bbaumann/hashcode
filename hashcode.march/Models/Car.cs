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
            int finishStep = this.CurrentStep;
            RideHistory.Add(r);
            return r.GetPointsAwarded(startStep, finishStep);
        }

        public Tuple<bool, bool> CanDoRide(Ride r)
        {
            bool canHavebonus = false;
            bool canFinishOnTime = false;

            int distanceToStart = this.CurrentCoord.ComputeDistance(r.StartingPoint);

            canFinishOnTime = ((this.CurrentStep + distanceToStart + r.Distance) < r.LatestFinish);
            canHavebonus = canFinishOnTime && ((this.CurrentStep + distanceToStart) <= r.EarliestStart);
            
            return new Tuple<bool, bool>(canFinishOnTime, canHavebonus);
        }

        public bool IsAvailable(int step)
        {
            return this.CurrentStep <= step;
        }
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

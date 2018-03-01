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
            if (this.CurrentStep < r.EarliestStart)
            {
                this.CurrentStep = r.EarliestStart;
            }
            int startStep = this.CurrentStep;
            this.MoveTo(r.FinishPoint);
            int finishStep = this.CurrentStep;
            RideHistory.Add(r);
            return r.GetPointsAwarded(startStep, finishStep);
        }
    }
}

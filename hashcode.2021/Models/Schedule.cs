using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2021.Models
{
    public class Schedule
    {
        public Intersection Intersection { get; set; }
        public List<Tuple<string,int>> GreenDurationByStreetName { get; set; }

        private int cycleDuration => GreenDurationByStreetName.Sum(t => t.Item2);

        public string GreenStreet(int time)
        {
            var pointInCycle = time % cycleDuration;
            int accu = 0;
            foreach (var cycleStep in GreenDurationByStreetName)
            {
                accu += cycleStep.Item2;
                if (pointInCycle < accu)
                {
                    return cycleStep.Item1;
                }
            }
            throw new Exception("Error in Schedule");
        }
    }
}

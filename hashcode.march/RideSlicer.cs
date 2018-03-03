using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;

namespace hashcode.march
{
    class RideSlicer
    {
        List<Ride> rides;
   
        public RideSlicer(State state)
        {
            RideAbsComp rideAbsComp = new RideAbsComp();
            List<Ride> rides = state.Rides;
            rides.Sort(rideAbsComp);
        }

        public List<Ride> Slice(int inMaxItem, int inMaxStep)
        {
            int i;
            for (i = 0; i < rides.Count && i < inMaxItem; ++i)
            {
                if (inMaxStep < rides[i].EarliestStart)
                {
                    break;
                }
            }
            return rides.GetRange(0, i);
        }
    }
}

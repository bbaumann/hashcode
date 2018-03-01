using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march
{

    public class RideAbsComp : IComparer<Models.Ride>
    {
        public int Compare(Models.Ride x, Models.Ride y)
        {
            return x.EarliestStart - y.EarliestStart;
        }
    }

    class RideIterator
    {
        List<Models.Ride> rides;
        int index;
        int maxItem;
        int maxStep;

        public RideIterator(State state)
        {
            RideAbsComp rideAbsComp = new RideAbsComp();
            rides = state.rides;
            rides.Sort(rideAbsComp);
            index = 0;
        }

        bool Begin(int inMaxStep, int inMaxItem)
        {
            maxItem = inMaxItem;
            maxStep = inMaxStep;
            index = 0;
            return true;
        }

        public Models.Ride Next()
        {
            if (index >= rides.Count - 1)
            {
                return null;
            }

            ++index;
            return rides[index];
        }
    }
}

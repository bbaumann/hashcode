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
            rides = state.Rides;
            rides.Sort(rideAbsComp);
            index = 0;
            maxStep = state.StepCount;
        }

        bool Begin(int inMaxStep = -1, int inMaxItem = -1)
        {
            maxItem = inMaxItem != -1 ? inMaxItem : maxItem;
            maxStep = inMaxStep != -1 ? inMaxStep : maxStep;
            index = 0;
            return true;
        }

        public Models.Ride Next()
        {
            if (index >= rides.Count - 1 ||
                maxStep > rides[index].EarliestStart ||
                maxItem > index)
            {
                return null;
            }

            ++index;
            return rides[index];
        }
    }
}

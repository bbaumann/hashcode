using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;
using System.Linq;

namespace hashcode.march.Solvers
{
    public class MixedRideChooser : IRideChooser
    {
        private Dictionary<int, IRideChooser> rideChoosers = new Dictionary<int, IRideChooser>();
        private int totalWeight;

        private Random rand = new Random();

        public MixedRideChooser(List<Tuple<IRideChooser,int>> rideChoosersWithWeight)
        {
            totalWeight = rideChoosersWithWeight.Sum(t => t.Item2);
            InitializeDictionary(rideChoosersWithWeight);
        }

        private void InitializeDictionary(List<Tuple<IRideChooser, int>> rideChoosersWithWeight)
        {
            int i = 0;
            foreach (var weightedRideChooser in rideChoosersWithWeight)
            {
                for (int j = 0; j < weightedRideChooser.Item2; j++)
                {
                    rideChoosers[i] = weightedRideChooser.Item1;
                    i++;
                }
            }
        }

        public bool ChooseRide(IList<Car> cars, IList<Ride> remainingRides)
        {
            var r = rand.Next(totalWeight);
            return rideChoosers[r].ChooseRide(cars, remainingRides);
        }

        public void Init()
        {
            foreach (var kvp in rideChoosers)
            {
                kvp.Value.Init();
            }
        }
    }
}

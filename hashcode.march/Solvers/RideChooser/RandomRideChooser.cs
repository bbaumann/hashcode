﻿using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;

namespace hashcode.march.Solvers
{

    public static class ListExtension
    {

        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
    public class RandomRideChooser : IRideChooser
    {
        public bool ChooseRide(Car car, IList<Ride> remainingRides)
        {
            Ride toRemove = null;
            remainingRides.Shuffle();
            foreach (var ride in remainingRides)
            {
                if (!ride.IsOk())
                {
                    continue;
                }
                if (car.CanDoRide(ride).Item1)
                {
                    car.DoRide(ride);
                    toRemove = ride;
                    break;
                }
            }

            if (toRemove != null)
            {
                remainingRides.Remove(toRemove);
                return true;
            }
            return false;
        }
    }
}

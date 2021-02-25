using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace hashcode._2021.Models
{
    public class Car
    {
        //note immutable
        public List<Street> Steps { get; }

        public long StepsTravelTime { get; private set; }

        public Street CurrentStreet => Steps[CurrentStreetIndex];
        public int CurrentStreetIndex;

        public int CurrentStreetStartupTime;

        public Car()
        {
            Steps = new List<Street>();
        }

        public void AddStep(Street s)
        {
            Steps.Add(s);
            StepsTravelTime += s.TravelTime;
        }

        public bool IsFinished => CurrentStreetIndex == Steps.Count - 1;

        /// <summary>
        /// returns true if car moved
        /// </summary>
        /// <returns></returns>
        public bool MoveToNextStreet(int currentTime)
        {
            if (IsFinished)
                throw new Exception("car should have been removed from list");
            if (currentTime - CurrentStreetStartupTime < CurrentStreet.TravelTime)
                return false;

            CurrentStreetIndex++;
            CurrentStreetStartupTime = currentTime;
            return true;
        }

        public void Clear()
        {
            CurrentStreetIndex = 0;
            CurrentStreetStartupTime = 0;
        }
    }
}

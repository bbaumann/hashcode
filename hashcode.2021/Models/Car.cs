using System;
using System.Linq;
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
            if (!Steps.Any())
            {
                s.Cars.Enqueue(this);
            }
            Steps.Add(s);
            StepsTravelTime += s.TravelTime;
        }

        public bool IsFinished => CurrentStreetIndex == Steps.Count; //Need to end the last step

        public int GetScore(int bonusPoint, int simulationDuration)
        {
            if (!IsFinished)
                return 0;
            return bonusPoint + simulationDuration - CurrentStreetStartupTime;
        }

        /// <summary>
        /// returns true if car moved
        /// </summary>
        /// <returns></returns>
        public bool MoveToNextStreet(int currentTime)
        {
            if (IsFinished)
                throw new Exception("car should have been removed from list");
            if (CurrentStreetIndex != 0
                &&
                currentTime - CurrentStreetStartupTime < CurrentStreet.TravelTime
                )
                return false;

            CurrentStreetIndex++;
            CurrentStreetStartupTime = currentTime;
            if (!IsFinished)
                CurrentStreet.Cars.Enqueue(this);
            return true;
        }

        public void Clear()
        {
            CurrentStreetIndex = 0;
            CurrentStreetStartupTime = 0;
        }
    }
}

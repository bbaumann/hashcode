using hashcode.march.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march
{
    public class State
    {
        public State()
        {
            Rides = new List<Ride>();
        }
        
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public int CarsCount { get; set; }
        public int RidesCount { get; set; }
        public int StartOnTimeBonus { get; set; }
        public int StepCount { get; set; }
                
        public List<Ride> Rides { get; private set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march
{
    class State
    {
        public State()
        {
            rides = new List<Models.Ride>();
        }

        public int rowCount { get; set; }
        public int colCount { get; set; }
        public int fleetCount { get; set; }
        public int ridesCount { get; set; }
        public int bonusCount { get; set; }
        public int stepCount { get; set; }

        public List<Models.Ride> rides { get; private set; }
    }
}

using hashcode.march.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march.Solvers
{
    public interface IRideChooser
    {
        bool ChooseRide(IList<Car> cars, IList<Ride> remainingRides);

        void Init();
    }
}

using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class BonusHunterCarLimitSolver : BaseSolver
    {
        public BonusHunterCarLimitSolver(int maxWaitTime) : base(new BonusHunterCarLimitedRideChooser(new MostAveragePointRideChooser(), maxWaitTime))
        {
        }
        
    }
}

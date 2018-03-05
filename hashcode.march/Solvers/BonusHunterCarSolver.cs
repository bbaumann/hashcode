using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class BonusHunterCarSolver : BaseSolver
    {
        public BonusHunterCarSolver(IRideChooser fallback) : base(new BonusHunterCarRideChooser(fallback))
        {
        }
        
    }
}

﻿using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class BonusHunterSolver : BaseSolver
    {
        public BonusHunterSolver(IRideChooser fallback) : base(new BonusHunterRideChooser(fallback))
        {
        }
        
    }
}

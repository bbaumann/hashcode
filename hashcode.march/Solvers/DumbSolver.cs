using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class DumbSolver : BaseSolver
    {
        public DumbSolver() : base(new DumbRideChooser())
        {

        }
    }

    public class RandomSolver : BaseSolver
    {
        public RandomSolver() : base(new RandomRideChooser())
        {
        }
    }
}

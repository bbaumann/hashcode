using hashcode._2020.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2020.Solvers
{
    public class MixedSolver : BaseSolver
    {
        public MixedSolver(List<Tuple<BaseSolver, int>> SolversWithWeight)
            : base(false)
            //: base(new MixedRideChooser(SolversWithWeight
            //        .Select(s => new { s.Item1.rideChooser, s.Item2 })
            //    .AsEnumerable()
            //    .Select(r => new Tuple<IRideChooser, int>(r.rideChooser,r.Item2))
            //    .ToList())
            //)
        {
            //We should mix the solvers here according to the weight
            Logger.Log("Mixed Strategy with " + String.Join(", ",SolversWithWeight.Select(s => s.Item1.GetType().Name + " x" + s.Item2)));
        }
    }
}

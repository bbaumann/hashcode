using hashcode.march.Models;
using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode.march.Solvers
{
    public class MixedSolver : BaseSolver
    {
        public MixedSolver(List<Tuple<BaseSolver, int>> SolversWithWeight) : 
            base(new MixedRideChooser(SolversWithWeight
                    .Select(s => new { s.Item1.rideChooser, s.Item2 })
                .AsEnumerable()
                .Select(r => new Tuple<IRideChooser, int>(r.rideChooser,r.Item2))
                .ToList())
            )
        {
            Logger.Log("Mixed Strategy with " + String.Join(", ",SolversWithWeight.Select(s => s.Item1.GetType().Name + " x" + s.Item2)));
        }
    }
}

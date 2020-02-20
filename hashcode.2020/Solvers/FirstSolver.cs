using hashcode._2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2020.Solvers
{
    public class FirstSolver : BaseSolver
    {
        public FirstSolver(bool isDeterministic) : base(isDeterministic)
        {
        }


        protected override void DoSolve(Solution res)
        {

            var minRelevantBookScore = 0;

            // calcul du seuil d'interet des livres
            long totalScore = 0;
            foreach (var scoreKV in StateFactory.CurrentState.ScoreByBookId)
            {
                totalScore += scoreKV.Value;
            }
            var meanScore = (int)(totalScore / StateFactory.CurrentState.ScoreByBookId.Count());
            minRelevantBookScore = meanScore;

            // idee: prise en compte des doublons

            StateFactory.CurrentState.Libraries.ForEach(x =>
            {
                var bookEfficientCount = 0;
                foreach (var book in x.Books)
                {
                    if (book.Value.Score < minRelevantBookScore)
                    {
                        break;
                    }
                    ++bookEfficientCount;
                }
                x.EfficiencyDayCount = bookEfficientCount / x.Freq;
            });

            // scoring by library
            StateFactory.CurrentState.Libraries.ForEach(x =>
            {
                // a tuner !!!!!!
                x.Priority = x.EfficiencyDayCount - 2 * x.NbDaysToSignup;
            });

            var date = 0;
            res.Libraries = StateFactory.CurrentState.Libraries.OrderBy(x => x.Priority).Select(x =>
            {
                var result = new WorkingLibrary(x, date);
                result.ShipBooks();
                date += x.NbDaysToSignup;
                return result;
            }).ToList();
        }
    }
}

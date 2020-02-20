using hashcode._2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2020.Solvers
{
    public class FirstSolver : BaseSolver
    {

        double _thresholdFactor;

        double _signupWeightFactor;

        public FirstSolver(bool isDeterministic, double thresholdFactor, double signupWeightFactor) : base(isDeterministic)
        {
            _thresholdFactor = thresholdFactor;
            _signupWeightFactor = signupWeightFactor;
        }


        protected override void DoSolve(Solution res)
        {

            var minRelevantBookScore = 0;

            // calcul du seuil d'interet des livres
            long totalScore = 0;
            int maxScore = -1;
            int minScore = -1;
            foreach (var scoreKV in State.ScoreByBookId)
            {
                totalScore += scoreKV.Value;
                if (maxScore == -1 || maxScore < scoreKV.Value)
                {
                    maxScore = scoreKV.Value;
                }
                if (minScore == -1 || minScore > scoreKV.Value)
                {
                    minScore = scoreKV.Value;
                }
            }
            var meanScore = (int)(totalScore / State.ScoreByBookId.Count());
            // a tuner !!!!
            minRelevantBookScore = (int)(((double)meanScore) * _thresholdFactor); // thresholdFactor avec maxScore et minScore

            // idee: prise en compte des doublons

            State.Libraries.ForEach(x =>
            {
                var bookEfficientCount = 0;
                foreach (var book in x.Books)
                {
                    if (book.Score < minRelevantBookScore)
                    {
                        break;
                    }
                    ++bookEfficientCount;
                }
                x.EfficiencyDayCount = bookEfficientCount / x.Freq;
            });

            // scoring by library
            State.Libraries.ForEach(x =>
            {
                // a tuner !!!!!!
                x.Priority = x.EfficiencyDayCount - _signupWeightFactor * x.NbDaysToSignup;
                // prendre en compte ce qu'il reste dans le temps imparti
                // dans la limite de la moitie du delai
            });

            var date = 0;
            var bookAlreadyUsed = new Dictionary<int, bool>();
            res.Libraries = State.Libraries.OrderByDescending(x => x.Priority).Select(x =>
            {
                var result = new WorkingLibrary(x, date, State, bookAlreadyUsed);
                result.ShipBooks();
                date += x.NbDaysToSignup;
                return result;
            }).ToList();
        }
    }
}

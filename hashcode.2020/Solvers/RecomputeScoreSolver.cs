using hashcode._2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2020.Solvers
{
    public class RecomputeScoreSolver : BaseSolver
    {

        double _thresholdFactor;

        double _signupWeightFactor;

        public RecomputeScoreSolver(bool isDeterministic, double thresholdFactor, double signupWeightFactor) : base(isDeterministic)
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
            minRelevantBookScore = (int)(meanScore * _thresholdFactor); // thresholdFactor avec maxScore et minScore

            var date = 0;
            var librariesToHandle = new List<Library>();
            librariesToHandle.AddRange(State.Libraries);
            // idee: prise en compte des doublons
            while (date < State.NbDays && librariesToHandle.Any())
            {
                librariesToHandle.RemoveAll(
                    l => (date + l.NbDaysToSignup >= State.NbDays)
                    );
                if (!librariesToHandle.Any())
                    break;

                librariesToHandle.ForEach(x =>
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
                    var dayLeftCount = State.NbDays - date - x.NbDaysToSignup;
                    if (x.EfficiencyDayCount > dayLeftCount)
                    {
                        x.EfficiencyDayCount = dayLeftCount;
                    }
                });
                // scoring by library
                librariesToHandle.ForEach(x =>
                {
                // a tuner !!!!!!
                x.Priority = x.EfficiencyDayCount - _signupWeightFactor * x.NbDaysToSignup;
                // prendre en compte ce qu'il reste dans le temps imparti
                // dans la limite de la moitie du delai
                });

                //pick up the first library
                var orderedLibraries = librariesToHandle.OrderByDescending(x => x.Priority);
                var wl = new WorkingLibrary(orderedLibraries.First(), date, State, null);
                wl.ShipBooks();
                date += wl.InitialLibrary.NbDaysToSignup;
                res.Libraries.Add(wl);
                librariesToHandle.Remove(orderedLibraries.First());
                //remove the books from other libraries
                foreach (var l in librariesToHandle)
                {
                    l.Books.RemoveAll(b => wl.OrderedBooksToScan.Contains(b));
                }
            }
        }
    }
}

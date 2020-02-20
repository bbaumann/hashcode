using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2020.Models
{
    public class Library
    {
        public int Id { get; set; }

        public int NbBooks { get; set; }

        public int NbDaysToSignup { get; set; }

        public int Freq { get; set; }
        public List<Book> Books { get; set; }

        // intermediaires de scoring
        public int EfficiencyDayCount { get; set; }

        public long EfficiencyScoreTotal { get; set; }

        public double Priority { get; set; }
    }
}

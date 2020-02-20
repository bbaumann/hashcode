using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2020.Models
{
    public class Library
    {
        public int NbBooks { get; set; }

        public int NbDaysToSignup { get; set; }

        public int Freq { get; set; }

        public List<Book> Books { get; set; }
    }
}

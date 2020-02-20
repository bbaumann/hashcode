using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2020.Models
{
    public class WorkingLibrary
    {
        public Library InitialLibrary { get; }

        public int SignupDate { get; }

        public int Id => InitialLibrary.Id;

        public int NbBooksToScan => OrderedBooksToScan.Count;

        //without duplicates
        public List<Book> OrderedBooksToScan { get; set; }

        public WorkingLibrary(Library initialLibrary)
        {
            InitialLibrary = initialLibrary;
        }

        public bool CanSignUp(int signUpDate)
        {
            int dateOfFirstBookShipping = signUpDate + InitialLibrary.NbDaysToSignup;
            return dateOfFirstBookShipping <= StateFactory.CurrentState.NbDays;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2020.Models
{
    public class WorkingLibrary
    {
        public Library InitialLibrary { get; }

        public int SignupDate { get; }

        public int Id => InitialLibrary.Id;

        public int NbBooksToScan => OrderedBooksToScan.Count;

        private int _currentBookIndex = 0;

        //without duplicates
        public List<Book> OrderedBooksToScan { get; private set; }

        public WorkingLibrary(Library initialLibrary, int signupDate)
        {
            InitialLibrary = initialLibrary;
            SignupDate = signupDate;
            OrderedBooksToScan = new List<Book>();
        }

        public bool CanSignUp(int signUpDate)
        {
            int dateOfFirstBookShipping = signUpDate + InitialLibrary.NbDaysToSignup;
            return dateOfFirstBookShipping <= StateFactory.CurrentState.NbDays;
        }

        private void ShipBooksForOneDay()
        {
            var newBooks = this.InitialLibrary.Books.Skip(_currentBookIndex)?.Take(InitialLibrary.Freq)?.Select(b => b.Value)?.ToList();
            if (newBooks != null)
            {
                OrderedBooksToScan.AddRange(newBooks);
                _currentBookIndex += newBooks.Count;
            }
        }

        public void ShipBooks()
        {
            //TODO improve perf
            int nbDaysToShip = StateFactory.CurrentState.NbDays - SignupDate + InitialLibrary.NbDaysToSignup + 1;
            for (int i = 0; i < nbDaysToShip; i++)
            {
                ShipBooksForOneDay();
            }
        }
    }
}

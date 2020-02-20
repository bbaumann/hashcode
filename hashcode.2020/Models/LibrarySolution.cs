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

        private State _state;

        public WorkingLibrary(Library initialLibrary, int signupDate, State state)
        {
            InitialLibrary = initialLibrary;
            SignupDate = signupDate;
            OrderedBooksToScan = new List<Book>();
            _state = state;
        }

        public bool CanSignUp(int signUpDate)
        {
            int dateOfFirstBookShipping = signUpDate + InitialLibrary.NbDaysToSignup;
            return dateOfFirstBookShipping <= _state.NbDays;
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
            int nbDaysToShip = _state.NbDays - SignupDate + InitialLibrary.NbDaysToSignup + 1;
            for (int i = 0; i < nbDaysToShip; i++)
            {
                ShipBooksForOneDay();
            }
        }
    }
}

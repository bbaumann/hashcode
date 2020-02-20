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

        private Dictionary<int, bool> _bookAlreadyUsed;



        public WorkingLibrary(Library initialLibrary, int signupDate, State state,
            Dictionary<int, bool> bookAlreadyUsed)
        {
            InitialLibrary = initialLibrary;
            SignupDate = signupDate;
            OrderedBooksToScan = new List<Book>();
            _state = state;
            _bookAlreadyUsed = bookAlreadyUsed;
        }

        public bool CanSignUp(int signUpDate)
        {
            int dateOfFirstBookShipping = signUpDate + InitialLibrary.NbDaysToSignup;
            return dateOfFirstBookShipping <= _state.NbDays;
        }

        private void ShipBooksForOneDay()
        {
            int toTake = InitialLibrary.Freq;
            var newBooks = new List<Book>();
            for (; _currentBookIndex < InitialLibrary.Books.Count; _currentBookIndex++)
            {
                var currentBook = InitialLibrary.Books[_currentBookIndex];
                if (_bookAlreadyUsed != null && _bookAlreadyUsed.ContainsKey(currentBook.Id))
                    continue;
                newBooks.Add(currentBook);
                toTake--;
                if (toTake <= 0)
                    break;
            }
            _currentBookIndex++;
            if (newBooks != null && newBooks.Any())
            {
                OrderedBooksToScan.AddRange(newBooks);
            }
        }

        public void ShipBooks()
        {
            //TODO improve perf
            int nbDaysToShip = _state.NbDays - SignupDate - InitialLibrary.NbDaysToSignup;
            for (int i = 0; i < nbDaysToShip; i++)
            {
                ShipBooksForOneDay();
            }

            if (_bookAlreadyUsed != null)
            {
                foreach (var bookToShip in OrderedBooksToScan)
                {
                    _bookAlreadyUsed[bookToShip.Id] = true;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2020.Models
{
    public class WorkingLibrary
    {
        public int Id { get; set; }

        public int NbBooksToScan { get; set; }

        //without duplicates
        public List<Book> OrderedBooksToScan { get; set; }
    }
}

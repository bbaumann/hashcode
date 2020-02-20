using System;

namespace hashcode._2020.Models
{
    public class Book : IComparable<Book>
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int CompareTo(Book other)
        {
            return -Score.CompareTo(other.Score);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Book)obj).Id);
        }
    }
}
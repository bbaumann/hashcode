using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2021.Models
{
    public class Intersection
    {
        public int Id { get; set; }
        public List<string> IncomingStreetNames { get; set; }
        public List<string> OutgoingStreetNames { get; set; }

        public Schedule Schedule { get; set; }

        public Intersection()
        {
            IncomingStreetNames = new List<string>();
            OutgoingStreetNames = new List<string>();
        }

        internal void AddOutgoingStreet(Street street) => OutgoingStreetNames.Add(street.Name);

        internal void AddIncomingStreet(Street street) => IncomingStreetNames.Add(street.Name);
    }
}

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


    }
}

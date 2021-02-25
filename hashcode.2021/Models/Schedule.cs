using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2021.Models
{
    public class Schedule
    {
        public Intersection Intersection { get; set; }
        public List<Tuple<string,int>> GreenDurationByStreetName { get; set; }
    }
}

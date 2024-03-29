﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace hashcode.march.Models
{
    public class Coord
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int ComputeDistance(Coord other)
        {
            return Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y);
        }
    }
}

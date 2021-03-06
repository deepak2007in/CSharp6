﻿namespace CSharp6
{
    using static System.Math;

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Sqrt(X * X + Y * Y);
    }
}
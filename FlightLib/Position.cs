using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Position
    {
        double x;
        double y;

        // Makes a position from the x and y coordinates.
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Returns the X coordinate.
        public double GetX()
        {
            return x;
        }

        // Returns the Y coordinate.
        public double GetY()
        {
            return y;
        }

        // Returns the straight-line distance from this position to b.
        public double DistanceTo(Position b)
        {
            double result = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return result;
        }
    }
}

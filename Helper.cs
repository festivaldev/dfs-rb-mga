using System;
using System.Drawing;

namespace DFSRBMGA
{
    public static class Helper
    {
        public static Point AdjustPoint(Point point, int multiplier, int x = 0, int y = 0) {
            return new Point(point.X * multiplier + x, point.Y * multiplier + y);
        }

        public static bool IsNeighbouringPoint(Point center, Point proband) {
            return Math.Abs(center.X - proband.X) <= 1 && Math.Abs(center.Y - proband.Y) <= 1 && ((center.X == proband.X) ^ (center.Y == proband.Y));
        }
    }
}

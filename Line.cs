using System.Drawing;

namespace DFSRBMGA
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line() { }

        public Line(Point start, Point end) {
            Start = start;
            End = end;
        }

        public Line(int startX, int startY, int endX, int endY) {
            Start = new Point(startX, startY);
            End = new Point(endX, endY);
        }
    }
}

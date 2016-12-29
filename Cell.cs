using System;
using System.Drawing;

namespace DFSRBMGA
{
    public class Cell
    {
        public Point Location { get; set; }
        public Borders Borders { get; set; } = Borders.All;
        public bool Mazed { get; set; } = false;

        private int Size;

        public Cell(int column, int row, int size) {
            Location = new Point(column, row);
            Size = size;
        }

        public Line GetBorder(Borders border) {
            switch (border) {
            case Borders.Top:
                return new Line(Helper.AdjustPoint(Location, Size), Helper.AdjustPoint(Location, Size, Size, 0));
            case Borders.Left:
                return new Line(Helper.AdjustPoint(Location, Size), Helper.AdjustPoint(Location, Size, 0, Size));
            case Borders.Bottom:
                return new Line(Helper.AdjustPoint(Location, Size, 0, Size), Helper.AdjustPoint(Location, Size, Size, Size));
            case Borders.Right:
                return new Line(Helper.AdjustPoint(Location, Size, Size, 0), Helper.AdjustPoint(Location, Size, Size, Size));
            }
            return null;
        }
    }

    [Flags]
    public enum Borders
    {
        None = 0,
        Top = 1,
        Left = 2,
        Bottom = 4,
        Right = 8,
        All = Top | Left | Bottom | Right
    }
}

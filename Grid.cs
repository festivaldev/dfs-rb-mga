using System;
using System.Collections.Generic;
using System.Linq;

namespace DFSRBMGA
{

    /* depth-first search recursive backtracker maze generation algorithm */

    public class Grid
    {
        public int CellSize { get; set; }
        public int GridSize { get; set; }
        public List<Cell> Cells { get; set; } = new List<Cell>();
        public Cell ActiveCell { get; set; }

        private Stack<Cell> MazedCells = new Stack<Cell>();
        private Random Random;
        private Cell NextCell;

        public Grid(int cellSize, int gridSize) {
            Random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
            CellSize = cellSize;
            GridSize = gridSize;
            var RowColumnCount = GridSize / CellSize;
            for (var i = 0; i < RowColumnCount; i++) {
                for (var j = 0; j < RowColumnCount; j++) {
                    Cells.Add(new Cell(i, j, cellSize));
                }
            }
            ActiveCell = Cells[0];
        }

        public bool Update() {
            if (!Cells.All(c => c.Mazed)) {
                ActiveCell.Mazed = true;
                try {
                    NextCell = GetRandomNeighbour(ActiveCell);
                    MazedCells.Push(ActiveCell);
                    RemoveBorders(ActiveCell, NextCell);
                } catch {
                    NextCell = MazedCells.Pop();
                }
                ActiveCell = NextCell;
                return true;
            }
            if (MazedCells.Count > 0) {
                NextCell = MazedCells.Pop();
                ActiveCell = NextCell;
                return true;
            }
            return false;
        }

        private Cell GetRandomNeighbour(Cell cell) {
            var k = cell.Location.X * cell.Location.Y * Random.Next(1, 11);
            for (var r = 0; r < k; r++) {
                Random.Next();
            }
            var Neighbours = Cells.FindAll(c => Helper.IsNeighbouringPoint(cell.Location, c.Location) && !c.Mazed);
            if (Neighbours.Count == 0) {
                throw new MissingFieldException();
            }
            return Neighbours[Random.Next(0, Neighbours.Count)];
        }

        private void RemoveBorders(Cell first, Cell other) {
            var Dx = other.Location.X - first.Location.X;
            var Dy = other.Location.Y - first.Location.Y;

            var FirstBorder = Borders.None;
            var OtherBorder = Borders.None;

            if (Dx == 1) {
                FirstBorder = Borders.Right;
                OtherBorder = Borders.Left;
            } else if (Dx == -1) {
                FirstBorder = Borders.Left;
                OtherBorder = Borders.Right;
            }

            if (Dy == 1) {
                FirstBorder = Borders.Bottom;
                OtherBorder = Borders.Top;
            } else if (Dy == -1) {
                FirstBorder = Borders.Top;
                OtherBorder = Borders.Bottom;
            }

            first.Borders = first.Borders & ~FirstBorder;
            other.Borders = other.Borders & ~OtherBorder;
        }
    }
}

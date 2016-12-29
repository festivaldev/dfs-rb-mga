using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DFSRBMGA
{
    public partial class MainWindow : Form
    {
        private Grid Grid;
        private Pen BorderPen = new Pen(Color.WhiteSmoke, 1F);
        private SolidBrush BackgroundBrush = new SolidBrush(ColorTranslator.FromHtml("#555"));
        private SolidBrush MazedBrush = new SolidBrush(ColorTranslator.FromHtml("#222"));

        private bool MazeCompleted;
        private Stopwatch Timer = new Stopwatch();

        public MainWindow() {
            InitializeComponent();

            Grid = new Grid(20, 400);

            KeyDown += OnFrmMainKeyDown;
            tmrFrames.Tick += OnTmrFramesTick;
            pnlGrid.Paint += OnPnlGridPaint;
        }

        private void OnFrmMainKeyDown(object sender, KeyEventArgs e) {
            if (MazeCompleted) {
                if (!Timer.IsRunning) {
                    Timer.Restart();
                }
                switch (e.KeyCode) {
                case Keys.Up:
                    if (!Grid.ActiveCell.Borders.HasFlag(Borders.Top)) {
                        Grid.ActiveCell = Grid.Cells.Find(c => c.Location == new Point(Grid.ActiveCell.Location.X, Grid.ActiveCell.Location.Y - 1));
                    }
                    break;
                case Keys.Left:
                    if (!Grid.ActiveCell.Borders.HasFlag(Borders.Left)) {
                        Grid.ActiveCell = Grid.Cells.Find(c => c.Location == new Point(Grid.ActiveCell.Location.X - 1, Grid.ActiveCell.Location.Y));
                    }
                    break;
                case Keys.Down:
                    if (!Grid.ActiveCell.Borders.HasFlag(Borders.Bottom)) {
                        Grid.ActiveCell = Grid.Cells.Find(c => c.Location == new Point(Grid.ActiveCell.Location.X, Grid.ActiveCell.Location.Y + 1));
                    }
                    break;
                case Keys.Right:
                    if (!Grid.ActiveCell.Borders.HasFlag(Borders.Right)) {
                        Grid.ActiveCell = Grid.Cells.Find(c => c.Location == new Point(Grid.ActiveCell.Location.X + 1, Grid.ActiveCell.Location.Y));
                    }
                    break;
                }
                if (Grid.ActiveCell.Location == Grid.Cells[Grid.Cells.Count - 1].Location) {
                    Timer.Stop();
                    MessageBox.Show(Timer.Elapsed.ToString());
                }
            }
        }

        private void OnTmrFramesTick(object sender, EventArgs e) {
            MazeCompleted = !Grid.Update();
            pnlGrid.Invalidate();
        }

        private void OnPnlGridPaint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(BackgroundBrush, 0, 0, 400, 400);
            foreach (var Cell in Grid.Cells) {

                if (Cell.Mazed) {
                    e.Graphics.FillRectangle(MazedBrush, new Rectangle(Cell.Location.X * Grid.CellSize, Cell.Location.Y * Grid.CellSize, Grid.CellSize, Grid.CellSize));
                } else {
                    e.Graphics.FillRectangle(BackgroundBrush, new Rectangle(Cell.Location.X * Grid.CellSize, Cell.Location.Y * Grid.CellSize, Grid.CellSize, Grid.CellSize));
                }
                if (Cell == Grid.ActiveCell) {
                    e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#1A55BE")), new Rectangle(Cell.Location.X * Grid.CellSize, Cell.Location.Y * Grid.CellSize, Grid.CellSize, Grid.CellSize));
                }
                if (Grid.Cells.IndexOf(Cell) == Grid.Cells.Count - 1) {
                    e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#FC3539")), new Rectangle(Cell.Location.X * Grid.CellSize, Cell.Location.Y * Grid.CellSize, Grid.CellSize, Grid.CellSize));
                }

                if (Cell.Borders.HasFlag(Borders.Top)) {
                    var Line = Cell.GetBorder(Borders.Top);
                    e.Graphics.DrawLine(BorderPen, Line.Start, Line.End);
                }
                if (Cell.Borders.HasFlag(Borders.Left)) {
                    var Line = Cell.GetBorder(Borders.Left);
                    e.Graphics.DrawLine(BorderPen, Line.Start, Line.End);
                }
                if (Cell.Borders.HasFlag(Borders.Bottom)) {
                    var Line = Cell.GetBorder(Borders.Bottom);
                    e.Graphics.DrawLine(BorderPen, Line.Start, Line.End);
                }
                if (Cell.Borders.HasFlag(Borders.Right)) {
                    var Line = Cell.GetBorder(Borders.Right);
                    e.Graphics.DrawLine(BorderPen, Line.Start, Line.End);
                }

            }
        }
    }
}

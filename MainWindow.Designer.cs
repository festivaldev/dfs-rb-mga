using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DFSRBMGA
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new Container();
            this.tmrFrames = new Timer(this.components);
            this.pnlGrid = new DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // tmrFrames
            // 
            this.tmrFrames.Enabled = true;
            this.tmrFrames.Interval = 1;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Location = new Point(12, 11);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new Size(400, 400);
            this.pnlGrid.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(425, 423);
            this.Controls.Add(this.pnlGrid);
            this.Font = new Font("Segoe UI", 8.25F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DFSRB Maze Generation Algorithm";
            this.ResumeLayout(false);

        }

        #endregion

        private Timer tmrFrames;
        private DoubleBufferedPanel pnlGrid;
    }
}


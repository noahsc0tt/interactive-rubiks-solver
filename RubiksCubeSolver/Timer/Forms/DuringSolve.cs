using System;
using System.Windows.Forms;
using System.Diagnostics;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Timer.Forms
{
    /// <summary>
    /// Times a Rubik's Cube solve. Stops when the user presses the spacebar.
    /// </summary>
    internal partial class DuringSolve : Form
    {
        public const string TimeFormat = "{0:mm\\:ss\\.ff}";
        private readonly Stopwatch solveTimer = new();

        public DuringSolve()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }
        
        private void DuringSolve_Load(object sender, EventArgs e) =>
            solveTimer.Start();

        private void DuringSolve_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Space)
            {
                solveTimer.Stop();
                timer.Enabled = false;
                FormNavigator.Navigate<BeforeSolve>(this, timeLabel.Text);
            }
        }

        private void Timer_Tick(object sender, EventArgs e) =>
            timeLabel.Text = string.Format(TimeFormat, solveTimer.Elapsed); 
    }
}

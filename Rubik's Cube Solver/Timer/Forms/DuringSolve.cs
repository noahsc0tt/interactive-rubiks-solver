using System;
using System.Windows.Forms;
using System.Diagnostics;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Timer.Forms
{
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

        private void DuringSolve_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Space)
            {
                solveTimer.Stop();
                FormNavigator.Navigate<BeforeSolve>(this, timeLabel.Text);
            }
        }

        private void Timer_Tick(object sender, EventArgs e) =>
            timeLabel.Text = string.Format(TimeFormat, solveTimer.Elapsed); 
    }
}

using System;
using System.Windows.Forms;
using System.Diagnostics;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Timer.Forms
{
    public partial class DuringSolve : Form
    {
        Stopwatch solveTimer = new Stopwatch();

        public DuringSolve()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }
        
        private void DuringSolve_Load(object sender, EventArgs e)
        {
            solveTimer.Start();
        }


        private void DuringSolve_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Space)
            {
                solveTimer.Stop();
                FormNavigator.Navigate<BeforeSolve>(this, lblTimer.Text);
            }
        }

        private void solveTimer_Tick(object sender, EventArgs e)
        {
            //outputting the time to the user
            lblTimer.Text = string.Format("{0:mm\\:ss\\.ff}", solveTimer.Elapsed); 
        }

    }
}

using System;
using System.Windows.Forms;
using System.Diagnostics;


namespace Rubiks_Cube_Solver
{
    public partial class During_Solve : Form
    {
        Stopwatch solveTimer = new Stopwatch();

        public During_Solve()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }
        
        private void During_Solve_Load(object sender, EventArgs e)
        {
            solveTimer.Start();
        }


        private void During_Solve_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Space)
            {
                solveTimer.Stop();
                FormNavigator.Navigate<Before_Solve>(this, lblTimer.Text);
            }
        }

        private void solveTimer_Tick(object sender, EventArgs e)
        {
            //outputting the time to the user
            lblTimer.Text = string.Format("{0:mm\\:ss\\.ff}", solveTimer.Elapsed); 
        }

    }
}

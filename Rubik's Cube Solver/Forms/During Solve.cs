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
        }
        
        private void During_Solve_Load(object sender, EventArgs e)
        {
            solveTimer.Start(); //timer is started
        }


        private void During_Solve_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Space) //if the user presses the spacebar
            {
                Global.time = lblTimer.Text;



                solveTimer.Stop(); //timer is stopped

                Before_Solve bs = new Before_Solve();
                bs.Show(); //open beforeSolve form
                Visible = false; //close duringSolve form
            }
        }

        private void solveTimer_Tick(object sender, EventArgs e)
        {
            //outputting the time to the user
            lblTimer.Text = string.Format("{0:mm\\:ss\\.ff}", solveTimer.Elapsed); 
        }

    }
}

using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSolver_Click(object sender, EventArgs e)
        {
            Global.stage[0] = 1;
            Global.stage[1] = 1;

            //opening the first form of the solver
            Input_Colours ic = new Input_Colours();
            ic.Show();
            Visible = false;
        }
        
        private void btnTimer_Click(object sender, EventArgs e)
        {
            //opening the first form of the timer
            Before_Solve bs = new Before_Solve();
            bs.Show();
            Visible = false;
        }

        private void btnNotation_Click(object sender, EventArgs e)
        {
            //opening the notation explanation document
            Notation_Explanation ne = new Notation_Explanation();
            ne.Show();
            Visible=false;
        }
    }
}
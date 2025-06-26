using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Before_Solve : Form
    {
        private String previousTime;
        public Before_Solve(String previousTime)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            this.previousTime = previousTime;
        }

        private void Before_Solve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) // if the user presses the spacebar
            {

                FormNavigator.Navigate<During_Solve>(this);

            }

        }

        private void Before_Solve_Load(object sender, EventArgs e)
        {
            lblTime.Text = this.previousTime;

            lblScramble.Text = Scrambler.getScramble();

            Global.scramble = lblScramble.Text;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }
    }
}

using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class BeforeSolve : Form
    {
        private String previousTime;
        public BeforeSolve(String previousTime)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            this.previousTime = previousTime;
        }

        private void BeforeSolve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) // if the user presses the spacebar
            {

                FormNavigator.Navigate<DuringSolve>(this);

            }

        }

        private void BeforeSolve_Load(object sender, EventArgs e)
        {
            lblTime.Text = this.previousTime;
            lblScramble.Text = Scrambler.GetScramble();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }
    }
}

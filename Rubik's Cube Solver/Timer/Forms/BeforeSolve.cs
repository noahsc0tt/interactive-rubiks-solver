using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Timer.Forms
{
    public partial class BeforeSolve : Form
    {
        private readonly string previousTime;

        public BeforeSolve(string previousTime)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            this.previousTime = previousTime;
        }

        private void BeforeSolve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) // if the user presses the spacebar
                FormNavigator.Navigate<DuringSolve>(this);
        }

        private void BeforeSolve_Load(object sender, EventArgs e)
        {
            lblTime.Text = previousTime;
            lblScramble.Text = Util.Scrambler.GetScramble();
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Rubiks_Cube_Solver.Forms.Menu>(this);
    }
}

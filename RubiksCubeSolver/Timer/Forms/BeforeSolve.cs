using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Timer.Forms
{
    internal partial class BeforeSolve : Form
    {
        private readonly string previousTime;

        public BeforeSolve(string previousTime)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            this.previousTime = previousTime;
        }

        private void BeforeSolve_Load(object sender, EventArgs e)
        {
            previousTimeLabel.Text = previousTime;
            scrambleLabel.Text = Util.Scrambler.GetScramble();
        }

        private void BeforeSolve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) // if the user presses the spacebar
                FormNavigator.Navigate<DuringSolve>(this);
        }
    }
}

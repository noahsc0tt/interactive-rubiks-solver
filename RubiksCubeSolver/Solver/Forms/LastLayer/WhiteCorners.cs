using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Solver.Forms
{
    /// <summary>
    /// A form explaining how to solve the 'White Corners' stage.
    /// </summary>
    internal partial class WhiteCorners : Form
    {
        public WhiteCorners()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, Stage.WhiteCorners);
    }
}

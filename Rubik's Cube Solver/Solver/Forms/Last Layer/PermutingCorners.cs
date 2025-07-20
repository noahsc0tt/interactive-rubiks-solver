using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    internal partial class PermutingCorners : Form
    {
        public PermutingCorners()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, Stage.PermutingCorners);
    }
}
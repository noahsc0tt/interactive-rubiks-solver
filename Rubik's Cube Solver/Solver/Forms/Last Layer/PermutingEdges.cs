using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    internal partial class PermutingEdges : Form
    {
        public PermutingEdges()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void MenuButton_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, Stage.PermutingEdges);
    }
}

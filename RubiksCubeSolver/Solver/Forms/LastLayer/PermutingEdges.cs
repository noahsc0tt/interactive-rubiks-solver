using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Solver.Forms
{
    /// <summary>
    /// A form explaining how to solve the 'Permuting Edges' stage.
    /// </summary>
    internal partial class PermutingEdges : Form
    {
        public PermutingEdges()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, Stage.PermutingEdges);
    }
}

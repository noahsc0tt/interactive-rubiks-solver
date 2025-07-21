using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Solver.Forms
{
    /// <summary>
    /// A form explaining how to solve the 'White Edges' stage.
    /// </summary>
    internal partial class WhiteEdges : Form
    {
        public WhiteEdges()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, Stage.WhiteEdges);
    }
}

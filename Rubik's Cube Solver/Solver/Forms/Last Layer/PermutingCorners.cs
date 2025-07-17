using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Solver.Forms.LastLayer
{
    public partial class PermutingCorners : Form
    {
        private static readonly Stage stage = new(StageStep.LastLayer, 3);

        public PermutingCorners()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, stage);
    }
}
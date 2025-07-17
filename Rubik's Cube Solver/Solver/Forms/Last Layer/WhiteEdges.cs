using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Solver.Forms.LastLayer
{
    public partial class WhiteEdges : Form
    {
        private static readonly Stage stage = new(StageStep.LastLayer, 0);

        public WhiteEdges()
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

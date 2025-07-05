using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class PermutingEdges : Form
    {
        private static readonly Stage stage = new(3, 2);

        public PermutingEdges()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, stage);
    }
}

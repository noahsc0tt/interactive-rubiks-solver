using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class TopLayerCorners : Form
    {
        public TopLayerCorners()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingMoves>(this, new Stage(3,1));

    }
}

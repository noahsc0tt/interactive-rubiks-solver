using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Top_Layer_Corners : Form
    {
        public Top_Layer_Corners()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Checking_Moves>(this);
        }

    }
}

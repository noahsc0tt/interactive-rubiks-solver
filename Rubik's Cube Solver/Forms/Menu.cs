using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void btnSolver_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Input_Colours>(this, new Stage());
        }
        
        private void btnTimer_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Before_Solve>(this, "N/A");
        }

        private void btnNotation_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Notation_Explanation>(this);
        }
    }
}
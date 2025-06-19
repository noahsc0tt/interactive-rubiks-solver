using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Permuting_Edges : Form
    {
        public Permuting_Edges()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //opening menu
            Menu menu = new Menu();
            menu.Show();
            Visible = false;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //opening the 'Checking Moves' form
            Checking_Moves cm = new Checking_Moves();
            cm.Show();
            Visible = false;
        }
    }
}

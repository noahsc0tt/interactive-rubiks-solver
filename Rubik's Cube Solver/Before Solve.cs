using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Before_Solve : Form
    {        
        public Before_Solve()
        {
            InitializeComponent();
        }

        private string scrambler()
        {
            //array of all possible moves
            string[] moves = { "U", "U'", "U2", "B", "B'", "B2", "F", "F'", "F2", "D", "D'", "D2", "L", "L'", "L2", "R", "R'", "R2" };

            Random random = new Random();

            string scramble = moves[random.Next(moves.Length)]; 
            string lastMove = scramble;
            string nextMove;

            //generating 20 random moves
            for (int i = 0; i < 19; i++)
            {
                do
                {
                    nextMove = moves[random.Next(moves.Length)];

                } while (nextMove.Substring(0, 1) == lastMove.Substring(0, 1));

                scramble += ", " + nextMove;
                lastMove = nextMove;
            }

            return scramble;
        }

        private void Before_Solve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) // if the user presses the spacebar
            {

                During_Solve ds = new During_Solve();
                ds.Show(); //open duringSolve form
                Visible = false; //close beforeSolve form
                
            }

        }

        private void Before_Solve_Load(object sender, EventArgs e)
        {
            lblTime.Text = Global.time;

            lblScramble.Text = scrambler();

            Global.scramble = lblScramble.Text;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //opening menu
            Menu menu = new Menu();
            menu.Show();
            Visible = false;
        }
    }
}

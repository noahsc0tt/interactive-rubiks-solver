using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.OleDb;


namespace Rubik_s_Cube_Solver
{
    public partial class During_Solve : Form
    {
        public void writeToDB()
        {
            string scrambleData = Global.scramble;
            int timeData = (int)solveTimer.ElapsedMilliseconds;

            //creating database connection 
            var insertConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=rubiksCubeDB.accdb");
            insertConn.Open();

            //creating a variable to store the insert SQL statement
            string insertString = "INSERT INTO times(scramble,time) values('" + scrambleData + "', '" + timeData + "')";

            //executing the SQL statement and creating a reader object to insert the values
            OleDbCommand insertCommand = new OleDbCommand(insertString, insertConn);
            OleDbDataReader insertReader = insertCommand.ExecuteReader();

            insertReader.Close();
            insertConn.Close();


        }
      

        Stopwatch solveTimer = new Stopwatch();

        public During_Solve()
        {
            InitializeComponent();
        }

        private void During_Solve_Load(object sender, EventArgs e)
        {
            solveTimer.Start(); //timer is started
        }


        private void During_Solve_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Space) //if the user presses the spacebar
            {
                Global.time = lblTimer.Text;

                //writeToDB(); //inserting the 'time' and 'scramble' values into the 'Times' table             

                solveTimer.Stop(); //timer is stopped

                Before_Solve bs = new Before_Solve();
                bs.Show(); //open beforeSolve form
                Visible = false; //close duringSolve form
            }
        }

        private void solveTimer_Tick(object sender, EventArgs e)
        {
            //outputting the time to the user
            lblTimer.Text = string.Format("{0:mm\\:ss\\.ff}", solveTimer.Elapsed); 
        }

    }
}

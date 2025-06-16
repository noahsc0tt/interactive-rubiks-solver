using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Rubik_s_Cube_Solver
{
    public partial class Output_Solution : Form
    {
        public Output_Solution()
        {
            InitializeComponent();
        }

        private void rotatePieceLocation()
        {
            //checking if the piece is an edge
            if (Global.location[0] == 2 || Global.location[1] == 2 || Global.location[2] == 2)
            {
                if (Global.location[1] == 3) //checking if the edge is in the top layer of the cube
                {
                    if (Global.location[0] == 2)
                    {
                        if (Global.location[2] == 3)
                        {
                            Global.location[0] = 1;
                            Global.location[2] = 2;
                        }
                        else
                        {
                            Global.location[0] = 3;
                            Global.location[2] = 2;
                        }
                    }
                    else
                    {
                        int swap = Global.location[0];
                        Global.location[0] = Global.location[2];
                        Global.location[2] = swap;
                    }
                }
                else if (Global.location[1] == 2) //checking if the edge is in the middle layer of the cube
                {
                    int swap = Global.location[0];

                    if (Global.location[2] == 1)
                    {
                        Global.location[0] = 3;
                    }
                    else
                    {
                        Global.location[0] = 1;
                    }
                    
                    Global.location[2] = swap;
                    
                    if (Global.orientation == "good")
                    {
                        Global.orientation = "bad";
                    }
                    else
                    {
                        Global.orientation = "good";
                    }
                }
                else //if the edge is in the bottom layer of the cube
                {
                    if (Global.location[2] == 1)
                    {
                        Global.location[0] = 3;
                        Global.location[2] = 2;
                    }
                    else if (Global.location[2] == 2)
                    {
                        int swap = Global.location[0];
                        Global.location[0] = Global.location[2];
                        Global.location[2] = swap;
                    }
                    else
                    {
                        Global.location[0] = 1;
                        Global.location[2] = 2;
                    }
                }
            }
            else //if the piece is a corner
            {
                int swap = Global.location[0];

                if (Global.location[2] == 1)
                {
                    Global.location[0] = 3;
                }
                else
                {
                    Global.location[0] = 1;
                }
                Global.location[2] = swap;
            }
        }


        private void calculateSolve()
        {
            //creating an integer value of Global.location that can be compared to the 'location' field in the Solver table
            int locationInt = Int32.Parse(string.Join("", Global.location));

            //creating database connection 
            var conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=rubiksCubeDB.accdb");
            conn.Open();

            //creating a variable to store the select SQL statement
            string sqlString = "SELECT * FROM Solver WHERE solveStage = " + Global.stage[0];

            //executing the SQL statement and creating a reader object to search the selected values
            OleDbCommand command = new OleDbCommand(sqlString, conn);
            OleDbDataReader reader = command.ExecuteReader();

            bool found = false; //creating a variable to check whether matching data has been found

            //iterating through the 'Solver' table records
            while (reader.Read())
            {
                //creating variables to store the data in the record
                int location = (int)reader["location"];
                string orientation = (string)reader["orientation"];
                string sequence = (string)reader["sequence"];
                string explanation = (string)reader["explanation"];


                if ((string) reader["orientation"] == "null")
                {
                    orientation = null;
                }


                //checking if the record matches the position of the piece inputted by the user
                if(location == locationInt && orientation == Global.orientation)
                {
                    //outputting the relevant information to the user
                    lblSequenceOfMoves.Text = sequence;
                    lblExplanation.Text = explanation;

                    found = true;
                }

            }

            if (!found) //checking if the user input does not match any data from the database

            {
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");

                //opening the 'Input Colours' form so the user can reenter their input
                Input_Colours ic = new Input_Colours();
                ic.Show();
                Visible = false;
            }

            reader.Close();
            conn.Close();
        }

        private void Output_Solution_Load(object sender, EventArgs e)
        {
            //calculating the necessary cube orientation based on the value of Global.stage[1]
            string frontFace = string.Empty;           
            if (Global.stage[1] == 1)
            {
                frontFace = "green";
            }
            else if (Global.stage[1] == 2)
            {
                frontFace = "orange";
            }
            else if (Global.stage[1] == 3)
            {
                frontFace = "blue";
            }
            else if (Global.stage[1] == 4)
            {
                frontFace = "red";
            }
            //outputting the necessary cube orientation to the user
            lblCubeOrientation.Text = "Hold your cube with the white centre piece on top and the " + frontFace + " centre piece facing you.";



            //calling the 'rotatePieceLocation' procedure the correct number of times 
            for (int i = 0; i < Global.stage[1]-1; i++)
            {
                rotatePieceLocation();
            }


            //updating the 'stage' label to show the user which stage of the solve they are on
            if (Global.stage[0] == 1)
            {
                lblNameOfStage.Text = "Stage: Yellow edges";
            }
            else if (Global.stage[0] == 2)
            {
                lblNameOfStage.Text = "Stage: Yellow corners";
            }
            else if (Global.stage[0] == 3)
            {
                lblNameOfStage.Text = "Stage: Middle layer edges";
            }

            calculateSolve();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //opening the 'Checking Moves' form
            Checking_Moves cm = new Checking_Moves();
            cm.Show();
            Visible = false;
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

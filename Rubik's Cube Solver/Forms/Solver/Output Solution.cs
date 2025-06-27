using System;
using System.Windows.Forms;


namespace Rubiks_Cube_Solver
{
    internal partial class Output_Solution : Form
    {
        private readonly Stage stage;

        public Output_Solution(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
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
            Boolean found = false;           

            if (!found) //checking if the user input does not match any data from the database

            {
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");

                //opening the 'Input Colours' form so the user can reenter their input
                
            }
        }

        private void Output_Solution_Load(object sender, EventArgs e)
        {
            //calculating the necessary cube orientation based on the value of stage.subStep
            string frontFace = string.Empty;           
            if (stage.subStep == 1)
            {
                frontFace = "green";
            }
            else if (stage.subStep == 2)
            {
                frontFace = "orange";
            }
            else if (stage.subStep == 3)
            {
                frontFace = "blue";
            }
            else if (stage.subStep == 4)
            {
                frontFace = "red";
            }
            //outputting the necessary cube orientation to the user
            lblCubeOrientation.Text = "Hold your cube with the white centre piece on top and the " + frontFace + " centre piece facing you.";



            //calling the 'rotatePieceLocation' procedure the correct number of times 
            for (int i = 0; i < stage.subStep-1; i++)
            {
                rotatePieceLocation();
            }


            //updating the 'stage' label to show the user which stage of the solve they are on
            if (stage.step == 1)
            {
                lblNameOfStage.Text = "Stage: Yellow edges";
            }
            else if (stage.step == 2)
            {
                lblNameOfStage.Text = "Stage: Yellow corners";
            }
            else if (stage.step == 3)
            {
                lblNameOfStage.Text = "Stage: Middle layer edges";
            }

            calculateSolve();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Checking_Moves>(this);
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }

    }
}

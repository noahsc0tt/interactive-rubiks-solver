using System;
using System.Windows.Forms;


namespace Rubiks_Cube_Solver
{
    internal partial class Output_Solution : Form
    {
        private readonly Stage stage;
        private PieceLocation location;
        private bool? isGoodOrientation;


        public Output_Solution(Stage currentStage, PieceLocation location, bool? isGood)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            this.location = location;
            isGoodOrientation = isGood;
        }

        private void rotatePieceLocation()
        {
            //checking if the piece is an edge
            if (location.X == 1 || location.Y == 1 || location.Z == 1)
            {
                if (location.Y == 2) //checking if the edge is in the top layer of the cube
                {
                    if (location.X == 1)
                    {
                        if (location.Z == 2)
                        {
                            location.X = 0;
                            location.Z = 1;
                        }
                        else
                        {
                            location.X = 2;
                            location.Z = 1;
                        }
                    }
                    else
                    {
                        int swap = location.X;
                        location.X = location.Z;
                        location.Z = swap;
                    }
                }
                else if (location.Y == 1) //checking if the edge is in the middle layer of the cube
                {
                    int swap = location.X;

                    if (location.Z == 0)
                    {
                        location.X = 2;
                    }
                    else
                    {
                        location.X = 0;
                    }
                    
                    location.Z = swap;
                    
                    if (isGoodOrientation == true)
                    {
                        isGoodOrientation = false;
                    }
                    else
                    {
                        isGoodOrientation = true;
                    }
                }
                else //if the edge is in the bottom layer of the cube
                {
                    if (location.Z == 0)
                    {
                        location.X = 2;
                        location.Z = 1;
                    }
                    else if (location.Z == 1)
                    {
                        int swap = location.X;
                        location.X = location.Z;
                        location.Z = swap;
                    }
                    else
                    {
                        location.X = 0;
                        location.Z = 1;
                    }
                }
            }
            else //if the piece is a corner
            {
                int swap = location.X;

                if (location.Z == 0)
                {
                    location.X = 2;
                }
                else
                {
                    location.X = 0;
                }
                location.Z = swap;
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
            if (stage.SubStep == 0)
            {
                frontFace = "green";
            }
            else if (stage.SubStep == 1)
            {
                frontFace = "orange";
            }
            else if (stage.SubStep == 2)
            {
                frontFace = "blue";
            }
            else if (stage.SubStep == 4)
            {
                frontFace = "red";
            }
            //outputting the necessary cube orientation to the user
            lblCubeOrientation.Text = "Hold your cube with the white centre piece on top and the " + frontFace + " centre piece facing you.";



            //calling the 'rotatePieceLocation' procedure the correct number of times 
            for (int i = 0; i < stage.SubStep-1; i++)
            {
                rotatePieceLocation();
            }


            //updating the 'stage' label to show the user which stage of the solve they are on
            if (stage.Step == 0)
            {
                lblNameOfStage.Text = "Stage: Yellow edges";
            }
            else if (stage.Step == 1)
            {
                lblNameOfStage.Text = "Stage: Yellow corners";
            }
            else if (stage.Step == 2)
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

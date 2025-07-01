using System;
using System.Windows.Forms;


namespace Rubiks_Cube_Solver
{
    internal partial class OutputSolution : Form
    {
        private readonly Stage stage;
        private PieceConfig pieceConfiguration;

        public OutputSolution(Stage currentStage, CubeNetCellLocation cell)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            pieceConfiguration = CellToPieceConfig.GetPieceConfig(cell);
        }

        private void rotatePieceLocation()
        {
            //checking if the piece is an edge
            if (pieceConfiguration.Location.X == 1 || pieceConfiguration.Location.Y == 1 || pieceConfiguration.Location.Z == 1)
            {
                if (pieceConfiguration.Location.Y == 2) //checking if the edge is in the top layer of the cube
                {
                    if (pieceConfiguration.Location.X == 1)
                    {
                        if (pieceConfiguration.Location.Z == 2)
                        {
                            pieceConfiguration.Location.X = 0;
                            pieceConfiguration.Location.Z = 1;
                        }
                        else
                        {
                            pieceConfiguration.Location.X = 2;
                            pieceConfiguration.Location.Z = 1;
                        }
                    }
                    else
                    {
                        int swap = pieceConfiguration.Location.X;
                        pieceConfiguration.Location.X = pieceConfiguration.Location.Z;
                        pieceConfiguration.Location.Z = swap;
                    }
                }
                else if (pieceConfiguration.Location.Y == 1) //checking if the edge is in the middle layer of the cube
                {
                    int swap = pieceConfiguration.Location.X;

                    if (pieceConfiguration.Location.Z == 0)
                    {
                        pieceConfiguration.Location.X = 2;
                    }
                    else
                    {
                        pieceConfiguration.Location.X = 0;
                    }
                    
                    pieceConfiguration.Location.Z = swap;

                    pieceConfiguration.Orientation = pieceConfiguration.Orientation.Flip();
                }
                else //if the edge is in the bottom layer of the cube
                {
                    if (pieceConfiguration.Location.Z == 0)
                    {
                        pieceConfiguration.Location.X = 2;
                        pieceConfiguration.Location.Z = 1;
                    }
                    else if (pieceConfiguration.Location.Z == 1)
                    {
                        int swap = pieceConfiguration.Location.X;
                        pieceConfiguration.Location.X = pieceConfiguration.Location.Z;
                        pieceConfiguration.Location.Z = swap;
                    }
                    else
                    {
                        pieceConfiguration.Location.X = 0;
                        pieceConfiguration.Location.Z = 1;
                    }
                }
            }
            else //if the piece is a corner
            {
                int swap = pieceConfiguration.Location.X;

                if (pieceConfiguration.Location.Z == 0)
                {
                    pieceConfiguration.Location.X = 2;
                }
                else
                {
                    pieceConfiguration.Location.X = 0;
                }
                pieceConfiguration.Location.Z = swap;
            }
        }


        private void calculateSolve()
        {
            Boolean found = false;           

            if (!found)

            {
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");
                //opening the 'Input Colours' form so the user can reenter their input
                // commit: FormNavigator.Navigate<Input_Colours>(this, stage);
                

            }
        }

        private void OutputSolution_Load(object sender, EventArgs e)
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

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingMoves>(this);

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);
    }
}

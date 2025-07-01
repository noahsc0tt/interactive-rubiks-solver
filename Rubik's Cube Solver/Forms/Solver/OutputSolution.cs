using System;
using System.Windows.Forms;


namespace Rubiks_Cube_Solver
{
    internal partial class OutputSolution : Form
    {
        private readonly Stage stage;
        private PieceConfig piece;

        public OutputSolution(Stage currentStage, CubeNetCellLocation cell)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            piece = CellToPieceConfig.GetPieceConfig(cell);
        }

        private void rotatePieceLocation()
        {
            (int x, int y, int z) = piece.Location.GetLocation();
            PieceOrientation orientation = piece.Orientation;

            //checking if the piece is an edge
            if (x == 1 || y == 1 || z == 1)
            {
                if (y == 2) //checking if the edge is in the top layer of the cube
                {
                    if (x == 1)
                    {
                        if (z == 2)
                        {
                            x = 0;
                            z = 1;
                        }
                        else
                        {
                            x = 2;
                            z = 1;
                        }
                    }
                    else
                    {
                        int swap = x;
                        x = z;
                        z = swap;
                    }
                }
                else if (y == 1) //checking if the edge is in the middle layer of the cube
                {
                    int swap = x;

                    if (z == 0)
                    {
                        x = 2;
                    }
                    else
                    {
                        x = 0;
                    }
                    
                    z = swap;

                    orientation = orientation.Flip();
                }
                else //if the edge is in the bottom layer of the cube
                {
                    if (z == 0)
                    {
                        x = 2;
                        z = 1;
                    }
                    else if (z == 1)
                    {
                        int swap = x;
                        x = z;
                        z = swap;
                    }
                    else
                    {
                        x = 0;
                        z = 1;
                    }
                }
            }
            else //if the piece is a corner
            {
                int swap = x;

                if (z == 0)
                {
                    x = 2;
                }
                else
                {
                    x = 0;
                }
                z = swap;
            }

            piece = new PieceConfig((x, y, z), orientation);
        }


        private void calculateSolve()
        {
            bool found = false;           

            if (!found)
            {
                //opening the 'Input Colours' form so the user can reenter their input
                FormNavigator.Navigate<InputColours>(this, stage);
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");
            }
        }

        private void OutputSolution_Load(object sender, EventArgs e)
        {
            //outputting the necessary cube orientation to the user
            lblCubeOrientation.Text = $"Hold your cube with the white centre piece on top and the {GetFrontFaceName()} centre piece facing you.";

            //updating the 'stage' label to show the user which stage of the solve they are on
            lblNameOfStage.Text = stage.GetName();

            //calling the 'rotatePieceLocation' procedure the correct number of times 
            for (int i = 0; i < stage.SubStep-1; i++)
            {
                rotatePieceLocation();
            }

            calculateSolve();
        }

        private string GetFrontFaceName() => stage.SubStep switch
        {
            0 => "green",
            1 => "orange",
            2 => "blue",
            3 => "red"
        };

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingMoves>(this);

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);
    }
}

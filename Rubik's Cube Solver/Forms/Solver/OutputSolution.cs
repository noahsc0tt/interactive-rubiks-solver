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

        private void RotatePieceLocation()
        {
            (int x, int y, int z) = piece.Location.GetLocation();
            PieceOrientation orientation = piece.Orientation;

            //checking if the piece is an edge
            if (x == 1 || y == 1 || z == 1)
            {
                switch(y)
                {
                    case 0:
                        if (z == 0)
                        {
                            x = 2;
                            z = 1;
                        }
                        else if (z == 1)
                            (z, x) = (x, z);
                        else
                        {
                            x = 0;
                            z = 1;
                        }
                        break;

                    case 1:
                        if (z == 0)
                            (x, z) = (2, x);
                        else
                            (x, z) = (0, x);
                        orientation = orientation.Flip();
                        break;
                    case 2:
                        if (x == 1)
                        {
                            if (z == 2)
                                x = 0;
                            else
                                x = 2;
                            z = 1;
                        }
                        else
                            (z, x) = (x, z);
                        break;
                }
            }
            else //if the piece is a corner
            {
                int swap = x;

                if (z == 0)
                    x = 2;
                else
                    x = 0;
                z = swap;
            }

            piece = new PieceConfig((x, y, z), orientation);
        }


        private void CalculateSolve()
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
                RotatePieceLocation();
            }

            CalculateSolve();
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

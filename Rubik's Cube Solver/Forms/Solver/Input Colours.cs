using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal partial class Input_Colours : Form
    {
        private readonly Stage stage;
        private bool selectionMade = false;
        private PieceConfig? selectedPiece;

        public Input_Colours(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
            stage = currentStage;
        }

        private void PopulateCubeFace(DataGridView face, Color colour)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = 0; i < 3; i++)
            {
                face.Rows.Add("", "", "");
            }
            face[1, 1].Style.BackColor = colour;
            face.ClearSelection(); //un-highlighting buttons
        }

        private void PopulateCubeNet()
        {
            //populating each face of the cube
            PopulateCubeFace(orangeFace, Color.Orange);
            PopulateCubeFace(redFace, Color.Red);
            PopulateCubeFace(whiteFace, Color.White);
            PopulateCubeFace(yellowFace, Color.Yellow);
            PopulateCubeFace(blueFace, Color.RoyalBlue);
            PopulateCubeFace(greenFace, Color.Green);
        }

        private void Solver_Input_Colours_Load(object sender, EventArgs e)
        {
            //creating variables to store information pertaining to the instructions to be output
            string requiredFace = string.Empty;
            string requiredPiece = string.Empty;
            
            //setting the value of these variables based on the value of Global.stage
            if (stage.Step == 0)
            {
                if (stage.SubStep == 0)
                {
                    requiredPiece = "green";
                }
                else if (stage.SubStep == 1)
                {
                    requiredPiece = "orange";

                }
                else if (stage.SubStep == 2)
                {
                    requiredPiece = "blue";

                }
                else if (stage.SubStep == 3)
                {
                    requiredPiece = "red";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the yellow square on the yellow and " + requiredPiece + " edge.";
            }
            else if (stage.Step == 1)
            {
                if (stage.SubStep == 0)
                {
                    requiredPiece = "green and red";

                }
                else if (stage.SubStep == 1)
                {
                    requiredPiece = "orange and green";

                }
                else if (stage.SubStep == 2)
                {
                    requiredPiece = "blue and orange";

                }
                else if (stage.SubStep == 3)
                {
                    requiredPiece = "red and blue";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the yellow square on the yellow, " + requiredPiece + " corner.";
            }
            else if (stage.Step == 2)
            {
                if (stage.SubStep == 0)
                {
                    requiredPiece = "green and red";
                    requiredFace = "green";

                }
                else if (stage.SubStep == 1)
                {
                    requiredPiece = "orange and green";
                    requiredFace = "orange";

                }
                else if (stage.SubStep == 2)
                {
                    requiredPiece = "blue and orange";
                    requiredFace = "blue";

                }
                else if (stage.SubStep == 3)
                {
                    requiredPiece = "red and blue";
                    requiredFace = "red";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the " + requiredFace + " square on the " + requiredPiece + " edge.";
            }
            PopulateCubeNet();
        }

        private void HandleCellClick(DataGridView face, DataGridViewCellEventArgs e, PieceConfig piece)
        {
            face.ClearSelection();
            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectionMade = true;
                selectedPiece = piece;
                face.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = stage.GetInputColour().ToColor();
            }
        }
        private void WhiteFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CubeNetCellLocation selectedCell = new CubeNetCellLocation((e.ColumnIndex, e.RowIndex), FaceColour.White);
            PieceConfig config = CellToPieceConfig.GetPieceConfig(selectedCell); 
            HandleCellClick((DataGridView)sender, e, config);
        }

        private void OrangeFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CubeNetCellLocation selectedCell = new CubeNetCellLocation((e.ColumnIndex, e.RowIndex),FaceColour.Orange);
            PieceConfig selectedPiece = CellToPieceConfig.GetPieceConfig(selectedCell);
            HandleCellClick((DataGridView) sender, e, selectedPiece);
        }

        private void GreenFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CubeNetCellLocation selectedCell = new CubeNetCellLocation((e.ColumnIndex, e.RowIndex), FaceColour.Green);
            PieceConfig selectedPiece = CellToPieceConfig.GetPieceConfig(selectedCell);
            HandleCellClick((DataGridView)sender, e, selectedPiece);
        }

        private void RedFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CubeNetCellLocation selectedCell = new CubeNetCellLocation((e.ColumnIndex, e.RowIndex), FaceColour.Red);
            PieceConfig selectedPiece = CellToPieceConfig.GetPieceConfig(selectedCell);
            HandleCellClick((DataGridView) sender, e, selectedPiece);
        }

        private void BlueFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CubeNetCellLocation selectedCell = new CubeNetCellLocation((e.ColumnIndex, e.RowIndex), FaceColour.Blue);
            PieceConfig selectedPiece = CellToPieceConfig.GetPieceConfig(selectedCell);
            HandleCellClick((DataGridView) sender, e, selectedPiece);
        }

        private void YellowFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CubeNetCellLocation selectedCell = new CubeNetCellLocation((e.ColumnIndex, e.RowIndex), FaceColour.Yellow);
            PieceConfig selectedPiece = CellToPieceConfig.GetPieceConfig(selectedCell);
            HandleCellClick((DataGridView) sender, e, selectedPiece);
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //checking if the user has inputted the position of the required piece
            if (selectionMade) 
                //moving on to the output solution form
                FormNavigator.Navigate<Output_Solution>(this);
            
            else
                //error message telling the user to input the required information before moving on
                MessageBox.Show(lblInstructions.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedPiece = null;
            selectionMade = false;
        }
    }
}

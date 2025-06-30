using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal partial class Input_Colours : Form
    {
        private readonly Stage stage;
        private PieceConfig? selectedPiece;
        private readonly (DataGridView, Color)[] faceInfo;

        public Input_Colours(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
            stage = currentStage;

            faceInfo =
            [
                (orangeFace, Color.Orange),
                (redFace, Color.Red),
                (whiteFace, Color.White),
                (yellowFace, Color.Yellow),
                (blueFace, Color.RoyalBlue),
                (greenFace, Color.Green)
            ];
            
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
            foreach(var (face, centreColour) in faceInfo)
                PopulateCubeFace(face, centreColour);
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

        private void HandleCellClick(DataGridView face, DataGridViewCellEventArgs e, FaceColour colour)
        {
            face.ClearSelection();

            (int col, int row) cellCoords = (e.ColumnIndex, e.RowIndex);

            if (cellCoords == (1,1)) //if a centre piece is clicked
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectedPiece = CellToPieceConfig.GetPieceConfig(new CubeNetCellLocation(cellCoords, colour));
                face.Rows[cellCoords.row].Cells[cellCoords.col].Style.BackColor = stage.GetInputColour().ToColor();
            }
        }

        private void WhiteFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.White);

        private void OrangeFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView) sender, e, FaceColour.Orange);

        private void GreenFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.Green);
        
        private void RedFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView) sender, e, FaceColour.Red);
        
        private void BlueFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView) sender, e, FaceColour.Blue);

        private void YellowFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView) sender, e, FaceColour.Yellow);
        

        private void btnMenu_Click(object sender, EventArgs e) => FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //checking if the user has inputted the position of the required piece
            if (selectedPiece is not null) 
                //moving on to the output solution form
                FormNavigator.Navigate<Output_Solution>(this, stage, selectedPiece);
            
            else
                //error message telling the user to input the required information before moving on
                MessageBox.Show(lblInstructions.Text);
        }

        private void btnClear_Click(object sender, EventArgs e) => selectedPiece = null;
    }
}

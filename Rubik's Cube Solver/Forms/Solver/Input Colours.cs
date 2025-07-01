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
            btnFinish.Visible = false;

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
            PopulateCubeNet();
            lblInstructions.Text = GetInstructions();
        }

        private string GetInstructions() 
        {
            string requiredPiece = stage.GetRequiredPiece();
            string requiredColour = stage.Step switch
            {
                0 or 1 => "yellow",
                2 => requiredPiece.Split(' ')[0]
            };
            return $"Input the position of the {requiredColour} square on the {requiredPiece}";
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
                btnFinish.Visible = true;
            }
        }

        private void WhiteFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.White);

        private void OrangeFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.Orange);

        private void GreenFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.Green);
        
        private void RedFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.Red);
        
        private void BlueFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.Blue);

        private void YellowFace_CellClick(object sender, DataGridViewCellEventArgs e) =>
            HandleCellClick((DataGridView)sender, e, FaceColour.Yellow);
        

        private void btnMenu_Click(object sender, EventArgs e) => FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Output_Solution>(this, stage, selectedPiece);
            
        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedPiece = null;
            btnFinish.Visible = false;
        }
    }
}

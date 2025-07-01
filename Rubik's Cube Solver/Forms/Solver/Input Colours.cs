using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    using Face = DataGridView;

    using Entry = System.Collections.Generic.KeyValuePair<DataGridView, FaceColour>;

    internal partial class Input_Colours : Form
    {
        private readonly Stage stage;
        private CubeNetCellLocation? selectedCell;
        private readonly ImmutableDictionary<DataGridView, FaceColour> faceColourDict;

        public Input_Colours(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
            btnFinish.Visible = false;

            stage = currentStage;
            faceColourDict = ImmutableDictionary.CreateRange
            (
                new Entry[] {
                new Entry(orangeFace, FaceColour.Orange),
                new Entry(redFace, FaceColour.Red),
                new Entry(whiteFace, FaceColour.White),
                new Entry(yellowFace, FaceColour.Yellow),
                new Entry(blueFace, FaceColour.Blue),
                new Entry(greenFace, FaceColour.Green)
            });
        }

        private void PopulateCubeFace(Face face, Color colour)
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
            foreach(Entry entry in faceColourDict)
                PopulateCubeFace(entry.Key, entry.Value.ToColor());
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



        private void HandleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Face face = (Face)sender;
            face.ClearSelection();


            (int col, int row) cellCoords = (e.ColumnIndex, e.RowIndex);
            if (cellCoords == (1,1)) //if a centre piece is clicked
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectedCell = new CubeNetCellLocation(cellCoords, faceColourDict[face]);
                face.Rows[cellCoords.row].Cells[cellCoords.col].Style.BackColor = stage.GetInputColour().ToColor();
                btnFinish.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) => FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Output_Solution>(this, stage, selectedCell);
            
        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedCell = null;
            btnFinish.Visible = false;
        }
    }
}

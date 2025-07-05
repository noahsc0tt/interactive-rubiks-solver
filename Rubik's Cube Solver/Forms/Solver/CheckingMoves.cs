using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    using Face = DataGridView;

    internal partial class CheckingMoves : Form
    {
        private Stage stage;
        private const int maxSubStep = 3;

        public CheckingMoves(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
        }
        private void Checking_Moves_Load(object sender, EventArgs e)
        {
            ColourCubeNet();

            //changing the text of the 'Next Stage' button if the user has completed the solve
            if (stage.GetStage() == (3,3))
            {
                btnNextStage.Visible = false;
                lblButtonInstructions.Text = "If your cube is fully solved, congratulations! Click the 'Menu' button to return to the menu.\r\n\r\nIf your cube is not solved, choose a stage to go back to in the 'Choose Stage' drop-down list.";
            }
        }

        private void PopulateCubeFace(Face face)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = 0; i < 3; i++)
                face.Rows.Add("", "", "");
            face[1, 1].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
            face.ClearSelection(); //un-highlighting buttons
        }

        private void PopulateCubeNet() =>
            Array.ForEach([whiteFace, yellowFace, greenFace, blueFace, redFace, orangeFace], PopulateCubeFace);


        private void ColourYellowEdges(int subStep)
        {
            if (subStep >= 0)
            {
                ColourCell(greenFace, (1, 2), Color.Green);
                ColourCell(yellowFace, (1, 0), Color.Yellow);
            }
            if (subStep >= 1)
            {
                ColourCell(orangeFace, (1, 2), Color.Orange);
                ColourCell(yellowFace, (0, 1), Color.Yellow);
            }
            if (subStep >= 2)
            {
                ColourCell(blueFace, (1, 2), Color.Blue);
                ColourCell(yellowFace, (1, 2), Color.Yellow);
            }
            if (subStep == 3)
            {
                ColourCell(redFace, (1, 2), Color.Red);
                ColourCell(yellowFace, (2, 1), Color.Yellow);
            }
        }

        private void ColourYellowCorners(int subStep)
        {
            if (subStep >= 0)
            {
                ColourCell(redFace, (0, 2), Color.Red);
                ColourCell(greenFace, (2, 2), Color.Green);
                ColourCell(yellowFace, (2, 0), Color.Yellow);
            }
            if (subStep >= 1)
            {
                ColourCell(greenFace, (0, 2), Color.Green);
                ColourCell(orangeFace, (2, 2), Color.Orange);
                ColourCell(yellowFace, (0, 0), Color.Yellow);
            }
            if (subStep >= 2)
            {
                ColourCell(orangeFace, (0, 2), Color.Orange);
                ColourCell(blueFace, (2, 2), Color.Blue);
                ColourCell(yellowFace, (0, 2), Color.Yellow);
            }
            if (subStep == 3)
            {
                ColourCell(blueFace, (0, 2), Color.Blue);
                ColourCell(redFace, (2, 2), Color.Red);
                ColourCell(yellowFace, (2, 2), Color.Yellow);
            }
        }

        private void ColourMiddleLayerEdges(int subStep)
        {
            if (subStep >= 0)
            {
                ColourCell(redFace, (0, 1), Color.Red);
                ColourCell(greenFace, (2, 1), Color.Green);
            }
            if (subStep >= 1)
            {
                ColourCell(greenFace, (0, 1), Color.Green);
                ColourCell(orangeFace, (2, 1), Color.Orange);
            }
            if (subStep >= 2)
            {
                ColourCell(orangeFace, (0, 1), Color.Orange);
                ColourCell(blueFace, (2, 1), Color.Blue);
            }
            if (subStep == 3)
            {
                ColourCell(blueFace, (0, 1), Color.Blue);
                ColourCell(redFace, (2, 1), Color.Red);
            }
        }

        private void ColourLastLayer(int subStep)
        {
            if (stage.SubStep >= 1) // white edges
            {
                ColourCell(whiteFace, (0, 1), Color.White);
                ColourCell(whiteFace, (1, 0), Color.White);
                ColourCell(whiteFace, (2, 1), Color.White);
                ColourCell(whiteFace, (1, 2), Color.White);
            }
            if (stage.SubStep >= 2) // white corners
            {
                ColourCell(whiteFace, (0, 0), Color.White);
                ColourCell(whiteFace, (2, 0), Color.White);
                ColourCell(whiteFace, (0, 2), Color.White);
                ColourCell(whiteFace, (2, 2), Color.White);
            }
            if (stage.SubStep >= 3) // permuting corners
            {
                ColourCell(greenFace, (0, 0), Color.Green);
                ColourCell(greenFace, (2, 0), Color.Green);
                ColourCell(orangeFace, (0, 0), Color.Orange);
                ColourCell(orangeFace, (2, 0), Color.Orange);
                ColourCell(blueFace, (0, 0), Color.Blue);
                ColourCell(blueFace, (2, 0), Color.Blue);
                ColourCell(redFace, (0, 0), Color.Red);
                ColourCell(redFace, (2, 0), Color.Red);

            }
            if (stage.SubStep == 4) // permuting edges
            {
                ColourCell(greenFace, (1, 0), Color.Green);
                ColourCell(orangeFace, (1, 0), Color.Orange);
                ColourCell(blueFace, (1, 0), Color.Blue);
                ColourCell(redFace, (1, 0), Color.Red);
            }
        }

        private void ColourCubeNet()
        {
            PopulateCubeNet();
            
            switch (stage.Step)
            {
                case 0:
                    ColourYellowEdges(stage.SubStep); 
                    break;
                case 1:
                    ColourYellowEdges(maxSubStep);
                    ColourYellowCorners(stage.SubStep);
                    break;
                case 2:
                    ColourYellowEdges(maxSubStep);
                    ColourYellowCorners(maxSubStep);
                    ColourMiddleLayerEdges(stage.SubStep);
                    break;
                case 3:
                    ColourYellowEdges(maxSubStep);
                    ColourYellowCorners(maxSubStep);
                    ColourMiddleLayerEdges(stage.SubStep);
                    ColourLastLayer(stage.SubStep);
                    break;

            };
        }

        private void ColourCell(Face face, (int x, int y) location, Color colour) =>
            face[location.x, location.y].Style.BackColor = colour;

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            stage.Increment();
            if (stage.Step == 3)
            {
                switch (stage.SubStep)
                {
                    case 0: FormNavigator.Navigate<TopLayerEdges>(this); break;
                    case 1: FormNavigator.Navigate<TopLayerCorners>(this); break;
                    case 2: FormNavigator.Navigate<PermutingCorners>(this); break;
                    case 3: FormNavigator.Navigate<PermutingEdges>(this); break;
                }
            }
            else
                FormNavigator.Navigate<InputColours>(this, stage);
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (int step, int subStep) = (string)boxChooseStage.SelectedItem switch
            {
                "Yellow Edges" => (0,0),
                "Yellow Corners" => (1,0),
                "Middle Layer Edges" => (2,0),
                "White Edges" => (3,0),
                "White Corners" => (3,1),
                "Corner Permutation" => (3,2),
                "Edge Permutation" => (3,3)
            };
            FormNavigator.Navigate<InputColours>(this, new Stage(step, subStep));
        }
    }
}

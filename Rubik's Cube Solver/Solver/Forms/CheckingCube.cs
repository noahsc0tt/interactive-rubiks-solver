using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    using LastLayer;
    using Face = DataGridView;

    internal partial class CheckingCube : Form
    {
        private readonly Stage stage;

        public CheckingCube(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
        }
        private void Checking_Moves_Load(object sender, EventArgs e)
        {
            ColourCubeNet();

            //changing the text of the 'Next Stage' button if the user has completed the solve
            if (stage.GetStage() == Stage.MaxStage)
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
                ColourCell(greenFace, (1, 2));
                ColourCell(yellowFace, (1, 0));
            }
            if (subStep >= 1)
            {
                ColourCell(orangeFace, (1, 2));
                ColourCell(yellowFace, (0, 1));
            }
            if (subStep >= 2)
            {
                ColourCell(blueFace, (1, 2));
                ColourCell(yellowFace, (1, 2));
            }
            if (subStep == 3)
            {
                ColourCell(redFace, (1, 2));
                ColourCell(yellowFace, (2, 1));
            }
        }

        private void ColourYellowCorners(int subStep)
        {
            if (subStep >= 0)
            {
                ColourCell(redFace, (0, 2));
                ColourCell(greenFace, (2, 2));
                ColourCell(yellowFace, (2, 0));
            }
            if (subStep >= 1)
            {
                ColourCell(greenFace, (0, 2));
                ColourCell(orangeFace, (2, 2));
                ColourCell(yellowFace, (0, 0));
            }
            if (subStep >= 2)
            {
                ColourCell(orangeFace, (0, 2));
                ColourCell(blueFace, (2, 2));
                ColourCell(yellowFace, (0, 2));
            }
            if (subStep == 3)
            {
                ColourCell(blueFace, (0, 2));
                ColourCell(redFace, (2, 2));
                ColourCell(yellowFace, (2, 2));
            }
        }

        private void ColourMiddleLayerEdges(int subStep)
        {
            if (subStep >= 0)
            {
                ColourCell(redFace, (0, 1));
                ColourCell(greenFace, (2, 1));
            }
            if (subStep >= 1)
            {
                ColourCell(greenFace, (0, 1));
                ColourCell(orangeFace, (2, 1));
            }
            if (subStep >= 2)
            {
                ColourCell(orangeFace, (0, 1));
                ColourCell(blueFace, (2, 1));
            }
            if (subStep == 3)
            {
                ColourCell(blueFace, (0, 1));
                ColourCell(redFace, (2, 1));
            }
        }

        private void ColourLastLayer(int subStep)
        {
            if (subStep >= 0) // white edges
            {
                ColourCell(whiteFace, (0, 1));
                ColourCell(whiteFace, (1, 0));
                ColourCell(whiteFace, (2, 1));
                ColourCell(whiteFace, (1, 2));
            }
            if (subStep >= 1) // white corners
            {
                ColourCell(whiteFace, (0, 0));
                ColourCell(whiteFace, (2, 0));
                ColourCell(whiteFace, (0, 2));
                ColourCell(whiteFace, (2, 2));
            }
            if (subStep >= 2) // permuting corners
            {
                ColourCell(greenFace, (0, 0));
                ColourCell(greenFace, (2, 0));
                ColourCell(orangeFace, (0, 0));
                ColourCell(orangeFace, (2, 0));
                ColourCell(blueFace, (0, 0));
                ColourCell(blueFace, (2, 0));
                ColourCell(redFace, (0, 0));
                ColourCell(redFace, (2, 0));

            }
            if (subStep == 3) // permuting edges
            {
                ColourCell(greenFace, (1, 0));
                ColourCell(orangeFace, (1, 0));
                ColourCell(blueFace, (1, 0));
                ColourCell(redFace, (1, 0));
            }
        }

        private void ColourCubeNet()
        {
            PopulateCubeNet();
            
            switch (stage.Step)
            {
                case StageStep.YellowEdges:
                    ColourYellowEdges(stage.SubStep); 
                    break;
                case StageStep.YellowCorners:
                    ColourYellowEdges(Stage.MaxSubStep);
                    ColourYellowCorners(stage.SubStep);
                    break;
                case StageStep.MiddleLayerEdges:
                    ColourYellowEdges(Stage.MaxSubStep);
                    ColourYellowCorners(Stage.MaxSubStep);
                    ColourMiddleLayerEdges(stage.SubStep);
                    break;
                case StageStep.LastLayer:
                    ColourYellowEdges(Stage.MaxSubStep);
                    ColourYellowCorners(Stage.MaxSubStep);
                    ColourMiddleLayerEdges(Stage.MaxSubStep);
                    ColourLastLayer(stage.SubStep);
                    break;

            };
        }

        private void ColourCell(Face face, (int x, int y) location) =>
            face[location.x, location.y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            stage.Increment();
            if (stage.Step == StageStep.LastLayer)
            {
                switch (stage.SubStep)
                {
                    case 0: FormNavigator.Navigate<WhiteEdges>(this); break;
                    case 1: FormNavigator.Navigate<WhiteCorners>(this); break;
                    case 2: FormNavigator.Navigate<PermutingCorners>(this); break;
                    case 3: FormNavigator.Navigate<PermutingEdges>(this); break;
                }
            }
            else
                FormNavigator.Navigate<InputPiece>(this, stage);
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (StageStep step, int subStep) = (string)boxChooseStage.SelectedItem switch
            {
                "Yellow Edges" => (StageStep.YellowEdges, Stage.MinSubStep),
                "Yellow Corners" => (StageStep.YellowCorners, Stage.MinSubStep),
                "Middle Layer Edges" => (StageStep.MiddleLayerEdges, Stage.MinSubStep),
                "White Edges" => (StageStep.LastLayer, 0),
                "White Corners" => (StageStep.LastLayer, 1),
                "Corner Permutation" => (StageStep.LastLayer, 2),
                "Edge Permutation" => (StageStep.LastLayer, 3)
            };
            if (step == StageStep.LastLayer)
                switch (subStep)
                {
                    case 0: FormNavigator.Navigate<WhiteEdges>(this); break;
                    case 1: FormNavigator.Navigate<WhiteCorners>(this); break;
                    case 2: FormNavigator.Navigate<PermutingCorners>(this); break;
                    case 3: FormNavigator.Navigate<PermutingEdges>(this); break;
                }
            else
                FormNavigator.Navigate<InputPiece>(this, new Stage(step, subStep));
        }
    }
}

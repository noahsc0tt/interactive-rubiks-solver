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
            new CubeNetColourer(new CubeNet
            (
                whiteFace, yellowFace, greenFace, blueFace, redFace, orangeFace
            )).ColourCubeNet(stage);
            //changing the text of the 'Next Stage' button if the user has completed the solve
            if (StageInfo.GetStageTuple(stage) == Stage.MaxStage)
            {
                btnNextStage.Visible = false;
                lblButtonInstructions.Text = "If your cube is fully solved, congratulations!\r\n\r\nIf not, choose a stage to go back to using the drop-down list.";
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            stage.Increment();
            Navigate(stage);
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e) =>
            Navigate((string)boxChooseStage.SelectedItem switch
            {
                "Yellow Edges" => Stage.YellowEdges,
                "Yellow Corners" => Stage.YellowCorners,
                "Middle Layer Edges" => Stage.MiddleLayerEdges,
                "White Edges" => Stage.WhiteEdges,
                "White Corners" => Stage.WhiteCorners,
                "Corner Permutation" => Stage.PermutingCorners,
                "Edge Permutation" => Stage.PermutingEdges
            });

        private void Navigate(Stage stage)
        {
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
    }
}

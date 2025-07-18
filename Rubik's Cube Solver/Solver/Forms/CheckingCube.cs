using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;
using Rubiks_Cube_Solver.Solver.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    internal partial class CheckingCube : Form
    {
        private readonly Stage stage;

        public CheckingCube(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
        }
        private void CheckingCube_Load(object sender, EventArgs e)
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
            FormNavigator.NavigateFromCheckingCube(this,stage);
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e) =>
            FormNavigator.NavigateFromCheckingCube(this, (string)boxChooseStage.SelectedItem switch
            {
                "Yellow Edges" => Stage.YellowEdges,
                "Yellow Corners" => Stage.YellowCorners,
                "Middle Layer Edges" => Stage.MiddleLayerEdges,
                "White Edges" => Stage.WhiteEdges,
                "White Corners" => Stage.WhiteCorners,
                "Corner Permutation" => Stage.PermutingCorners,
                "Edge Permutation" => Stage.PermutingEdges
            });
    }
}

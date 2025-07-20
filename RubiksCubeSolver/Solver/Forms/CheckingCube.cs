using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Solver.Forms
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
            if (stage.GetTuple() == Stage.MaxStage)
            {
                nextStageButton.Visible = false;
                instructionsLabel.Text = "If your cube is fully solved, congratulations!\r\n\r\nIf not, choose a stage to go back to using the drop-down list.";
            }
        }

        private void NextStageButton_Click(object sender, EventArgs e) =>
            FormNavigator.NavigateFromCheckingCube(this, Stage.Increment(stage));

        private void ChooseStageComboBox_SelectionChangeCommitted(object sender, EventArgs e) =>
            FormNavigator.NavigateFromCheckingCube(this, (string)((ComboBox)sender).SelectedItem switch
            {
                "Yellow Edges" => Stage.YellowEdges,
                "Yellow Corners" => Stage.YellowCorners,
                "Middle Layer Edges" => Stage.MiddleLayerEdges,
                "White Edges" => Stage.WhiteEdges,
                "White Corners" => Stage.WhiteCorners,
                "Corner Permutation" => Stage.PermutingCorners,
                "Edge Permutation" => Stage.PermutingEdges,
                _ => throw new ArgumentException($"Unrecognised selection: {((ComboBox)sender).SelectedItem}", nameof(sender))
            });
    }
}

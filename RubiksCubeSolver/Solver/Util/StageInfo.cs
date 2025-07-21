using System;

namespace RubiksCubeSolver.Solver.Util
{
    /// <summary>
    /// Provides names, instructions, and colour information for Stage objects.
    /// </summary>
    internal static class StageInfo
    {
        public static string GetName(Stage stage) =>
            $"{GetStepName(stage.Step)} - {GetSubStepName(stage)}";

        private static string GetStepName(StageStep step) => step switch
        {
            StageStep.YellowEdges => "Yellow Cross",
            StageStep.YellowCorners => "Yellow Corners",
            StageStep.MiddleLayerEdges => "Middle Layer Edges",
            StageStep.LastLayer => "Last Layer",
            _ => throw new ArgumentException($"Invalid stage step: {step}", nameof(step))
        };

        private static string GetSubStepName(Stage stage) => 
            stage.Step == StageStep.LastLayer ?
                stage.SubStep switch
                {
                    Stage.WhiteEdgesSubStep => "White Edges",
                    Stage.WhiteCornersSubStep => "White Corners",
                    Stage.PermutingCornersSubStep => "Permuting Corners",
                    Stage.PermutingEdgesSubStep => "Permuting Edges",
                    _ => throw new ArgumentOutOfRangeException(nameof(stage), stage.SubStep, Stage.SubStepOutOfRangeExceptionMessage)
                }
                : GetRequiredPieceName(stage);

        public static string GetRequiredPieceName(Stage stage) => stage.Step switch
            {
                StageStep.YellowEdges => $"yellow and {stage.SubStep switch
                {
                    0 => "green",
                    1 => "orange",
                    2 => "blue",
                    3 => "red",
                    _ => throw new ArgumentOutOfRangeException(nameof(stage), stage.SubStep, Stage.SubStepOutOfRangeExceptionMessage)
                }} edge",
                StageStep.YellowCorners => $"yellow, {GetColourPairName(stage)} corner",
                StageStep.MiddleLayerEdges => $"{GetColourPairName(stage)} edge",
                _ => throw new InvalidOperationException($"The last layer stages (currently {GetName(stage)}) do not have required pieces")
            };

        /// <summary>
        /// helper method for GetRequiredPieceName
        /// </summary>
        private static string GetColourPairName(Stage stage)
        {
            (StageStep step, int subStep) = stage.GetTuple();
            if (!(step == StageStep.YellowCorners || step == StageStep.MiddleLayerEdges))
                throw new InvalidOperationException($"Only the Yellow Corners and Middle Layer Edges steps have colour pairs, not {step}");
            return subStep switch
            {
                0 => "green and red",
                1 => "orange and green",
                2 => "blue and orange",
                3 => "red and blue",
                _ => throw new ArgumentOutOfRangeException(nameof(stage), subStep, Stage.SubStepOutOfRangeExceptionMessage)
            };
        }

        public static string GetFrontFaceName(Stage stage)
        {
            if (stage.Step == StageStep.LastLayer)
                throw new InvalidOperationException($"The last layer stages (currently {GetName(stage)}) do not have front faces");
            return stage.SubStep switch
            {
                0 => "green",
                1 => "orange",
                2 => "blue",
                3 => "red",
                _ => throw new ArgumentOutOfRangeException(nameof(stage), stage.SubStep, Stage.SubStepOutOfRangeExceptionMessage)
            };
        }

        public static FaceColour GetInputColour(Stage stage) => stage.Step switch
        {
            StageStep.YellowEdges or StageStep.YellowCorners => FaceColour.Yellow,
            StageStep.MiddleLayerEdges => stage.SubStep switch
            {
                0 => FaceColour.Green,
                1 => FaceColour.Orange,
                2 => FaceColour.Blue,
                3 => FaceColour.Red,
                _ => throw new ArgumentOutOfRangeException(nameof(stage), stage.SubStep, Stage.SubStepOutOfRangeExceptionMessage)
            },
            _ => throw new InvalidOperationException($"The last layer stages (currently {GetName(stage)}) do not have input colours")
        };

        public static string GetInstructions(Stage stage)
        {
            if (stage.Step == StageStep.LastLayer)
                throw new InvalidOperationException($"The last layer stages (currently {GetName(stage)}) do not have instructions");
            return $"Input the position of the {GetInputColour(stage).ToString().ToLower()} square on the {GetRequiredPieceName(stage)}";
        }
    }
}

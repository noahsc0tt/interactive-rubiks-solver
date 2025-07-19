using System;

namespace Rubiks_Cube_Solver.Solver.Util
{
    internal static class StageInfo
    {
        public static (StageStep Step, int SubStep) GetStageTuple(Stage stage) => (stage.Step, stage.SubStep);

        public static string GetName(Stage stage) =>
            stage.Step == StageStep.LastLayer ? GetStepName(stage) : $"{GetStepName(stage)} - {GetRequiredPiece(stage)}";

        private static string GetStepName(Stage stage) => stage.Step switch
        {
            StageStep.YellowEdges => "Yellow Cross",
            StageStep.YellowCorners => "Yellow Corners",
            StageStep.MiddleLayerEdges => "Middle Layer Edges",
            StageStep.LastLayer => "Top Layer",
            _ => throw new ArgumentException($"Invalid stage step: {stage.Step}")
        };

        public static string GetRequiredPiece(Stage stage)
        {
            (StageStep step, int subStep) = GetStageTuple(stage);
            return step switch
            {
                StageStep.YellowEdges => $"yellow and {subStep switch
                {
                    0 => "green",
                    1 => "orange",
                    2 => "blue",
                    3 => "red"
                }} edge",
                StageStep.YellowCorners => $"yellow, {GetColourPair(subStep)} corner",
                StageStep.MiddleLayerEdges => $"{GetColourPair(subStep)} edge",
                _ => throw new InvalidOperationException($"The last layer stages (currently {step}.{subStep}) do not have required pieces")
            };
        }

        //helper method for GetRequiredPiece
        private static string GetColourPair(int subStep) => subStep switch
        {
            0 => "green and red",
            1 => "orange and green",
            2 => "blue and orange",
            3 => "red and blue",
        };

        public static string GetFrontFaceName(Stage stage) => stage.SubStep switch
        {
            0 => "green",
            1 => "orange",
            2 => "blue",
            3 => "red"
        };

        public static FaceColour GetInputColour(Stage stage) => stage.Step switch
        {
            StageStep.YellowEdges or StageStep.YellowCorners => FaceColour.Yellow,
            StageStep.MiddleLayerEdges => stage.SubStep switch
            {
                0 => FaceColour.Green,
                1 => FaceColour.Orange,
                2 => FaceColour.Blue,
                3 => FaceColour.Red
            },
            _ => throw new InvalidOperationException($"The last layer stages (currently {stage.Step}.{stage.SubStep}) do not have input colours")
        };

        public static string GetInstructions(Stage stage) =>
            $"Input the position of the {GetInputColour(stage).ToString().ToLower()} square on the {GetRequiredPiece(stage)}";
    }
}

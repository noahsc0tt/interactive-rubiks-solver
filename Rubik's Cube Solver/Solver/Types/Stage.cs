using System;

namespace Rubiks_Cube_Solver.Solver
{
    internal enum StageStep 
    {
        YellowEdges,
        YellowCorners,
        MiddleLayerEdges,
        LastLayer
    }

    internal class Stage
    {
        public const StageStep MaxStep = StageStep.LastLayer;
        public const int MinSubStep = 0;
        public const int MaxSubStep = 3;
        public static readonly (StageStep, int) MaxStage = (MaxStep, MaxSubStep);
        public StageStep Step { get; private set; }
        public int SubStep { get; private set; }
        
        
        public Stage() : this(StageStep.YellowEdges, MinSubStep) { }

        public Stage(StageStep step, int subStep)
        {            
            Step = step;
            ValidateSubStep(subStep);
            SubStep = subStep;
        }

        private static void ValidateSubStep(int subStep)
        {
            if (subStep < MinSubStep || subStep > MaxSubStep)
                throw new ArgumentOutOfRangeException("subStep", $"subStep must be in the range {MinSubStep}-{MaxSubStep}");
        }

        public void Increment()
        {
            if (SubStep < MaxSubStep)
                SubStep++;
            else if (Step < MaxStep)
            {
                Step++;
                SubStep = MinSubStep;
            }
            else
                throw new InvalidOperationException($"Stage is already at maximum: {MaxStage}");
        }
    }

    internal static class StageInfo 
    {
        public static(StageStep Step, int SubStep) GetStageTuple(Stage stage) => (stage.Step, stage.SubStep);
        
        public static string GetName(Stage stage) => 
            stage.Step == StageStep.LastLayer ? GetStepName(stage) : $"{GetStepName(stage)} - {GetRequiredPiece(stage)}";

        private static string GetStepName(Stage stage) => stage.Step switch
        {
            StageStep.YellowEdges => "Yellow Cross",
            StageStep.YellowCorners => "Yellow Corners",
            StageStep.MiddleLayerEdges => "Middle Layer Edges",
            StageStep.LastLayer => "Top Layer"
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
            _ => throw new InvalidOperationException("Last layer stages have no input")
        };

    }
}

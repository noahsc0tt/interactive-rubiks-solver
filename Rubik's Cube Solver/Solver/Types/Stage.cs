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
        public StageStep Step { get; private set; }
        public int SubStep { get; private set; }
        
        public const StageStep MaxStep = StageStep.LastLayer;
        public const int MinSubStep = 0;
        public const int MaxSubStep = 3;
        public static readonly (StageStep, int) MaxStage = (MaxStep, MaxSubStep);
        
        public Stage() : this(StageStep.YellowEdges, MinSubStep) { }

        public Stage(StageStep step, int subStep)
        {            
            ValidateArg(subStep, nameof(subStep));
            Step = step;
            SubStep = subStep;
        }

        private static void ValidateArg(int value, string paramName)
        {
            if (value < MinSubStep || value > MaxSubStep)
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be in the range {MinSubStep}-{MaxSubStep}");
        }

        public (StageStep Step, int SubStep) GetStage() => (Step, SubStep);
        
        public string GetName() => 
            Step == StageStep.LastLayer ? GetStepName() : $"{GetStepName()} - {GetRequiredPiece()}";

        private string GetStepName() => Step switch
        {
            StageStep.YellowEdges => "Yellow Cross",
            StageStep.YellowCorners => "Yellow Corners",
            StageStep.MiddleLayerEdges => "Middle Layer Edges",
            StageStep.LastLayer => "Top Layer"
        };

        public string GetRequiredPiece() => Step switch
        {
            StageStep.YellowEdges => $"yellow and {SubStep switch
            {
                0 => "green",
                1 => "orange",
                2 => "blue",
                3 => "red"
            }} edge",
            StageStep.YellowCorners => $"yellow, {GetColourPair()} corner",
            StageStep.MiddleLayerEdges => $"{GetColourPair()} edge",
            _ => throw new InvalidOperationException($"The last layer stages (currently {Step.ToString()}.{SubStep}) do not have required pieces")
        };

        //helper method for GetRequiredPiece
        private string GetColourPair() => SubStep switch
        {
            0 => "green and red",
            1 => "orange and green",
            2 => "blue and orange",
            3 => "red and blue",
        };

        public FaceColour GetInputColour() => Step switch
        {
            StageStep.YellowEdges or StageStep.YellowCorners => FaceColour.Yellow,
            StageStep.MiddleLayerEdges => SubStep switch
            {
                0 => FaceColour.Green,
                1 => FaceColour.Orange,
                2 => FaceColour.Blue,
                3 => FaceColour.Red
            },
            _ => throw new InvalidOperationException("Last layer stages have no input")
        };

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
}

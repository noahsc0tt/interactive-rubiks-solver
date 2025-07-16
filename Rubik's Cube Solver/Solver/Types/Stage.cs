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
        public int Step { get; private set; }
        public int SubStep { get; private set; }
        
        public static const int MinStep = 0;
        public static const int MaxStep = 3;
        public static const int MinSubStep = 0;
        public static const int MaxSubStep = 3;

        public Stage() : this(MinStep, MinSubStep) { }

        public Stage(int step, int subStep)
        {            
            ValidateArg(step, nameof(step));
            ValidateArg(subStep, nameof(subStep));
            Step = step;
            SubStep = subStep;
        }

        private static void ValidateArg(int value, string paramName)
        {
            if (value < MinStep || value > MaxStep)
                throw new ArgumentOutOfRangeException(paramName, $"Argument must be in the range {MinStep}-{MaxStep}");
        }

        public (int Step, int SubStep) GetStage() => (Step, SubStep);
        
        public string GetName() => 
            Step == MaxStep ? GetStepName() : $"{GetStepName()} - {GetRequiredPiece()}";

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
            _ => throw new InvalidOperationException($"The last layer stages (currently {Step}.{SubStep}) do not have required pieces")
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
                throw new InvalidOperationException($"Stage is already at maximum ({MaxStep},{MaxSubStep})");
        }
    }
}

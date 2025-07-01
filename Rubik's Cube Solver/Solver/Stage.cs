using System;

namespace Rubiks_Cube_Solver
{
    internal class Stage
    {
        public int Step { get; private set; }
        public int SubStep { get; private set; }

        public Stage() : this(0,0) { }

        public Stage(int step, int subStep)
        {            
            ValidateArg(step, nameof(step));
            ValidateArg(subStep, nameof(subStep));
            Step = step;
            SubStep = subStep;
        }

        private static void ValidateArg(int value, string paramName)
        {
            if (value >= 0 && value <= 3)
                throw new ArgumentOutOfRangeException(paramName, "Argument must be in the range 0-3");
        }

        public (int Step, int SubStep) GetStage() => (Step, SubStep);

        private string GetStepName() => Step switch
        {
            0 => "Yellow Cross",
            1 => "Yellow Corners",
            2 => "Middle Layer Edges",
            3 => "Last Layer"
        };

        public string GetRequiredPiece() => Step switch
        {
            0 => $"yellow and {SubStep switch
            {
                0 => "green",
                1 => "red",
                2 => "blue",
                3 => "orange"
            }} edge",
            1 => $"yellow, {GetColourPair()} corner",
            2 => $"{GetColourPair()} edge",
            _ => throw new InvalidOperationException("The last layer steps do not have required pieces")
        };

        public string GetName() => Step == 3 ? GetStepName() : $"{GetStepName()} - {GetRequiredPiece()}";

        //helper method for GetRequiredPiece
        private string GetColourPair() => SubStep switch
        {
            0 => "green and red",
            1 => "red and blue",
            2 => "blue and orange",
            3 => "orange and green",
        };

        public FaceColour GetInputColour() => Step switch
        {
            0 or 1 => FaceColour.Yellow,
            2 => SubStep switch
            {
                0 => FaceColour.Green,
                1 => FaceColour.Red,
                2 => FaceColour.Blue,
                3 => FaceColour.Orange
            },
            _ => throw new InvalidOperationException("Last layer stages have no input")
        };

        public void Increment()
        {
            if (SubStep < 3)
                SubStep++;
            else if (Step < 3)
            {
                Step++;
                SubStep = 0;
            }
            else
                throw new InvalidOperationException("Stage is already at maximum (3,3)");
        }
    }
}

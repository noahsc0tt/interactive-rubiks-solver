using System;
using System.Drawing;


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
            this.Step = step;
            this.SubStep = subStep;
        }
        private static bool IsArgValid(int arg) => arg >= 0 && arg <= 3;

        private static void ValidateArg(int value, string paramName)
        {
            if (!IsArgValid(value))
                throw new ArgumentOutOfRangeException(paramName, "Argument must be in the range 0-3");
        }

        public (int Step, int SubStep) GetStage() => (Step, SubStep);

        public string GetName()
        {
            if (Step > 2) return "Stage Name already in form";

            string stepName = Step switch
            {
                0 => "Yellow Cross",
                1 => "Yellow Corners",
                2 => "Middle Layer Edges"
            };

            string subStepName = Step switch
            {
                0 => $"yellow and {SubStep switch
                {
                    0 => "green",
                    1 => "red",
                    2 => "blue",
                    3 => "orange"
                }} edge",
                1 => $"yellow, {GetColourPair()} corner",
                2 => $"{GetColourPair()} edge"
            };
            return stepName + " - " + subStepName;
        }

        //helper method for GetName to reduce duplication
        private string GetColourPair() => SubStep switch
        {
            0 => "green and red",
            1 => "red and blue",
            2 => "blue and orange",
            3 => "orange and green"
        };

        public Color GetColour() => Step switch
        {
            0 or 1 => Color.Yellow,
            2 => SubStep switch
            {
                0 => Color.Green,
                1 => Color.Red,
                2 => Color.RoyalBlue,
                3 => Color.Orange
            },
            _ => Color.Gray // default colour since step 3 does not have colours
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

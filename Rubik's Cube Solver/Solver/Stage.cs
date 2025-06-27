using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Rubiks_Cube_Solver
{
    internal readonly struct StageInfo
    {
        public string Name { get; }
        public Color InputColour { get; }

        public StageInfo(string name, Color colour)
        {
            this.Name = name;
            InputColour = colour;
        }
    }
    internal class Stage
    {
        public static readonly ReadOnlyDictionary<(int Step, int SubStep), StageInfo> StageInfoDict =
            new ReadOnlyDictionary<(int Step, int SubStep), StageInfo>(new Dictionary<(int Step, int SubStep), StageInfo>
            {
                { new Stage(0, 0), new StageInfo("Cross", Color.Red) },
                { new Stage(1, 0), new StageInfo("F2L", Color.Green) },
                { new Stage(2, 0), new StageInfo("OLL", Color.Blue) },
                { new Stage(3, 0), new StageInfo("PLL", Color.Yellow) }
            });
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

        
        public int[] GetStage() => [Step, SubStep];

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

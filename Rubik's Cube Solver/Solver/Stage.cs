using System;

namespace Rubiks_Cube_Solver
{
    internal class Stage
    {
        public int step { get; private set; }
        public int subStep { get; private set; }

        public Stage() : this(0,0) { }

        public Stage(int step, int subStep)
        {
            if (!IsValid(step))
            {
                throw new ArgumentOutOfRangeException("step", "step must be in the range 0-3");
            }
            else if (!IsValid(subStep))
            {
                throw new ArgumentOutOfRangeException("subStep", "subStep must be in the range 0-3");
            }
            this.step = step;
            this.subStep = subStep;
        }

        private static bool IsValid(int arg) => arg >= 0 && arg <= 3;
        

        public int[] GetStage() => new int[] { step, subStep };

        public void Increment()
        {
            if (subStep < 3)
            {
                subStep++;
            }
            else if (step < 3)
            {
                step++;
                subStep = 0;
            }
            else
            {
                throw new InvalidOperationException("Stage is already at maximum (3,3)");
            }
        }
    }
}

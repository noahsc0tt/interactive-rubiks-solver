using System;

namespace Rubiks_Cube_Solver.Solver
{
    internal class Stage
    {
        private int step;
        private int subStep;

        public Stage()
        {
            new Stage(0, 0);
        }

        public Stage(int step, int subStep)
        {
            if (IsValid(step, subStep))
            {
                this.step = step;
                this.subStep = subStep;
            }
            else
            {
                throw new ArgumentOutOfRangeException(null, "Invalid stage arguments");
            }
        }
        
        private static bool IsValid(int step, int subStep) => 
            step >= 0 && step <= 3 && subStep >= 0 && subStep <= 3;
        

        public int[] GetStage() => new int[] { step, subStep };

        public void IncrementStage()
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
                throw new InvalidOperationException("Stage is already at maximum");
            }
        }
    }
}

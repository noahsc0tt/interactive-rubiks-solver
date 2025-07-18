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
        public static readonly Stage YellowEdges = new(StageStep.YellowEdges, Stage.MinSubStep);
        public static readonly Stage YellowCorners = new(StageStep.YellowCorners, Stage.MinSubStep);
        public static readonly Stage MiddleLayerEdges = new(StageStep.MiddleLayerEdges, Stage.MinSubStep);
        public static readonly Stage WhiteEdges = new(StageStep.LastLayer, 0);
        public static readonly Stage WhiteCorners = new(StageStep.LastLayer, 1);
        public static readonly Stage PermutingCorners = new(StageStep.LastLayer, 2);
        public static readonly Stage PermutingEdges = new(StageStep.LastLayer, 3);
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
}

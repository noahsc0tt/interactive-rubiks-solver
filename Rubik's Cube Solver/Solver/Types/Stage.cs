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

    internal record Stage
    {
        public const StageStep MaxStep = StageStep.LastLayer;
        public const int MinSubStep = 0;
        public const int MaxSubStep = 3;
        public static readonly (StageStep, int) MaxStage = (MaxStep, MaxSubStep);
        public static readonly Stage YellowEdges = new(StageStep.YellowEdges, MinSubStep);
        public static readonly Stage YellowCorners = new(StageStep.YellowCorners, MinSubStep);
        public static readonly Stage MiddleLayerEdges = new(StageStep.MiddleLayerEdges, MinSubStep);
        public static readonly Stage WhiteEdges = new(StageStep.LastLayer, 0);
        public static readonly Stage WhiteCorners = new(StageStep.LastLayer, 1);
        public static readonly Stage PermutingCorners = new(StageStep.LastLayer, 2);
        public static readonly Stage PermutingEdges = new(StageStep.LastLayer, 3);
        public StageStep Step { get; init; }
        public int SubStep { get; init; }
        
        // first stage as a default
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
                throw new ArgumentOutOfRangeException(nameof(subStep), $"{nameof(subStep)} must be in the range {MinSubStep}-{MaxSubStep}");
        }

        public static Stage Increment(Stage stage)
        {
            (StageStep step, int subStep) = (stage.Step, stage.SubStep);
            if (subStep < MaxSubStep)
                return stage with { SubStep = ++subStep };
            else if (step < MaxStep)
                return new Stage(++step, MinSubStep);
            else
                throw new InvalidOperationException($"Stage is already at maximum: {MaxStage}");
        }
    }
}
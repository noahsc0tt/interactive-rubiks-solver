using System;

namespace RubiksCubeSolver.Solver
{
    internal enum StageStep 
    {
        YellowEdges,
        YellowCorners,
        MiddleLayerEdges,
        LastLayer
    }

    /// <summary>
    /// Represents a stage in the Rubik's Cube solving process, made up of a step and substep.
    /// </summary>
    internal record Stage
    {
        public const StageStep MaxStep = StageStep.LastLayer;
        public const int MinSubStep = 0;
        public const int MaxSubStep = 3;
        public readonly static string SubStepOutOfRangeExceptionMessage = $"SubStep must be in the range {MinSubStep}-{MaxSubStep}";
        public const int WhiteEdgesSubStep = 0;
        public const int WhiteCornersSubStep = 1;
        public const int PermutingCornersSubStep = 2;
        public const int PermutingEdgesSubStep = 3;
        public static readonly Stage MinStage = new(StageStep.YellowEdges, MinSubStep);
        public static readonly Stage MaxStage = new(MaxStep, MaxSubStep);
        public static readonly Stage YellowEdges = new(StageStep.YellowEdges, MinSubStep);
        public static readonly Stage YellowCorners = new(StageStep.YellowCorners, MinSubStep);
        public static readonly Stage MiddleLayerEdges = new(StageStep.MiddleLayerEdges, MinSubStep);
        public static readonly Stage WhiteEdges = new(StageStep.LastLayer, WhiteEdgesSubStep);
        public static readonly Stage WhiteCorners = new(StageStep.LastLayer, WhiteCornersSubStep);
        public static readonly Stage PermutingCorners = new(StageStep.LastLayer, PermutingCornersSubStep);
        public static readonly Stage PermutingEdges = new(StageStep.LastLayer, PermutingEdgesSubStep);
        public StageStep Step { get; init; }
        public int SubStep { get; init; }
        
        public Stage(StageStep step, int subStep)
        {            
            Step = step;
            ValidateSubStep(subStep);
            SubStep = subStep;
        }

        private static void ValidateSubStep(int subStep)
        {
            if (subStep < MinSubStep || subStep > MaxSubStep)
                throw new ArgumentOutOfRangeException(nameof(subStep), subStep, SubStepOutOfRangeExceptionMessage);
        }

        public static Stage Increment(Stage stage)
        {
            (StageStep step, int subStep) = (stage.Step, stage.SubStep);
            if (subStep < MaxSubStep)
                // move to the next substep within the current step
                return stage with { SubStep = ++subStep };
            else if (step < MaxStep)
                // move to the start of the next step
                return new Stage(++step, MinSubStep);
            else
                throw new InvalidOperationException($"Stage is already at maximum: {MaxStage.GetTuple()}");
        }

        public (StageStep step, int subStep) GetTuple() =>
            (Step, SubStep);
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Rubiks_Cube_Solver
{
    using Dict = ImmutableDictionary<PieceConfig, PieceSolution>;
    using Entry = KeyValuePair<PieceConfig, PieceSolution>;
    internal static class SolvePiece
    {
        private static readonly Dict yellowEdgesDict;
        private static readonly Dict yellowCornersDict;
        private static readonly Dict middleLayerEdgesDict;

        private static Entry CreateCornerEntry((int, int, int) location, string sequence, string explanation) =>
            CreateEntry(location, PieceOrientation.Corner, sequence, explanation);

        private static Entry CreateEntry((int, int, int) location, PieceOrientation orientation, string sequence, string explanation) =>
            new Entry(new PieceConfig(location, orientation), new PieceSolution(sequence, explanation));

        public static Dict GetStageDict(Stage stage) =>
            stage.Step switch
            {
                0 => yellowEdgesDict,
                1 => yellowCornersDict,
                2 => middleLayerEdgesDict,
                _ => throw new InvalidOperationException("Last layer stages do not have PieceSolutions")
            };

        public static PieceSolution GetSolution(Stage stage, PieceConfig piece) =>
            GetStageDict(stage)[piece];
    }
}

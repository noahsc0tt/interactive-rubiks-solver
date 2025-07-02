using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Rubiks_Cube_Solver
{
    using Dict = ImmutableDictionary<PieceConfig, PieceSolution>;
    using Entry = KeyValuePair<PieceConfig, PieceSolution>;
    internal static class SolvePiece
    {
        private static readonly Dict yellowEdgesDict = ImmutableDictionary.CreateRange
            ([
                CreateEntry((0,0,1), PieceOrientation.Good, "L2, U', F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((0,0,1), PieceOrientation.Bad, "L', F'", "Bring the edge next to the correct slot. Insert it"),
                CreateEntry((0,1,0), PieceOrientation.Good, "F'", "Insert the edge into the correct slot"),
                CreateEntry((0,1,0), PieceOrientation.Bad, "L', U', L, F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((0,1,2), PieceOrientation.Good, "L, U', L', F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((0,1,2), PieceOrientation.Bad, "L2, F', L2", "Bring the edge next to the correct slot. Insert it"),
                CreateEntry((0,2,1), PieceOrientation.Good, "U', F2", "Position the edge above the correct slot. Insert it"),
                CreateEntry((0,2,1), PieceOrientation.Bad, "L, F', L'", "Bring the edge next to the correct slot. Insert it"),
                CreateEntry((1,0,0), PieceOrientation.Good, "Already Solved", "Already Solved"),
                CreateEntry((1,0,0), PieceOrientation.Bad, "F2, U', R', F, R", "Bring the edge to the top layer. Move it across. Bring it next to the correct slot. Insert it"),
                CreateEntry((1,0,2), PieceOrientation.Good, "B2, U2, F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((1,0,2), PieceOrientation.Bad, "B2, U, R', F, R", "Bring the edge to the top layer. Move it across. Bring it next to the correct slot. Insert it"),
                CreateEntry((1,2,0), PieceOrientation.Good, "F2", "Insert the edge into the correct slot"),
                CreateEntry((1,2,0), PieceOrientation.Bad, "U', R', F, R", "Move the edge across. Bring it next to the correct slot. Insert it"),
                CreateEntry((1,2,2), PieceOrientation.Good, "U2, F2", "Position the edge above the correct slot. Insert it"),
                CreateEntry((1,2,2), PieceOrientation.Bad, "U, R', F, R", "Move the edge across. Bring it next to the correct slot. Insert it"),
                CreateEntry((2,0,1), PieceOrientation.Good, "R2, U, F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((2,0,1), PieceOrientation.Bad, "R, U, F2", "Bring the edge next to the correct slot. Insert it"),
                CreateEntry((2,1,0), PieceOrientation.Good, "R, U, R', F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((2,1,0), PieceOrientation.Bad, "F", "Insert the edge into the correct slot"),
                CreateEntry((2,1,2), PieceOrientation.Good, "R', U, R, F2", "Bring the edge to the top layer. Position it above the correct slot. Insert it"),
                CreateEntry((2,1,2), PieceOrientation.Bad, "R2, F, R2", "Insert the edge into the correct slot"),
                CreateEntry((2,2,1), PieceOrientation.Good, "U, F2", "Position the edge above the correct slot. Insert it"),
                CreateEntry((2,2,1), PieceOrientation.Bad, "R', F, R", "Bring the edge next to the correct slot. Insert it"),
            ]);

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

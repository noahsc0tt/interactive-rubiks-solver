using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Rubiks_Cube_Solver.Solver.Util
{
    using Dict = ImmutableDictionary<PieceLocation, PieceSolution>;
    using Entry = KeyValuePair<PieceLocation, PieceSolution>;
    internal static class SolvePiece
    {

        private static readonly string[] yellowEdgesExplanations =
            [
                "Bring the edge to the top layer. Position it above the correct slot. Insert it.",
                "Bring the edge next to the correct slot. Insert it.",
                "Insert the edge into the correct slot. Insert it.",
                "Position the edge above the correct slot. Insert it.",
                "Bring the edge to the top layer. Move it across. Bring it next to the correct slot. Insert it.",
                "Move the edge across. Bring it next to the correct slot. Insert it."
            ];

        private static readonly string[] yellowCornersExplanations =
            [
                "Bring the corner to the top layer. Position it above the correct slot. ",
                "Position the corner above the correct slot. "
            ];

        private static readonly string[] middleLayerEdgesExplanations =
            [
                "Take the edge out of the incorrect slot. Re-insert the corner. Match the edge up with the corresponding corner. Insert the pair into the correct slot.",
                "Match the edge up with the corresponding corner. Insert the pair into the correct slot.",
                "Take the pair out of their slot. Match the edge up with the corner. Insert the pair into the correct slot."
            ];

        private static readonly Dict yellowEdgesDict = CreateDict
            ([
                ((0,0,1), PieceOrientation.Good, "L2, U', F2", yellowEdgesExplanations[0]),
                ((0,0,1), PieceOrientation.Bad, "L', F'", yellowEdgesExplanations[1]),
                ((0,1,0), PieceOrientation.Good, "L', U', L, F2", yellowEdgesExplanations[0]),
                ((0,1,0), PieceOrientation.Bad, "F'", yellowEdgesExplanations[2]),
                ((0,1,2), PieceOrientation.Good, "L, U', L', F2", yellowEdgesExplanations[0]),
                ((0,1,2), PieceOrientation.Bad, "L2, F', L2", yellowEdgesExplanations[1]),
                ((0,2,1), PieceOrientation.Good, "U', F2", yellowEdgesExplanations[3]),
                ((0,2,1), PieceOrientation.Bad, "L, F', L'", yellowEdgesExplanations[1]),
                ((1,0,0), PieceOrientation.Good, "Already Solved", "Already Solved."),
                ((1,0,0), PieceOrientation.Bad, "F2, U', R', F, R", yellowEdgesExplanations[4]),
                ((1,0,2), PieceOrientation.Good, "B2, U2, F2", yellowEdgesExplanations[0]),
                ((1,0,2), PieceOrientation.Bad, "B2, U, R', F, R", yellowEdgesExplanations[4]),
                ((1,2,0), PieceOrientation.Good, "F2", yellowEdgesExplanations[2]),
                ((1,2,0), PieceOrientation.Bad, "U', R', F, R", yellowEdgesExplanations[5]),
                ((1,2,2), PieceOrientation.Good, "U2, F2", yellowEdgesExplanations[3]),
                ((1,2,2), PieceOrientation.Bad, "U, R', F, R", yellowEdgesExplanations[5]),
                ((2,0,1), PieceOrientation.Good, "R2, U, F2", yellowEdgesExplanations[0]),
                ((2,0,1), PieceOrientation.Bad, "R, U, F2", yellowEdgesExplanations[1]),
                ((2,1,0), PieceOrientation.Good, "R, U, R', F2", yellowEdgesExplanations[0]),
                ((2,1,0), PieceOrientation.Bad, "F", yellowEdgesExplanations[2]),
                ((2,1,2), PieceOrientation.Good, "R', U, R, F2", yellowEdgesExplanations[0]),
                ((2,1,2), PieceOrientation.Bad, "R2, F, R2", yellowEdgesExplanations[2]),
                ((2,2,1), PieceOrientation.Good, "U, F2", yellowEdgesExplanations[3]),
                ((2,2,1), PieceOrientation.Bad, "R', F, R", yellowEdgesExplanations[1])
            ]);

        private static readonly Dict yellowCornersDict = CreateCornerDict
            ([
                ((0,0,0), "L', U', L. ", yellowCornersExplanations[0]),
                ((0,0,2), "L, U, L', U. ", yellowCornersExplanations[0]),
                ((0,2,0), "U'. ", yellowCornersExplanations[1]),
                ((0,2,2), "U2. ", yellowCornersExplanations[1]),
                ((2,0,0), "", ""),
                ((2,0,2), "R', U, R, U. ", yellowCornersExplanations[0]),
                ((2,2,0), "", ""),
                ((2,2,2), "U. ", yellowCornersExplanations[1])
            ]);
        private static readonly Dict middleLayerEdgesDict = CreateDict
            ([
                ((0,1,0), PieceOrientation.Good, "F, U', F', U', L', U, L, U2, R, U', R', U', F', U, F", middleLayerEdgesExplanations[0]),
                ((0,1,0), PieceOrientation.Bad, "F, U', F', U', L', U, L, U', F', U, F, U, R, U', R'", middleLayerEdgesExplanations[0]),
                ((0,1,2), PieceOrientation.Good, "B', U, B, U, L, U', L', U2, R, U', R', U', F', U, F", middleLayerEdgesExplanations[0]),
                ((0,1,2), PieceOrientation.Bad, "B', U, B, U, L, U', L', U', F', U, F, U, R, U', R'", middleLayerEdgesExplanations[0]),
                ((0,2,1), PieceOrientation.Good, "U, F', U, F, U, R, U', R'", middleLayerEdgesExplanations[1]),
                ((0,2,1), PieceOrientation.Bad, "R, U', R', U', F', U, F", middleLayerEdgesExplanations[1]),
                ((1,2,0), PieceOrientation.Good, "U2, F', U, F, U, R, U', R'", middleLayerEdgesExplanations[1]),
                ((1,2,0), PieceOrientation.Bad, "U, R, U', R', U', F', U, F", middleLayerEdgesExplanations[1]),
                ((1,2,2), PieceOrientation.Good, "F', U, F, U, R, U', R'", middleLayerEdgesExplanations[1]),
                ((1,2,2), PieceOrientation.Bad, "U', R, U', R', U', F', U, F", middleLayerEdgesExplanations[1]),
                ((2,1,0), PieceOrientation.Good, "Already solved.", "Already solved."),
                ((2,1,0), PieceOrientation.Bad, "R, U', R', U, F', U2, F, U2, F', U, F", middleLayerEdgesExplanations[2]),
                ((2,1,2), PieceOrientation.Good, "B, U', B', U', R', U, R, R, U', R', U', F', U, F", middleLayerEdgesExplanations[0]),
                ((2,1,2), PieceOrientation.Bad, "B, U', B', U', R', U, R, U, F', U, F, U, R, U', R'", middleLayerEdgesExplanations[0]),
                ((2,2,1), PieceOrientation.Good, "U', F', U, F, U, R, U', R'", middleLayerEdgesExplanations[1]),
                ((2,2,1), PieceOrientation.Bad, "U2, R, U', R', U', F', U, F", middleLayerEdgesExplanations[1]),
            ]);

        private static Entry CreateEntry(((int, int, int) location, PieceOrientation orientation, string sequence, string explanation) entry) =>
            new(new PieceLocation(entry.location, entry.orientation), new PieceSolution(entry.sequence, entry.explanation));

        private static Dict CreateCornerDict(((int, int, int) location, string sequence, string explanation)[] entries) =>
            CreateDict(entries.Select(entry =>
            (entry.location, PieceOrientation.Corner,
                entry.sequence + "Repeat the moves (R, U, R', U') until the yellow square is pointing down.",
                entry.explanation + "Cycle the corner until it is solved.")).ToArray());

        private static Dict CreateDict(((int, int, int) location, PieceOrientation orientation, string sequence, string explanation)[] entries) =>
            ImmutableDictionary.CreateRange(entries.Select(CreateEntry));

        public static Dict GetStageDict(Stage stage) =>
            stage.Step switch
            {
                StageStep.YellowEdges => yellowEdgesDict,
                StageStep.YellowCorners => yellowCornersDict,
                StageStep.MiddleLayerEdges => middleLayerEdgesDict,
                _ => throw new InvalidOperationException($"Last layer stages (currently {stage.Step.ToString()}.{stage.SubStep}) do not have PieceSolutions")
            };

        public static PieceSolution GetSolution(Stage stage, PieceLocation piece) =>
            GetStageDict(stage).TryGetValue(piece, out PieceSolution solution) ? solution :
                throw new ArgumentException($"No solution found for piece {piece.Coords.ToString()}, {piece.Orientation.ToString()}");
    }
}

using System;

namespace Rubiks_Cube_Solver.Solver
{
    internal enum PieceOrientation
    {
        Good, Bad, Corner
    }

    internal static class OrientationFlipExtension
    {
        public static PieceOrientation Flip(this PieceOrientation originalOrientation) => originalOrientation switch
        {
            PieceOrientation.Good => PieceOrientation.Bad,
            PieceOrientation.Bad => PieceOrientation.Good,
            PieceOrientation.Corner => PieceOrientation.Corner,
            _ => throw new ArgumentException($"Invalid orientation: {originalOrientation}", nameof(originalOrientation))
        };
    }
}

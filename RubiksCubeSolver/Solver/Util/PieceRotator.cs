using System;

namespace RubiksCubeSolver.Solver.Util
{
    /// <summary>
    /// Provides logic for rotating the user's piece, so it can be solved relative to the correct faces.
    /// </summary>
    internal static class PieceRotator
    {
        /// <summary>
        /// Simulates a y' rotation move and returns the new PieceLocation. Complex 3D cube logic.
        /// </summary>
        private static PieceLocation YPrimeMove(PieceLocation initialLocation)
        {
            (int x, int y, int z) = initialLocation.Coords.GetLocation();
            PieceOrientation orientation = initialLocation.Orientation;

            if (x == 1 || y == 1 || z == 1) // if the piece is an edge
            {
                if (y == 1) orientation = orientation.Flip();
                (x, z) = y switch
                {
                    0 => z switch
                    {
                        0 => (2, 1),
                        1 => (z, x),
                        2 => (0, 1),
                        _ => throw new ArgumentOutOfRangeException(PieceCoords.CoordinateOutOfRangeExceptionMessage, nameof(z))
                    },
                    1 => (z == 0) ? (2, x) : (0, x),
                    2 => (x == 1) ? (z == 2 ? 0 : 2, 1) : (z, x),
                    _ => throw new ArgumentOutOfRangeException(PieceCoords.CoordinateOutOfRangeExceptionMessage, nameof(y))
                };
            }
            else // if the piece is a corner
                (x, z) = (z == 2 ? 0 : 2, x);

            return new PieceLocation((x, y, z), orientation);
        }

        /// <summary>
        /// Rotates the piece the correct number of times, so that it can be solved relative to the correct faces
        /// </summary>
        public static PieceLocation RotatePiece(PieceLocation piece, Stage stage)
        {
            for (int i = 0; i < stage.SubStep; i++)
                piece = YPrimeMove(piece);
            return piece;
        }
    }
}

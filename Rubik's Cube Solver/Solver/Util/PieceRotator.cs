namespace Rubiks_Cube_Solver.Solver.Util
{
    internal static class PieceRotator
    {
        private static PieceLocation YPrimeMove(PieceLocation initialLocation)
        {
            (int x, int y, int z) = initialLocation.Coords.GetLocation();
            PieceOrientation orientation = initialLocation.Orientation;

            //checking if the piece is an edge
            if (x == 1 || y == 1 || z == 1)
            {
                if (y == 1) orientation = orientation.Flip();
                (x, z) = y switch
                {
                    0 => z switch
                    {
                        0 => (2, 1),
                        1 => (z, x),
                        2 => (0, 1)
                    },
                    1 => (z == 0) ? (2, x) : (0, x),
                    2 => (x == 1) ? (z == 2 ? 0 : 2, 1) : (z, x),
                };
            }
            else //if the piece is a corner
                (x, z) = (z == 2 ? 0 : 2, x);

            return new PieceLocation((x, y, z), orientation);
        }
        public static PieceLocation RotatePiece(PieceLocation piece, Stage stage)
        {
            // rotating the piece the correct number of times, so that it can be solved relative to its centre piece
            for (int i = 0; i < stage.SubStep; i++)
                piece = YPrimeMove(piece);
            return piece;
        }
    }
}

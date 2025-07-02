namespace Rubiks_Cube_Solver
{
    internal static class RotatePiece
    {
        public static PieceConfig AntiClockwise(PieceConfig initialConfig)
        {
            (int x, int y, int z) = initialConfig.Location.GetLocation();
            PieceOrientation orientation = initialConfig.Orientation;

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
                    2 => (x == 1) ? (z == 2 ? 0 : 2, 1) : (z, x)
                };
            }
            else //if the piece is a corner
                (x, z) = (z == 2 ? 0 : 2, x);

            return new PieceConfig((x, y, z), orientation);
        }
    }
}

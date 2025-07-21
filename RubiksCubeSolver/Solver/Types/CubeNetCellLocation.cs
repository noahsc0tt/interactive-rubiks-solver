namespace RubiksCubeSolver.Solver
{
    /// <summary>
    /// Represents the two-dimensional position of a cell on a Rubik's Cube net.
    /// </summary>
    internal readonly record struct CubeNetCellLocation
    {
        public const int MinCoordValue = 0;
        public const int MaxCoordValue = 2;
        public int X { get; }
        public int Y { get; }
        public FaceColour Face { get; }

        public CubeNetCellLocation(FaceColour face, (int x, int y) coords)
        {
            (int x, int y) = coords;
            Util.CoordValidator.ValidateCoords(MinCoordValue, MaxCoordValue, (x, nameof(x)), (y, nameof(y)));
            X = x;
            Y = y;
            Face = face;
        }
    }
}
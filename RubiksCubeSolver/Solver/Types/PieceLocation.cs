namespace RubiksCubeSolver.Solver
{
    using Util;
    internal readonly record struct PieceCoords
    {
        public const int Min = 0;
        public const int Max = 2;
        public readonly static string CoordinateOutOfRangeExceptionMessage = CoordValidator.GetOutOfRangeExceptionMessage(Min, Max);
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public PieceCoords((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
        public PieceCoords(int x, int y, int z)
        {
            CoordValidator.ValidateCoords(Min, Max, (x, nameof(x)), (y, nameof(y)), (z, nameof(z)));
            X = x;
            Y = y;
            Z = z;
        }

        public (int X, int Y, int Z) GetLocation() => (X, Y, Z);
    }

    internal readonly record struct PieceLocation(PieceCoords Coords, PieceOrientation Orientation)
    {
        public PieceLocation((int, int, int) location, PieceOrientation orientation) :
            this(new PieceCoords(location), orientation) { }
    }
}
namespace Rubiks_Cube_Solver.Solver
{
    internal readonly record struct PieceCoords
    {
        public const int MinCoord = 0;
        public const int MaxCoord = 2;
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public PieceCoords((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
        public PieceCoords(int x, int y, int z)
        {
            Util.CoordValidator.ValidateCoords(MinCoord, MaxCoord, (x, nameof(x)), (y, nameof(y)), (z, nameof(z)));
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
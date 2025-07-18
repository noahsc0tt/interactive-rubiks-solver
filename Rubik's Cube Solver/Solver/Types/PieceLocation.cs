namespace Rubiks_Cube_Solver.Solver
{
    internal class PieceLocation(PieceLocation.PieceCoords location, PieceOrientation orientation)
    {
        internal class PieceCoords
        {
            public const int MinCoord = 0;
            public const int MaxCoord = 2;
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Z { get; private set; }

            public PieceCoords((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
            public PieceCoords(int x, int y, int z)
            {
                Util.CoordValidator.ValidateCoords(MinCoord, MaxCoord, (x, nameof(x)), (y, nameof(y)), (z, nameof(z)));
                X = x;
                Y = y;
                Z = z;
            }

            public (int X, int Y, int Z) GetLocation() => (X, Y, Z);

            public override bool Equals(object obj) =>
                (obj is PieceCoords other) && (X, Y, Z) == (other.X, other.Y, other.Z);

            public override int GetHashCode() =>
                // using hash of ValueTuple
                (X, Y, Z).GetHashCode();
        }

        public PieceCoords Coords { get; } = location;
        public PieceOrientation Orientation { get; } = orientation;

        public PieceLocation((int, int, int) location, PieceOrientation orientation) :
            this(new PieceCoords(location), orientation) { }

        public override bool Equals(object obj) =>
            (obj is PieceLocation other) && Orientation == other.Orientation && Coords.Equals(other.Coords);

        public override int GetHashCode() =>
            // using hash of ValueTuple
            (Orientation, Coords).GetHashCode();
    }
}
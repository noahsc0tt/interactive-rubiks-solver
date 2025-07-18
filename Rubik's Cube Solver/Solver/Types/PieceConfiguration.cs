namespace Rubiks_Cube_Solver.Solver
{
    internal class PieceConfiguration
    {
        internal class PieceLocation
        {
            public const int MinCoord = 0;
            public const int MaxCoord = 2;
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Z { get; private set; }

            public PieceLocation((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
            public PieceLocation(int x, int y, int z)
            {
                Util.CoordValidator.ValidateCoords(MinCoord, MaxCoord, (x, nameof(x)), (y, nameof(y)), (z, nameof(z)));
                X = x;
                Y = y;
                Z = z;
            }

            public (int X, int Y, int Z) GetLocation() => (X, Y, Z);

            public override bool Equals(object obj) =>
                (obj is PieceLocation other) && (X, Y, Z) == (other.X, other.Y, other.Z);

            public override int GetHashCode() =>
                // using hash of ValueTuple
                (X, Y, Z).GetHashCode();
        }

        public PieceLocation Location { get; private set; }
        public PieceOrientation Orientation { get; private set; }

        public PieceConfiguration((int, int, int) location, PieceOrientation orientation) :
            this(new PieceLocation(location), orientation) { }
        public PieceConfiguration(PieceLocation location, PieceOrientation orientation)
        {
            Orientation = orientation;
            Location = location;
        }

        public override bool Equals(object obj) =>
            (obj is PieceConfiguration other) && Orientation == other.Orientation && Location.Equals(other.Location);

        public override int GetHashCode() =>
            // using hash of ValueTuple
            (Orientation, Location).GetHashCode();
    }
}
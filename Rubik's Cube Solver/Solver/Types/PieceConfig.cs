namespace Rubiks_Cube_Solver.Solver
{
    internal enum PieceOrientation
    {
        Good, Bad, Corner
    }

    internal static class OrientationFlipExtension
    {
        public static PieceOrientation Flip(this PieceOrientation original) => original switch
        {
            PieceOrientation.Good => PieceOrientation.Bad,
            PieceOrientation.Bad => PieceOrientation.Good,
            PieceOrientation.Corner => PieceOrientation.Corner
        };
    }

    internal class PieceLocation
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public const int Min = 0;
        public const int Max = 2;

        public PieceLocation((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
        public PieceLocation(int x, int y, int z)
        {
            Util.CoordValidator.ValidateCoords(Min, Max, (x, nameof(x)), (y, nameof(y)), (z, nameof(z)));
            X = x;
            Y = y;
            Z = z;
        }

        public (int X, int Y, int Z) GetLocation() => (X, Y, Z);

        public override bool Equals(object obj) =>
            (obj is PieceLocation other) && (X,Y,Z) == (other.X, other.Y, other.Z);

        public override int GetHashCode() =>
            // using hash of ValueTuple
            (X, Y, Z).GetHashCode();
    }

    internal class PieceConfig
    {
        public PieceLocation Location { get; private set; }
        public PieceOrientation Orientation { get; private set; }

        public PieceConfig((int, int, int) location, PieceOrientation orientation) :
            this(new PieceLocation(location), orientation) { }
        public PieceConfig(PieceLocation location, PieceOrientation orientation)
        {
            Orientation = orientation;
            Location = location;
        }

        public override bool Equals(object obj) =>
            (obj is PieceConfig other) && Orientation == other.Orientation && Location.Equals(other.Location);

        public override int GetHashCode() =>
            // using hash of ValueTuple
            (Orientation, Location).GetHashCode();
    }
}
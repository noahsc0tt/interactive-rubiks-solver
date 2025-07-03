using System;

namespace Rubiks_Cube_Solver
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
        private int _x;
        private int _y;
        private int _z;

        public int X
        {
            get => _x;
            set
            {
                CoordValidator.ValidateCoord(value, nameof(X), 0, 2);
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                CoordValidator.ValidateCoord(value, nameof(Y), 0, 2);
                _y = value;
            }
        }

        public int Z
        {
            get => _z;
            set
            {
                CoordValidator.ValidateCoord(value, nameof(Z), 0, 2);
                _z = value;
            }
        }
        public PieceLocation((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
        public PieceLocation(int x, int y, int z)
        {
            CoordValidator.ValidateCoords([(x, nameof(x)), (y, nameof(y)), (x, nameof(x))], 0, 2);
            _x = x;
            _y = y;
            _z = z;
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
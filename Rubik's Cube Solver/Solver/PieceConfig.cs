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
                ValidateCoord(value, nameof(X));
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                ValidateCoord(value, nameof(Y));
                _y = value;
            }
        }

        public int Z
        {
            get => _z;
            set
            {
                ValidateCoord(value, nameof(Z));
                _z = value;
            }
        }
        public PieceLocation((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
        public PieceLocation(int x, int y, int z)
        {
            ValidateCoord(x, nameof(x));
            ValidateCoord(y, nameof(y));
            ValidateCoord(z, nameof(z));
            _x = x;
            _y = y;
            _z = z;
        }
        private static bool IsCoordValid(int coord) => coord >= 0 && coord <= 2;

        public static void ValidateCoord(int coord, string paramName)
        {
            if (!IsCoordValid(coord))
                throw new ArgumentOutOfRangeException(paramName, "Coordinate must be in the range 0-2");
        }
        public (int X, int Y, int Z) GetLocation() => (X, Y, Z);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            PieceLocation other = (PieceLocation)obj;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override int GetHashCode()
        {
            // using hash of ValueTuple
            return (X, Y, Z).GetHashCode();
        }

    }

    internal class PieceConfig
    {
        public PieceOrientation Orientation { get; set; }
        public PieceLocation Location { get; set; }

        public PieceConfig (PieceOrientation orientation, PieceLocation location)
        {
            Orientation = orientation;
            Location = location;
        }
    }
}
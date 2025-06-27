using System;

namespace Rubiks_Cube_Solver
{
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

        private static void ValidateCoord(int coord, string paramName)
        {
            if (!IsCoordValid(coord))
                throw new ArgumentOutOfRangeException(paramName, "Coordinate must be in the range 0-2");
        }
        public (int X, int Y, int Z) GetLocation() => (X, Y, Z);
    }
}
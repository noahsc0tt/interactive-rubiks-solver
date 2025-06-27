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
                ValidateArg(value, nameof(X));
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                ValidateArg(value, nameof(Y));
                _y = value;
            }
        }

        public int Z
        {
            get => _z;
            set
            {
                ValidateArg(value, nameof(Z));
                _z = value;
            }
        }
        public PieceLocation((int x, int y, int z) location) : this(location.x, location.y, location.z) { }
        public PieceLocation(int x, int y, int z)
        {
            ValidateArg(x, nameof(x));
            ValidateArg(y, nameof(y));
            ValidateArg(z, nameof(z));
            _x = x;
            _y = y;
            _z = z;
        }
        private static bool IsArgValid(int coord) => coord >= 0 && coord <= 2;

        private static void ValidateArg(int coord, string paramName)
        {
            if (!IsArgValid(coord))
                throw new ArgumentOutOfRangeException(paramName, "Coordinate must be in the range 0-2");
        }
        public (int X, int Y, int Z) GetLocation() => (X, Y, Z);
    }
}
using System;

namespace Rubiks_Cube_Solver
{
    internal class PieceLocation
    {
        public int X { get; private set; }
        public int Y { get; private set;}
        public int Z { get; private set;}
        public PieceLocation(int x, int y, int z)
        {
            ValidateArg(x, nameof(x));
            ValidateArg(y, nameof(y));
            ValidateArg(z, nameof(z));
            X = x;
            Y = y;
            Z = z;
        }
        private static bool IsArgValid(int coord) => coord >= 0 && coord <= 2;

        private static void ValidateArg(int coord, string paramName)
        {
            if (!IsArgValid(coord))
                throw new ArgumentOutOfRangeException(paramName, "Coordinate must be in the range 0-2");
        }

        public void setX(int x)
        {
            ValidateArg(x, nameof(x));
            X = x;
        }
        public void setY(int y)
        {
            ValidateArg(y, nameof(y));
            Y = y;
        }
        public void setZ(int z)
        {
            ValidateArg(z, nameof(z));
            Z = z;
        }

        public int[] GetLocation() => [ X, Y, Z];
    }
}
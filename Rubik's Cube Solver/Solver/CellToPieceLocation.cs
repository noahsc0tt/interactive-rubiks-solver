using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_Cube_Solver
{
    internal class CubeNetLocation
    {
        public readonly int X;
        public readonly int Y;
        public readonly Color Face;

        public CubeNetLocation((int x, int y) location, Color face) : this(location.x, location.y, face) { }
        public CubeNetLocation(int x, int y, Color face)
        {
            ValidateArg(x, nameof(x));
            ValidateArg(y, nameof(y));
            X = x;
            Y = y;
            Face = face;
        }
        private static bool IsCoordValid(int coord) => coord >= 0 && coord <= 2;

        private static void ValidateArg(int coord, string paramName)
        {
            if (!IsCoordValid(coord))
                throw new ArgumentOutOfRangeException(paramName, "Coordinate must be in the range 0-2");
        }
        public (int X, int Y, Color Face) GetLocation() => (X, Y, Face);
    }

}

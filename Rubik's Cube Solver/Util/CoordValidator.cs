using System;
using System.Linq;

namespace Rubiks_Cube_Solver
{
    internal static class CoordValidator
    {
        private static bool IsCoordValid(int coord, int min, int max) =>
            coord >= min && coord <= max;

        public static void ValidateCoord(int coord, string coordName, int min, int max)
        {
            if (!IsCoordValid(coord, min, max))
                throw new ArgumentOutOfRangeException(coordName, $"Coordinate must be in the range {min}-{max}");
        }

        public static void ValidateCoords((int value, string name)[] coords, int min, int max)
        {
            foreach (var coord in coords)
                ValidateCoord(coord.value, coord.name, min, max);
        }

    }
}

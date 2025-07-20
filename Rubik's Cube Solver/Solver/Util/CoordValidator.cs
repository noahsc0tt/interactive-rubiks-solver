using System;
using System.Linq;

namespace Rubiks_Cube_Solver.Solver.Util
{
    internal static class CoordValidator
    {
        public static bool IsCoordValid(int min, int max, int coord) =>
            coord >= min && coord <= max;

        public static bool AreCoordsValid(int min, int max, params int[] coords) =>
            coords.All(coord => IsCoordValid(min, max, coord));

        public static void ValidateCoord(int min, int max, int coord, string coordName)
        {
            if (!IsCoordValid(min, max, coord))
                throw new ArgumentOutOfRangeException(coordName, coord, $"Coordinate must be in the range {min}-{max}");
        }

        public static void ValidateCoords(int min, int max, params (int value, string name)[] coords)
        {
            foreach (var (value, name) in coords)
                ValidateCoord(min, max, value, name);
        }

    }
}

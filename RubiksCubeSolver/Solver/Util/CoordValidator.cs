using System;
using System.Linq;

namespace RubiksCubeSolver.Solver.Util
{
    /// <summary>
    /// Utility class for validating coordinate values.
    /// </summary>
    internal static class CoordValidator
    {
        public static string GetOutOfRangeExceptionMessage(int min, int max) => 
            $"Coordinate must be in the range {min}-{max}";

        public static bool IsCoordValid(int min, int max, int coord) =>
            coord >= min && coord <= max;

        public static void ValidateCoord(int min, int max, int coord, string coordName)
        {
            if (!IsCoordValid(min, max, coord))
                throw new ArgumentOutOfRangeException(coordName, coord, GetOutOfRangeExceptionMessage(min, max));
        }

        public static void ValidateCoords(int min, int max, params (int value, string name)[] coords)
        {
            foreach (var (value, name) in coords)
                ValidateCoord(min, max, value, name);
        }
    }
}

using System;

namespace Rubiks_Cube_Solver
{
    internal static class CoordValidator
    {
        private static bool IsValid(int coord, int min, int max) =>
            coord >= min && coord <= max;

        public static void Validate(int coord, string coordName, int min, int max)
        {
            if (!IsValid(coord, min, max))
                throw new ArgumentOutOfRangeException(coordName, $"Coordinate must be in the range {min}-{max}");
        }

    }
}

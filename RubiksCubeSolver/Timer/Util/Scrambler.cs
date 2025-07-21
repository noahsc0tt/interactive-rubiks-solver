using System;

namespace RubiksCubeSolver.Timer.Util
{
    /// <summary>
    /// Generates random Rubik's Cube scrambles.
    /// </summary>
    internal static class Scrambler
    {
        private const int length = 20;
        private static readonly string[] faces = ["U", "D", "F", "B", "L", "R"];
        private static readonly string[] suffixes = [ "", "'", "2" ];
        private static readonly Random random = new();

        public static string GetScramble()
        {
            string[] moves = new string[length];
            char secondToLastFace = default, lastFace = default;

            for (int i = 0; i < length; i++)
            {
                string nextMove;
                char nextFace;
                do // making sure three consecutive moves are on different faces
                {  // avoids redundant sequences such as U, U' or U, D, U'
                    nextMove = GetMove();
                    nextFace = nextMove[0];
                }
                while (nextFace == secondToLastFace || nextFace == lastFace);

                moves[i] = nextMove;
                (secondToLastFace, lastFace) = (lastFace, nextFace);
            }
            return string.Join(", ", moves);
        }

        private static string GetMove() =>
            faces[random.Next(faces.Length)] + suffixes[random.Next(suffixes.Length)];
    }
}
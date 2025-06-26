using System;

namespace Rubiks_Cube_Solver
{
    internal static class Scrambler
    {
        private static readonly string[] faces = { "U", "D", "F", "B", "L", "R" };
        private static readonly string[] suffixes = { "", "'", "2" };
        private static readonly Random random = new Random();
        private static readonly int length = 20;

        public static string GetScramble()
        {
            string scramble = "";
            char lastFace = '\0';
            string nextMove;

            for (int i = 0; i < length; i++)
            {
                do
                {
                    nextMove = GetMove();
                } while (nextMove[0] == lastFace); //making sure consecutive moves are on different faces

                if (i > 0) scramble += ", ";
                scramble += nextMove;
                lastFace = nextMove[0];
            }

            return scramble;
        }

        private static string GetMove()
        {
            return faces[random.Next(faces.Length)] + suffixes[random.Next(suffixes.Length)];
        }
    }
}

using System;

namespace Rubiks_Cube_Solver
{
    internal static class Scrambler
    {
        private static readonly string[] faces = { "U", "D", "F", "B", "L", "R" };
        private static readonly string[] suffixes = { "", "'", "2" };
        private static readonly Random random = new();
        private const int length = 20;

        public static string GetScramble()
        {
            string[] moves = new string[length];
            (char, char) lastTwoFaces = ('\0', '\0');

            for (int i = 0; i < length; i++)
            {
                string nextMove;
                do //making sure three consecutive moves are on different faces
                    nextMove = GetMove();
                while (nextMove[0] == lastTwoFaces.Item1 || nextMove[0] == lastTwoFaces.Item2); 

                moves[i] = nextMove;
                lastTwoFaces = (lastTwoFaces.Item2, nextMove[0]);
            }
            return string.Join(", ", moves);
        }

        private static string GetMove() => 
            faces[random.Next(faces.Length)] + suffixes[random.Next(suffixes.Length)];
        
    }
}

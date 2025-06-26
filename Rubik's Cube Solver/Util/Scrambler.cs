using System;

namespace Rubiks_Cube_Solver
{
    internal static class Scrambler
    {
        public static string getScramble()
        {
            Random random = new Random();

            string scramble = Scrambler.getMove(random);
            string lastMove = scramble;
            string nextMove;

            //generating 20 random moves
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    nextMove = Scrambler.getMove(random);

                } while (nextMove.Substring(0, 1) == lastMove.Substring(0, 1)); //making sure consecutive moves are on different faces

                scramble += ", " + nextMove;
                lastMove = nextMove;
            }

            return scramble;
        }

        private static string getMove(Random random)
        {
            //arrays of possible moves
            string[] moves = { "U", "D", "F", "B", "L", "R" };
            string[] suffixes = { "", "'", "2" };
            return moves[random.Next(moves.Length)] + suffixes[random.Next(suffixes.Length)];
        }
    }
}

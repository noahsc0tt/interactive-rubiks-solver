namespace Rubiks_Cube_Solver
{
    internal class PieceSolution
    {
        public string Sequence { get; private set; }
        public string Explanation { get; private set; }

        public PieceSolution(string sequence, string explanation) =>
            (Sequence, Explanation) = (sequence, explanation);
    }
}

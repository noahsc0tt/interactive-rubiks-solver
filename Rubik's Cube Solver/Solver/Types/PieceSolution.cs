namespace Rubiks_Cube_Solver
{
    internal class PieceSolution
    {
        public string Sequence { get; set; }
        public string Explanation { get; set; }

        public PieceSolution(string sequence, string explanation) =>
            (Sequence, Explanation) = (sequence, explanation);
    }
}

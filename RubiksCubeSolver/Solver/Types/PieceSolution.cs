namespace RubiksCubeSolver.Solver
{
    /// <summary>
    /// Represents the solution for a Rubik's Cube piece to be output.
    /// </summary>
    internal readonly record struct PieceSolution(string Sequence, string Explanation) { }
}
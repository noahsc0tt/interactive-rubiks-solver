using System.Windows.Forms;

namespace RubiksCubeSolver.Solver
{
    using Face = DataGridView;
    
    /// <summary>
    /// Stores the DataGridView faces of a UI Rubik's Cube net.
    /// </summary>
    internal record CubeNetFaces(Face White, Face Yellow, Face Green, Face Blue, Face Red, Face Orange)
    {
        public const int Dimension = 3;
        public static readonly (int x, int y) CentrePieceCellCoords = (1, 1);
      
        public Face[] GetFaces() =>
            [White, Yellow, Green, Blue, Red, Orange];
    }
}
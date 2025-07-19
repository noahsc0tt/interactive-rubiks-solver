using System.Windows.Forms;

namespace Rubiks_Cube_Solver.Solver
{
    using Face = DataGridView;
    
    internal record CubeNet(Face White, Face Yellow, Face Green, Face Blue, Face Red, Face Orange)
    {
        public static readonly (int x, int y) CentrePieceCellCoords = (1, 1);
      
        public Face[] GetFaces() =>
            [White, Yellow, Green, Blue, Red, Orange];
    }
}
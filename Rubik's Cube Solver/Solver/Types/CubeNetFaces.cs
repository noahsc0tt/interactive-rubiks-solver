using System.Windows.Forms;

namespace Rubiks_Cube_Solver.Solver
{
    using Face = DataGridView;
    
    internal class CubeNetFaces(Face whiteFace, Face yellowFace, Face greenFace, Face blueFace, Face redFace, Face orangeFace)
    {
        public Face White { get; } = whiteFace;
        public Face Yellow { get; } = yellowFace;
        public Face Green { get; } = greenFace;
        public Face Blue { get; } = blueFace;
        public Face Red { get; } = redFace;
        public Face Orange { get; } = orangeFace;

        public Face[] GetFaces() =>
            [White, Yellow, Green, Blue, Red, Orange];
    }
}
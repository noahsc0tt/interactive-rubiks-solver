using System.Windows.Forms;

namespace Rubiks_Cube_Solver.Solver
{
    using Face = DataGridView;
    
    internal class CubeNetFaces
    {
        public Face White { get; }
        public Face Yellow { get; }
        public Face Green { get; }
        public Face Blue { get; }
        public Face Red { get; }
        public Face Orange { get; }

        public CubeNetFaces(Face whiteFace, Face yellowFace, Face greenFace, Face blueFace, Face redFace, Face orangeFace)
        {
            White = whiteFace;
            Yellow = yellowFace;
            Green = greenFace;
            Blue = blueFace;
            Red = redFace;
            Orange = orangeFace;
        }

        public Face[] GetFaces() =>
            [White, Yellow, Green, Blue, Red, Orange];
    }
}
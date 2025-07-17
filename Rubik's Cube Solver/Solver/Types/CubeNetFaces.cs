using System.Windows.Forms;

namespace Solver.Types
{
    using Face = DataGridView;
    
    internal class CubeNetFaces
    {
        public Face White { get; init; }
        public Face Yellow { get; init; }
        public Face Green { get; init; }
        public Face Blue { get; init; }
        public Face Red { get; init; }
        public Face Orange { get; init; }

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
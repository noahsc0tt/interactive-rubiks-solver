using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_Cube_Solver
{
    internal enum FaceColour 
    {
        White,
        Yellow,
        Green,
        Blue,
        Red,
        Orange
    }

    internal static class FaceColourToColor
    {
        public static Color ToColor(this FaceColour colour) => colour switch
        {
            FaceColour.White => Color.White,
            FaceColour.Yellow => Color.Yellow,
            FaceColour.Green => Color.Green,
            FaceColour.Blue => Color.Blue,
            FaceColour.Red => Color.Red,
            FaceColour.Orange => Color.Orange
        };
    }
}

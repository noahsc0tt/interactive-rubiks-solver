using System;
using System.Drawing;

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

    internal static class FaceColourExtension
    {
        public static FaceColour FromFaceName(string faceName) => faceName switch
        {
            "whiteFace" => FaceColour.White,
            "yellowFace" => FaceColour.Yellow,
            "greenFace" => FaceColour.Green,
            "blueFace" => FaceColour.Blue,
            "redFace" => FaceColour.Red,
            "orangeFace" => FaceColour.Orange,
            _ => throw new ArgumentException("Invalid face name")
        };


        
        public static Color ToColor(this FaceColour colour) => colour switch
        {
            FaceColour.White => Color.White,
            FaceColour.Yellow => Color.Yellow,
            FaceColour.Green => Color.Green,
            FaceColour.Blue => Color.RoyalBlue,
            FaceColour.Red => Color.Red,
            FaceColour.Orange => Color.Orange
        };
    }
}

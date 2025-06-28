using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_Cube_Solver
{
    internal class CubeNetCellLocation
    {
        public readonly int X;
        public readonly int Y;
        public readonly Color Face;

        public CubeNetCellLocation((int x, int y) location, Color face) : this(location.x, location.y, face) { }
        public CubeNetCellLocation(int x, int y, Color face)
        {
            PieceLocation.ValidateCoord(x, nameof(x));
            PieceLocation.ValidateCoord(y, nameof(y));
            X = x;
            Y = y;
            Face = face;
        }
        
        public (int X, int Y, Color Face) GetLocation() => (X, Y, Face);

        public override bool Equals(object obj) =>
            (obj is CubeNetCellLocation other) && X == other.X && Y == other.Y && Face.Equals(other.Face);

        public override int GetHashCode() =>
            // using hash of ValueTuple
            (X, Y, Face).GetHashCode();
    }

    
}

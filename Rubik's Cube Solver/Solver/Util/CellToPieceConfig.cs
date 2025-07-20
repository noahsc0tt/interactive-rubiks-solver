using System;
using System.Collections.Immutable;
using System.Linq;

namespace Rubiks_Cube_Solver.Solver.Util
{
    using Dict = ImmutableDictionary<(int, int), PieceLocation>;
    using Entry = System.Collections.Generic.KeyValuePair<(int, int), PieceLocation>;

    internal static class CellToPieceConfig
    {
        private static readonly (int, int)[] cubeFaceCellCoords =
            [(0, 0), (1, 0), (2, 0), (0, 1), (2, 1), (0, 2), (1, 2), (2, 2)];

        private static readonly Dict whiteDict = CreateFaceDict
            ([
                ((0,2,2), PieceOrientation.Corner),
                ((1,2,2), PieceOrientation.Good),
                ((2,2,2), PieceOrientation.Corner),
                ((0,2,1), PieceOrientation.Good),
                ((2,2,1), PieceOrientation.Good),
                ((0,2,0), PieceOrientation.Corner),
                ((1,2,0), PieceOrientation.Good),
                ((2,2,0), PieceOrientation.Corner),
            ]);
        private static readonly Dict yellowDict = CreateFaceDict
            ([
                ((0,0,0), PieceOrientation.Corner),
                ((1,0,0), PieceOrientation.Good),
                ((2,0,0), PieceOrientation.Corner),
                ((0,0,1), PieceOrientation.Good),
                ((2,0,1), PieceOrientation.Good),
                ((0,0,2), PieceOrientation.Corner),
                ((1,0,2), PieceOrientation.Good),
                ((2,0,2), PieceOrientation.Corner),
            ]);
        private static readonly Dict greenDict = CreateFaceDict
            ([
                ((0,2,0), PieceOrientation.Corner),
                ((1,2,0), PieceOrientation.Bad),
                ((2,2,0), PieceOrientation.Corner),
                ((0,1,0), PieceOrientation.Good),
                ((2,1,0), PieceOrientation.Good),
                ((0,0,0), PieceOrientation.Corner),
                ((1,0,0), PieceOrientation.Bad),
                ((2,0,0), PieceOrientation.Corner),
            ]);
        private static readonly Dict blueDict = CreateFaceDict
            ([
                ((2,2,2), PieceOrientation.Corner),
                ((1,2,2), PieceOrientation.Bad),
                ((0,2,2), PieceOrientation.Corner),
                ((2,1,2), PieceOrientation.Good),
                ((0,1,2), PieceOrientation.Good),
                ((2,0,2), PieceOrientation.Corner),
                ((1,0,2), PieceOrientation.Bad),
                ((0,0,2), PieceOrientation.Corner),
            ]);
        private static readonly Dict redDict = CreateFaceDict
            ([
                ((2,2,0), PieceOrientation.Corner),
                ((2,2,1), PieceOrientation.Bad),
                ((2,2,2), PieceOrientation.Corner),
                ((2,1,0), PieceOrientation.Bad),
                ((2,1,2), PieceOrientation.Bad),
                ((2,0,0), PieceOrientation.Corner),
                ((2,0,1), PieceOrientation.Bad),
                ((2,0,2), PieceOrientation.Corner),
            ]);
        private static readonly Dict orangeDict = CreateFaceDict
            ([
                ((0,2,2), PieceOrientation.Corner),
                ((0,2,1), PieceOrientation.Bad),
                ((0,2,0), PieceOrientation.Corner),
                ((0,1,2), PieceOrientation.Bad),
                ((0,1,0), PieceOrientation.Bad),
                ((0,0,2), PieceOrientation.Corner),
                ((0,0,1), PieceOrientation.Bad),
                ((0,0,0), PieceOrientation.Corner),
            ]);

        private static Dict GetFaceDict(FaceColour colour) => colour switch
        {
            FaceColour.White => whiteDict,
            FaceColour.Yellow => yellowDict,
            FaceColour.Green => greenDict,
            FaceColour.Blue => blueDict,
            FaceColour.Red => redDict,
            FaceColour.Orange => orangeDict,
            _ => throw new ArgumentException($"Invalid face colour: {colour}", nameof(colour))
        };

        private static Dict CreateFaceDict(((int, int, int) location, PieceOrientation orientation)[] pieceConfigs) =>
            ImmutableDictionary.CreateRange
            (
                cubeFaceCellCoords.Zip(pieceConfigs, (coord, config) => 
                    new Entry(coord, new PieceLocation(config.location, config.orientation)))
            );

        public static PieceLocation GetPieceConfig(CubeNetCellLocation cellLocation)
        {
            if (!GetFaceDict(cellLocation.Face).TryGetValue((cellLocation.X, cellLocation.Y), out var pieceLocation))
                throw new ArgumentException($"No corresponding piece location found for ({cellLocation.X}, {cellLocation.Y}) on face {cellLocation.Face}", nameof(cellLocation));
            return pieceLocation;
        }
    }
}

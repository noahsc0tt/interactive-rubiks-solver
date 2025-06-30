using System.Collections.Immutable;
using System.Linq;

namespace Rubiks_Cube_Solver
{
    using Entry = System.Collections.Generic.KeyValuePair<(int, int), PieceConfig>;
    using Dict = System.Collections.Immutable.ImmutableDictionary<(int, int), PieceConfig>;

    internal static class CellToPieceConfig
    {
        private static readonly (int, int)[] cubeFaceCellCoords =
            [(0, 0), (1, 0), (2, 0), (1, 0), (1, 2), (2, 0), (2, 1), (2, 2)];

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
            FaceColour.Orange => orangeDict
        };

        private static Dict CreateFaceDict(((int, int, int) location, PieceOrientation orientation)[] pieceConfigs) =>
            ImmutableDictionary.CreateRange
            (
                cubeFaceCellCoords.Zip(pieceConfigs, (coord, config) => 
                    new Entry(coord, new PieceConfig(config.location, config.orientation)))
            );

        public static PieceConfig GetPieceConfig(CubeNetCellLocation cellLocation) =>
            GetFaceDict(cellLocation.Face)[(cellLocation.X, cellLocation.Y)];
    }
}

using System.Linq;
using System.Collections.Immutable;

namespace Rubiks_Cube_Solver
{
    using Entry = System.Collections.Generic.KeyValuePair<(int, int), PieceConfig>;
    using Dict = System.Collections.Immutable.ImmutableDictionary<(int, int), PieceConfig>;

    internal static class CellToPieceConfig
    {
        // dont need to be members, group them somehow (directly in switch statement?)
        private static readonly Dict whiteDict = CreateColourDict
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
        private static readonly Dict yellowDict = CreateColourDict
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
        private static readonly Dict greenDict = CreateColourDict
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
        private static readonly Dict blueDict = CreateColourDict
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
        private static readonly Dict redDict = CreateColourDict
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
        private static readonly Dict orangeDict = CreateColourDict
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

        private static Dict GetColourDict(FaceColour colour) => colour switch
        {
            FaceColour.White => whiteDict,
            FaceColour.Yellow => yellowDict,
            FaceColour.Green => greenDict,
            FaceColour.Blue => blueDict,
            FaceColour.Red => redDict,
            FaceColour.Orange => orangeDict
        };

        private static Dict CreateColourDict(((int, int, int) location, PieceOrientation orientation)[] pieceConfigs)
            => ImmutableDictionary.CreateRange
            (
                new[] { (0, 0), (1, 0), (2, 0), (1, 0), (1, 2), (2, 0), (2, 1), (2, 2) } // the cell coordinates on each face
                .Zip(pieceConfigs, CreateEntry)
            );

        private static Entry CreateEntry((int, int) cellLocation, ((int, int, int) location, PieceOrientation orientation) pieceConfig)
            => new(cellLocation, new PieceConfig(pieceConfig.location, pieceConfig.orientation));


        public static PieceConfig GetPieceConfig(CubeNetCellLocation cellLocation) =>
            GetColourDict(cellLocation.Face)[(cellLocation.X, cellLocation.Y)];
    }
}

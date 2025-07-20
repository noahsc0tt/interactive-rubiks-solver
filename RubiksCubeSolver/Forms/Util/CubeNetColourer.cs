using System;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms.Util
{
    using Solver;
    using Face = DataGridView;

    internal class CubeNetColourer(CubeNet faces)
    {
        private const int maxNumPieces = 4;
        private void PopulateCubeFace(Face face)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = CubeNetCellLocation.MinCoordValue; i <= CubeNetCellLocation.MaxCoordValue; i++)
                face.Rows.Add("", "", "");
            (int x, int y) = CubeNet.CentrePieceCellCoords;
            face[x, y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
            face.ClearSelection(); //un-highlighting buttons
        }

        public void PopulateCubeNet() =>
            Array.ForEach(faces.GetFaces(), PopulateCubeFace);

        private void ColourYellowEdges(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.YellowEdges);
            if (numPieces >= 1)
                ColourCells
                ([
                    (faces.Green, (1, 2)),
                    (faces.Yellow, (1, 0))
                ]);
            if (numPieces >= 2)
                ColourCells
                ([
                    (faces.Orange, (1, 2)),
                    (faces.Yellow, (0, 1))
                ]);
            if (numPieces >= 3)
                ColourCells
                ([
                    (faces.Blue, (1, 2)),
                    (faces.Yellow, (1, 2))
                ]);
            if (numPieces == 4)
                ColourCells
                ([
                    (faces.Red, (1, 2)),
                    (faces.Yellow, (2, 1))
                ]);
        }

        private void ColourYellowCorners(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.YellowCorners);
            if (numPieces >= 1)
                ColourCells
                ([
                    (faces.Red, (0, 2)),
                    (faces.Green, (2, 2)),
                    (faces.Yellow, (2, 0))
                ]);
            if (numPieces >= 2)
                ColourCells
                ([
                    (faces.Green, (0, 2)),
                    (faces.Orange, (2, 2)),
                    (faces.Yellow, (0, 0))
                ]);
            if (numPieces >= 3)
                ColourCells
                ([
                    (faces.Orange, (0, 2)),
                    (faces.Blue, (2, 2)),
                    (faces.Yellow, (0, 2))
                ]);
            if (numPieces == 4)
                ColourCells
                ([
                    (faces.Blue, (0, 2)),
                    (faces.Red, (2, 2)),
                    (faces.Yellow, (2, 2))
                ]);
        }

        private void ColourMiddleLayerEdges(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.MiddleLayerEdges);
            if (numPieces >= 1)
                ColourCells
                ([
                    (faces.Red, (0, 1)),
                    (faces.Green, (2, 1))
                ]);
            if (numPieces >= 2)
                ColourCells
                ([
                    (faces.Green, (0, 1)),
                    (faces.Orange, (2, 1))
                ]);
            if (numPieces >= 3)
                ColourCells
                ([
                    (faces.Orange, (0, 1)),
                    (faces.Blue, (2, 1))
                ]);
            if (numPieces == 4)
                ColourCells
                ([
                    (faces.Blue, (0, 1)),
                    (faces.Red, (2, 1))
                ]);
        }

        private void ColourLastLayerPieces(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.LastLayer);
            if (numPieces >= 1) // white edges
                ColourCells
                ([
                    (faces.White, (0, 1)),
                    (faces.White, (1, 0)),
                    (faces.White, (2, 1)),
                    (faces.White, (1, 2))
                ]);
            if (numPieces >= 2) // white corners
                ColourCells
                ([
                    (faces.White, (0, 0)),
                    (faces.White, (2, 0)),
                    (faces.White, (0, 2)),
                    (faces.White, (2, 2))
                ]);
            if (numPieces >= 3) // permuting corners
                ColourCells
                ([
                    (faces.Green, (0, 0)),
                    (faces.Green, (2, 0)),
                    (faces.Orange, (0, 0)),
                    (faces.Orange, (2, 0)),
                    (faces.Blue, (0, 0)),
                    (faces.Blue, (2, 0)),
                    (faces.Red, (0, 0)),
                    (faces.Red, (2, 0))
                ]);
            if (numPieces == 4) // permuting edges
                ColourCells
                ([
                    (faces.Green, (1, 0)),
                    (faces.Orange, (1, 0)),
                    (faces.Blue, (1, 0)),
                    (faces.Red, (1, 0))
                ]);
        }

        private static int GetNumPiecesToColour(Stage stage, StageStep colourStep)
        {
            if (stage.Step < colourStep) return 0;
            return colourStep == stage.Step ? stage.SubStep+1 : maxNumPieces;
        }

        public void ColourCubeNet(Stage stage)
        {
            PopulateCubeNet();

            ColourYellowEdges(stage);
            ColourYellowCorners(stage);
            ColourMiddleLayerEdges(stage);
            ColourLastLayerPieces(stage);
        }

        private static void ColourCell((Face face, (int x, int y) coords) cell) =>
            ColourCell(cell.face, cell.coords);

        private static void ColourCell(Face face, (int x, int y) coords) =>
            face[coords.x, coords.y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();

        private static void ColourCells((Face face, (int x, int y) coords)[] cells) =>
            Array.ForEach(cells, ColourCell);
    }
}
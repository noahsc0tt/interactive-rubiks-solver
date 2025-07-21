using System;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms.Util
{
    using Solver;
    using Solver.Util;
    using Face = DataGridView;
    
    /// <summary>
    /// Handles coloring and populating the Rubik's Cube net UI.
    /// </summary>
    internal class CubeNetColourer(CubeNet net)
    {
        private const int maxNumPiecesToColour = 4;

        private void PopulateCubeFace(Face face)
        {
            // adding each cell (3x3) to the face
            for (int i = CubeNetCellLocation.MinCoordValue; i <= CubeNetCellLocation.MaxCoordValue; i++)
                face.Rows.Add("", "", "");
            // colouring the centre cell
            (int x, int y) = CubeNet.CentrePieceCellCoords;
            face[x, y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
            face.ClearSelection(); //un-highlighting cell buttons
        }

        public void PopulateCubeNet() =>
            Array.ForEach(net.GetFaces(), PopulateCubeFace);

        private void ColourYellowEdges(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.YellowEdges);
            if (numPieces >= 1)
                ColourCells
                ([
                    (net.Green, (1, 2)),
                    (net.Yellow, (1, 0))
                ]);
            if (numPieces >= 2)
                ColourCells
                ([
                    (net.Orange, (1, 2)),
                    (net.Yellow, (0, 1))
                ]);
            if (numPieces >= 3)
                ColourCells
                ([
                    (net.Blue, (1, 2)),
                    (net.Yellow, (1, 2))
                ]);
            if (numPieces == 4)
                ColourCells
                ([
                    (net.Red, (1, 2)),
                    (net.Yellow, (2, 1))
                ]);
        }

        private void ColourYellowCorners(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.YellowCorners);
            if (numPieces >= 1)
                ColourCells
                ([
                    (net.Red, (0, 2)),
                    (net.Green, (2, 2)),
                    (net.Yellow, (2, 0))
                ]);
            if (numPieces >= 2)
                ColourCells
                ([
                    (net.Green, (0, 2)),
                    (net.Orange, (2, 2)),
                    (net.Yellow, (0, 0))
                ]);
            if (numPieces >= 3)
                ColourCells
                ([
                    (net.Orange, (0, 2)),
                    (net.Blue, (2, 2)),
                    (net.Yellow, (0, 2))
                ]);
            if (numPieces == 4)
                ColourCells
                ([
                    (net.Blue, (0, 2)),
                    (net.Red, (2, 2)),
                    (net.Yellow, (2, 2))
                ]);
        }

        private void ColourMiddleLayerEdges(Stage stage)
        {
            int numPieces = GetNumPiecesToColour(stage, StageStep.MiddleLayerEdges);
            if (numPieces >= 1)
                ColourCells
                ([
                    (net.Red, (0, 1)),
                    (net.Green, (2, 1))
                ]);
            if (numPieces >= 2)
                ColourCells
                ([
                    (net.Green, (0, 1)),
                    (net.Orange, (2, 1))
                ]);
            if (numPieces >= 3)
                ColourCells
                ([
                    (net.Orange, (0, 1)),
                    (net.Blue, (2, 1))
                ]);
            if (numPieces == 4)
                ColourCells
                ([
                    (net.Blue, (0, 1)),
                    (net.Red, (2, 1))
                ]);
        }

        private void ColourLastLayerPieces(Stage stage)
        {
            (StageStep step, int subStep) = stage.GetTuple();
            if (step != StageStep.LastLayer) return;
            if (subStep >= Stage.WhiteEdgesSubStep)
                ColourCells
                ([
                    (net.White, (0, 1)),
                    (net.White, (1, 0)),
                    (net.White, (2, 1)),
                    (net.White, (1, 2))
                ]);
            if (subStep >= Stage.WhiteCornersSubStep)
                ColourCells
                ([
                    (net.White, (0, 0)),
                    (net.White, (2, 0)),
                    (net.White, (0, 2)),
                    (net.White, (2, 2))
                ]);
            if (subStep >= Stage.PermutingCornersSubStep)
                ColourCells
                ([
                    (net.Green, (0, 0)),
                    (net.Green, (2, 0)),
                    (net.Orange, (0, 0)),
                    (net.Orange, (2, 0)),
                    (net.Blue, (0, 0)),
                    (net.Blue, (2, 0)),
                    (net.Red, (0, 0)),
                    (net.Red, (2, 0))
                ]);
            if (subStep == Stage.PermutingEdgesSubStep)
                ColourCells
                ([
                    (net.Green, (1, 0)),
                    (net.Orange, (1, 0)),
                    (net.Blue, (1, 0)),
                    (net.Red, (1, 0))
                ]);
        }

        private static int GetNumPiecesToColour(Stage stage, StageStep colourStep)
        {
            if (stage.Step == StageStep.LastLayer)
                throw new InvalidOperationException($"Last Layer stages (currently {StageInfo.GetName(stage)}) do not have set numPiece values");
            if (stage.Step < colourStep) return 0;
            return colourStep == stage.Step ? stage.SubStep+1 : maxNumPiecesToColour;
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
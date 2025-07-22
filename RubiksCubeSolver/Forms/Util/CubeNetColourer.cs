using System;
using System.Windows.Forms;
using System.Drawing;

namespace RubiksCubeSolver.Forms.Util
{
    using Solver;
    using System.Drawing;
    using Face = DataGridView;
    
    /// <summary>
    /// Handles coloring and populating the Rubik's Cube net UI.
    /// </summary>
    internal class CubeNetColourer(CubeNetFaces faces)
    {
        private const int maxNumPiecesToColour = 4;

        private static void PopulateCubeFace(Face face)
        {
            AddCellsToFace(face);
            ColourCentreCell(face);
            face.ClearSelection(); //un-highlighting cell buttons

            // ensuring cells do not get painted over
            face.CellPainting += (sender, e) =>
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;
            };
        }

        private static void AddCellsToFace(Face face)
        {
            face.Width = face.Height = Math.Min(face.Width, face.Height);
            // adding each cell (3x3) to the face
            int cellSize = face.Width / CubeNetFaces.Dimension;
            for (int i = 0; i < CubeNetFaces.Dimension; i++)
            {
                face.Columns.Add(new DataGridViewButtonColumn { Width = cellSize });
                face.Rows[face.Rows.Add()].Height = cellSize;
            }
        }

        private static void ColourCentreCell(Face face) =>
            face[CubeNetFaces.CentrePieceCellCoords.x, CubeNetFaces.CentrePieceCellCoords.y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();

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
            (StageStep step, int subStep) = stage.GetTuple();
            if (step != StageStep.LastLayer) return;
            if (subStep >= Stage.WhiteEdgesSubStep)
                ColourCells
                ([
                    (faces.White, (0, 1)),
                    (faces.White, (1, 0)),
                    (faces.White, (2, 1)),
                    (faces.White, (1, 2))
                ]);
            if (subStep >= Stage.WhiteCornersSubStep)
                ColourCells
                ([
                    (faces.White, (0, 0)),
                    (faces.White, (2, 0)),
                    (faces.White, (0, 2)),
                    (faces.White, (2, 2))
                ]);
            if (subStep >= Stage.PermutingCornersSubStep)
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
            if (subStep == Stage.PermutingEdgesSubStep)
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
            return stage.Step == colourStep ? stage.SubStep+1 : maxNumPiecesToColour;
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
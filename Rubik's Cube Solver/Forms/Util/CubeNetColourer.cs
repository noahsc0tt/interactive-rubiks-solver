using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Rubiks_Cube_Solver.Solver;

namespace Rubiks_Cube_Solver.Forms.Util
{
    using Face = DataGridView;

    internal class CubeNetColourer
    {
        private readonly CubeNetFaces faces;

        public CubeNetColourer(CubeNetFaces faces) =>
            this.faces = faces;

        private void PopulateCubeFace(Face face)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = CubeNetCellLocation.MinCoord; i <= CubeNetCellLocation.MaxCoord; i++)
                face.Rows.Add("", "", "");
            face[1, 1].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
            face.ClearSelection(); //un-highlighting buttons
        }

        public void PopulateCubeNet() =>
            Array.ForEach(faces.GetFaces(), PopulateCubeFace);

        private void ColourYellowEdges(int subStep)
        {
            if (subStep >= 0)
                ColourCells
                ([
                    (faces.Green, (1, 2)),
                    (faces.Yellow, (1, 0))
                ]);
            if (subStep >= 1)
                ColourCells
                ([
                    (faces.Orange, (1, 2)),
                    (faces.Yellow, (0, 1))
                ]);
            if (subStep >= 2)
                ColourCells
                ([
                    (faces.Blue, (1, 2)),
                    (faces.Yellow, (1, 2))
                ]);
            if (subStep == 3)
                ColourCells
                ([
                    (faces.Red, (1, 2)),
                    (faces.Yellow, (2, 1))
                ]);
        }

        private void ColourYellowCorners(int subStep)
        {
            if (subStep >= 0)
                ColourCells
                ([
                    (faces.Red, (0, 2)),
                    (faces.Green, (2, 2)),
                    (faces.Yellow, (2, 0))
                ]);
            if (subStep >= 1)
                ColourCells
                ([
                    (faces.Green, (0, 2)),
                    (faces.Orange, (2, 2)),
                    (faces.Yellow, (0, 0))
                ]);
            if (subStep >= 2)
                ColourCells
                ([
                    (faces.Orange, (0, 2)),
                    (faces.Blue, (2, 2)),
                    (faces.Yellow, (0, 2))
                ]);
            if (subStep == 3)
                ColourCells
                ([
                    (faces.Blue, (0, 2)),
                    (faces.Red, (2, 2)),
                    (faces.Yellow, (2, 2))
                ]);
        }

        private void ColourMiddleLayerEdges(int subStep)
        {
            if (subStep >= 0)
                ColourCells
                ([
                    (faces.Red, (0, 1)),
                    (faces.Green, (2, 1))
                ]);
            if (subStep >= 1)
                ColourCells
                ([
                    (faces.Green, (0, 1)),
                    (faces.Orange, (2, 1))
                ]);
            if (subStep >= 2)
                ColourCells
                ([
                    (faces.Orange, (0, 1)),
                    (faces.Blue, (2, 1))
                ]);
            if (subStep == 3)
                ColourCells
                ([
                    (faces.Blue, (0, 1)),
                    (faces.Red, (2, 1))
                ]);
        }

        private void ColourLastLayerPieces(int subStep)
        {
            if (subStep >= 0) // white edges
                ColourCells
                ([
                    (faces.White, (0, 1)),
                    (faces.White, (1, 0)),
                    (faces.White, (2, 1)),
                    (faces.White, (1, 2))
                ]);
            if (subStep >= 1) // white corners
                ColourCells
                ([
                    (faces.White, (0, 0)),
                    (faces.White, (2, 0)),
                    (faces.White, (0, 2)),
                    (faces.White, (2, 2))
                ]);
            if (subStep >= 2) // permuting corners
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
            if (subStep == 3) // permuting edges
                ColourCells
                ([
                    (faces.Green, (1, 0)),
                    (faces.Orange, (1, 0)),
                    (faces.Blue, (1, 0)),
                    (faces.Red, (1, 0))
                ]);
        }

        public void ColourCubeNet(Stage stage)
        {
            PopulateCubeNet();

            switch (stage.Step)
            {
                case StageStep.YellowEdges:
                    ColourYellowEdges(stage.SubStep);
                    break;
                case StageStep.YellowCorners:
                    ColourYellowEdges(Stage.MaxSubStep);
                    ColourYellowCorners(stage.SubStep);
                    break;
                case StageStep.MiddleLayerEdges:
                    ColourYellowEdges(Stage.MaxSubStep);
                    ColourYellowCorners(Stage.MaxSubStep);
                    ColourMiddleLayerEdges(stage.SubStep);
                    break;
                case StageStep.LastLayer:
                    ColourYellowEdges(Stage.MaxSubStep);
                    ColourYellowCorners(Stage.MaxSubStep);
                    ColourMiddleLayerEdges(Stage.MaxSubStep);
                    ColourLastLayerPieces(stage.SubStep);
                    break;
            }
        }

        private static void ColourCell((Face face, (int x, int y) coords) cell) =>
            ColourCell(cell.face, cell.coords);

        private static void ColourCell(Face face, (int x, int y) coords) =>
            face[coords.x, coords.y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();

        private static void ColourCells((Face face, (int x, int y) coords)[] cells) =>
            Array.ForEach(cells, ColourCell);
    }
}
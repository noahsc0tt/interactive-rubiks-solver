using System;
using System.Windows.Forms;
using System.Collections.Generic;

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

        private List<(Face, (int x, int y))> GetYellowEdges(int subStep)
        {
            List<(Face, (int x, int y))> cells = new();
            if (subStep >= 0)
                cells.AddRange
                ([
                    (faces.Green, (1, 2)),
                    (faces.Yellow, (1, 0))
                ])
            if (subStep >= 1)
                cells.AddRange
                ([
                    (faces.Orange, (1, 2)),
                    (faces.Yellow, (0, 1))
                ])
            if (subStep >= 2)
                cells.AddRange
                ([
                    (faces.Blue, (1, 2)),
                    (faces.Yellow, (1, 2))
                ])
            if (subStep == 3)
                cells.AddRange
                ([
                    (faces.Red, (1, 2)),
                    (faces.Yellow, (2, 1))
                ])
            return cells;
        }

        private List<(Face, (int x, int y))> GetYellowCorners(int subStep)
        {
            List<(Face, (int x, int y))> cells = new();
            if (subStep >= 0)
                cells.AddRange
                ([
                    (faces.Red, (0, 2)),
                    (faces.Green, (2, 2)),
                    (faces.Yellow, (2, 0))
                ])
            if (subStep >= 1)
                cells.AddRange
                ([
                    (faces.Green, (0, 2)),
                    (faces.Orange, (2, 2)),
                    (faces.Yellow, (0, 0))
                ])
            if (subStep >= 2)
                cells.AddRange
                ([
                    (faces.Orange, (0, 2)),
                    (faces.Blue, (2, 2)),
                    (faces.Yellow, (0, 2))
                ])
            if (subStep == 3)
                cells.AddRange
                ([
                    (faces.Blue, (0, 2)),
                    (faces.Red, (2, 2)),
                    (faces.Yellow, (2, 2))
                ])
            return cells;
        }

        private List<(Face, (int x, int y))> GetMiddleLayerEdges(int subStep)
        {
            List<(Face, (int x, int y))> cells = new();
            if (subStep >= 0)
            {
                cells.AddRange
                ([
                    (faces.Red, (0, 1)),
                    (faces.Green, (2, 1))
                ])
            if (subStep >= 1)
                cells.AddRange
                ([
                    (faces.Green, (0, 1)),
                    (faces.Orange, (2, 1))
                ])
            if (subStep >= 2)
                cells.AddRange
                ([
                    (faces.Orange, (0, 1)),
                    (faces.Blue, (2, 1))
                ])
            if (subStep == 3)
                cells.AddRange
                ([
                    (faces.Blue, (0, 1)),
                    (faces.Red, (2, 1))
                ])
            return cells;
        }

        private List<(Face, (int x, int y))> GetLastLayerPieces(int subStep)
        {
            List<(Face, (int x, int y))> cells = new();
            if (subStep >= 0) // white edges
                cells.AddRange
                ([
                    (faces.White, (0, 1)),
                    (faces.White, (1, 0)),
                    (faces.White, (2, 1)),
                    (faces.White, (1, 2))
                ])
            if (subStep >= 1) // white corners
                cells.AddRange
                ([
                    (faces.White, (0, 0)),
                    (faces.White, (2, 0)),
                    (faces.White, (0, 2)),
                    (faces.White, (2, 2))
                ])
            if (subStep >= 2) // permuting corners
                cells.AddRange
                ([
                    (faces.Green, (0, 0)),
                    (faces.Green, (2, 0)),
                    (faces.Orange, (0, 0)),
                    (faces.Orange, (2, 0)),
                    (faces.Blue, (0, 0)),
                    (faces.Blue, (2, 0)),
                    (faces.Red, (0, 0)),
                    (faces.Red, (2, 0))
                ])  
            if (subStep == 3) // permuting edges
                cells.AddRange
                ([
                    (faces.Green, (1, 0)),
                    (faces.Orange, (1, 0)),
                    (faces.Blue, (1, 0)),
                    (faces.Red, (1, 0))
                ])
            return cells;
        }

        public void ColourCubeNet(Stage stage)
        {
            PopulateCubeNet();

            List<(Face, (int x, int y))> cells = new();

            switch (stage.Step)
            {
                case StageStep.YellowEdges:
                    cells.AddRange(GetYellowEdges(stage.SubStep));
                    break;
                case StageStep.YellowCorners:
                    cells.AddRange(GetYellowEdges(Stage.MaxSubStep));
                    cells.AddRange(GetYellowCorners(stage.SubStep));
                    break;
                case StageStep.MiddleLayerEdges:
                    cells.AddRange(GetYellowEdges(Stage.MaxSubStep));
                    cells.AddRange(GetYellowCorners(Stage.MaxSubStep));
                    cells.AddRange(GetMiddleLayerEdges(stage.SubStep));
                    break;
                case StageStep.LastLayer:
                    cells.AddRange(GetYellowEdges(Stage.MaxSubStep));
                    cells.AddRange(GetYellowCorners(Stage.MaxSubStep));
                    cells.AddRange(GetMiddleLayerEdges(Stage.MaxSubStep));
                    cells.AddRange(GetLastLayerPieces(stage.SubStep));
                    break;
            }
            ColourCells(cells);
        }

        private static void ColourCell((Face face, (int x, int y) coords) cell) =>
            cell.face[cell.coords.x, cell.coords.y].Style.BackColor = FaceColourExtension.FromFaceName(cell.face.Name).ToColor();

        private static void ColourCells(List<(Face face, (int x, int y) coords)> cells) =>
            cells.ForEach(ColourCell);
    }
}
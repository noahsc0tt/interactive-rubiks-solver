using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Solver;

namespace Rubiks_Cube_Solver.Forms.Util
{
    using Face = DataGridView;

    internal static class CubeNetColourer
    {
        private static void PopulateCubeFace(Face face)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = CubeNetCellLocation.MinCoord; i <= CubeNetCellLocation.MaxCoord; i++)
                face.Rows.Add("", "", "");
            face[1, 1].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
            face.ClearSelection(); //un-highlighting buttons
        }

        public static void PopulateCubeNet(CubeNetFaces faces) =>
            Array.ForEach(faces.GetFaces(), PopulateCubeFace);

        private static void ColourYellowEdges(int subStep, CubeNetFaces faces)
        {
            if (subStep >= 0)
            {
                ColourCell(faces.Green, (1, 2));
                ColourCell(faces.Yellow, (1, 0));
            }
            if (subStep >= 1)
            {
                ColourCell(faces.Orange, (1, 2));
                ColourCell(faces.Yellow, (0, 1));
            }
            if (subStep >= 2)
            {
                ColourCell(faces.Blue, (1, 2));
                ColourCell(faces.Yellow, (1, 2));
            }
            if (subStep == 3)
            {
                ColourCell(faces.Red, (1, 2));
                ColourCell(faces.Yellow, (2, 1));
            }
        }

        private static void ColourYellowCorners(int subStep, CubeNetFaces faces)
        {
            if (subStep >= 0)
            {
                ColourCell(faces.Red, (0, 2));
                ColourCell(faces.Green, (2, 2));
                ColourCell(faces.Yellow, (2, 0));
            }
            if (subStep >= 1)
            {
                ColourCell(faces.Green, (0, 2));
                ColourCell(faces.Orange, (2, 2));
                ColourCell(faces.Yellow, (0, 0));
            }
            if (subStep >= 2)
            {
                ColourCell(faces.Orange, (0, 2));
                ColourCell(faces.Blue, (2, 2));
                ColourCell(faces.Yellow, (0, 2));
            }
            if (subStep == 3)
            {
                ColourCell(faces.Blue, (0, 2));
                ColourCell(faces.Red, (2, 2));
                ColourCell(faces.Yellow, (2, 2));
            }
        }

        private static void ColourMiddleLayerEdges(int subStep, CubeNetFaces faces)
        {
            if (subStep >= 0)
            {
                ColourCell(faces.Red, (0, 1));
                ColourCell(faces.Green, (2, 1));
            }
            if (subStep >= 1)
            {
                ColourCell(faces.Green, (0, 1));
                ColourCell(faces.Orange, (2, 1));
            }
            if (subStep >= 2)
            {
                ColourCell(faces.Orange, (0, 1));
                ColourCell(faces.Blue, (2, 1));
            }
            if (subStep == 3)
            {
                ColourCell(faces.Blue, (0, 1));
                ColourCell(faces.Red, (2, 1));
            }
        }

        private static void ColourLastLayer(int subStep, CubeNetFaces faces)
        {
            if (subStep >= 0) // white edges
            {
                ColourCell(faces.White, (0, 1));
                ColourCell(faces.White, (1, 0));
                ColourCell(faces.White, (2, 1));
                ColourCell(faces.White, (1, 2));
            }
            if (subStep >= 1) // white corners
            {
                ColourCell(faces.White, (0, 0));
                ColourCell(faces.White, (2, 0));
                ColourCell(faces.White, (0, 2));
                ColourCell(faces.White, (2, 2));
            }
            if (subStep >= 2) // permuting corners
            {
                ColourCell(faces.Green, (0, 0));
                ColourCell(faces.Green, (2, 0));
                ColourCell(faces.Orange, (0, 0));
                ColourCell(faces.Orange, (2, 0));
                ColourCell(faces.Blue, (0, 0));
                ColourCell(faces.Blue, (2, 0));
                ColourCell(faces.Red, (0, 0));
                ColourCell(faces.Red, (2, 0));

            }
            if (subStep == 3) // permuting edges
            {
                ColourCell(faces.Green, (1, 0));
                ColourCell(faces.Orange, (1, 0));
                ColourCell(faces.Blue, (1, 0));
                ColourCell(faces.Red, (1, 0));
            }
        }

        public static void ColourCubeNet(Stage stage, CubeNetFaces faces)
        {
            PopulateCubeNet(faces);

            switch (stage.Step)
            {
                case StageStep.YellowEdges:
                    ColourYellowEdges(stage.SubStep, faces);
                    break;
                case StageStep.YellowCorners:
                    ColourYellowEdges(Stage.MaxSubStep, faces);
                    ColourYellowCorners(stage.SubStep, faces);
                    break;
                case StageStep.MiddleLayerEdges:
                    ColourYellowEdges(Stage.MaxSubStep, faces);
                    ColourYellowCorners(Stage.MaxSubStep, faces);
                    ColourMiddleLayerEdges(stage.SubStep, faces);
                    break;
                case StageStep.LastLayer:
                    ColourYellowEdges(Stage.MaxSubStep, faces);
                    ColourYellowCorners(Stage.MaxSubStep, faces);
                    ColourMiddleLayerEdges(Stage.MaxSubStep, faces);
                    ColourLastLayer(stage.SubStep, faces);
                    break;

            };
        }

        private static void ColourCell(Face face, (int x, int y) location) =>
            face[location.x, location.y].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
    }
}
using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{

    static class Global
    {
        //Creating attributes to be used across forms
        public static int[] location = new int[3];

        public static string orientation;


        public static int[] stage = { 3, 4 };

        public static string selectedColour;

        public static bool coloured = false;

        public static string time;

        public static string scramble;
        
        public static void incrementStage()
        {
            //controlling incrementation of the Global.stage attribute through the different stages of the solve
            if (stage[1] < 4) 
            {
                stage[1]++;
            }
            else
            {
                stage[0]++;
                stage[1] = 1;
            }
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}

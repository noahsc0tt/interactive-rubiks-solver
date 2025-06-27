using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{

    static class Global
    {
        //Creating attributes to be used across forms
        public static int[] location = new int[3];

        public static string orientation;

        public static string selectedColour;

        
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

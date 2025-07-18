using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(Forms.Menu.Instance);
        }
    }
}

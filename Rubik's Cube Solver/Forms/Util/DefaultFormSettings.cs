using System.Windows.Forms;
using System.Drawing;

namespace Rubiks_Cube_Solver.Forms.Util
{
    // extension Form class
    internal static class DefaultFormSettings
    {
        public static void ApplyDefaultFormSettings(this Form form)
        {
            form.MaximumSize = new Size(1920, 1080);
            form.Size = form.MaximumSize;
            form.WindowState = FormWindowState.Maximized;
            form.KeyPreview = true;
        }
    }
}

using System.Windows.Forms;
using System.Drawing;

namespace RubiksCubeSolver.Forms.Util
{
    // extension Form class
    internal static class DefaultFormSettings
    {
        public const int MaxWidth = 1920;
        public const int MaxHeight = 1080;

        public static void ApplyDefaultFormSettings(this Form form)
        {
            form.MaximumSize = new Size(MaxWidth, MaxHeight);
            form.Size = form.MaximumSize;
            form.WindowState = FormWindowState.Maximized;
            form.KeyPreview = true;
        }
    }
}

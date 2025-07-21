using System.Windows.Forms;
using System.Drawing;

namespace RubiksCubeSolver.Forms.Util
{
    /// <summary>
    /// Provides an extension method for applying default size and window settings to Forms.
    /// </summary>
    internal static class DefaultFormSettings
    {
        public static readonly Size DefaultFormSize = new (1920, 1080);

        /// <summary>
        /// Applies fixed size and window settings to avoid manual frontend scaling work...
        /// </summary>
        public static void ApplyDefaultFormSettings(this Form form)
        {
            form.MaximumSize = form.MinimumSize = form.Size = DefaultFormSize;
            form.WindowState = FormWindowState.Maximized;
            form.KeyPreview = true;
        }
    }
}

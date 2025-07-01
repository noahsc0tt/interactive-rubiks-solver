using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal static class FormNavigator
    {
        public static void Navigate<T>(Form currentForm, params object[] args) where T : Form
        {
            Form newForm = (Form)Activator.CreateInstance(typeof(T), args);
            newForm.Show();
            currentForm.Close();
        }
    }
}

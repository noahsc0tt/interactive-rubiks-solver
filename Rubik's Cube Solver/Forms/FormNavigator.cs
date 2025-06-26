using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal static class FormNavigator
    {
        internal static void Navigate<T> (Form currentForm) where T : Form
        {
            Form nextForm = (Form) Activator.CreateInstance(typeof(T));
            nextForm.Show();
            currentForm.Hide();
        }
        
        internal static void Navigate<T> (Form currentForm, params object[] args) where T : Form
        {
            Form nextForm = (Form) Activator.CreateInstance(typeof(T), args);
            nextForm.Show();
            currentForm.Hide();
        }
    }
}

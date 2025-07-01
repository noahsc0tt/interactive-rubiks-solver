using System;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal static class FormNavigator
    {
        public static void Navigate<T>(Form currentForm) where T : Form =>
            SwitchForms(currentForm, (Form)Activator.CreateInstance(typeof(T)));
        
        public static void Navigate<T>(Form currentForm, params object[] args) where T : Form =>
            SwitchForms(currentForm, (Form)Activator.CreateInstance(typeof(T), args));

        private static void SwitchForms(Form oldForm, Form newForm)
        {
            newForm.Show();
            oldForm.Close();
        }
    }
}

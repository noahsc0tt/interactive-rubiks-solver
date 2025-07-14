using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver.Forms.Util
{
    using SingletonEntry = KeyValuePair<Type, Form>;

    internal static class FormNavigator
    {
        private static readonly ImmutableDictionary<Type, Form> singletons = ImmutableDictionary.CreateRange
            ([
                new SingletonEntry(typeof(Menu), Forms.Menu.Instance),
                new SingletonEntry(typeof(NotationExplanation), NotationExplanation.Instance)
            ]);

        public static void Menu(Form currentForm) =>
            Navigate<Menu>(currentForm);

        public static void Navigate<T>(Form currentForm, params object[] args) where T : Form
        {
            Form newForm = singletons.TryGetValue(typeof(T), out Form singleton) ? singleton :
                (Form)Activator.CreateInstance(typeof(T), args);

            SwitchForms(currentForm, newForm);
        }

        private static void SwitchForms(Form currentForm, Form newForm)
        {
            newForm.Show();

            if (singletons.ContainsKey(currentForm.GetType()))
                currentForm.Hide();
            else
                currentForm.Close();
        }
    }
}

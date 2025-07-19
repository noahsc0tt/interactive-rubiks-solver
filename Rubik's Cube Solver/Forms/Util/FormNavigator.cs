using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Solver;
using Rubiks_Cube_Solver.Solver.Forms;

namespace Rubiks_Cube_Solver.Forms.Util
{
    using SingletonEntry = KeyValuePair<Type, Form>;

    internal static class FormNavigator
    {
        private static bool navigating = false;

        private static readonly ImmutableDictionary<Type, Form> singletons = ImmutableDictionary.CreateRange
            ([
                new SingletonEntry(typeof(Menu), Forms.Menu.Instance),
                new SingletonEntry(typeof(NotationExplanation), NotationExplanation.Instance)
            ]);

        public static void Menu(Form currentForm) =>
            Navigate<Menu>(currentForm);

        public static void NavigateFromCheckingCube(CheckingCube currentForm, Stage stage)
        {
            if (stage.Step == StageStep.LastLayer)
            {
                switch (stage.SubStep)
                {
                    case 0: Navigate<WhiteEdges>(currentForm); break;
                    case 1: Navigate<WhiteCorners>(currentForm); break;
                    case 2: Navigate<PermutingCorners>(currentForm); break;
                    case 3: Navigate<PermutingEdges>(currentForm); break;
                }
            }
            else
                Navigate<InputPiece>(currentForm, stage);
        }

        public static void Navigate<T>(Form currentForm, params object[] args) where T : Form
        {
            navigating = true;
            Form newForm = singletons.TryGetValue(typeof(T), out Form singleton) ? singleton :
                (Form)Activator.CreateInstance(typeof(T), args);

            ExitOnUserClose(newForm);
            SwitchForms(currentForm, newForm);
            navigating = false;
        }

        private static void SwitchForms(Form currentForm, Form newForm)
        {
            newForm.Show();

            if (singletons.ContainsKey(currentForm.GetType()))
                currentForm.Hide();
            else
                currentForm.Close();
        }

        private static void ExitOnUserClose(Form form) =>
            form.FormClosing += (s, e) =>
            {
                if (!navigating && e.CloseReason == CloseReason.UserClosing)
                    Application.Exit();
            };
    }
}

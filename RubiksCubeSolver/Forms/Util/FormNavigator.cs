using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms.Util
{
    using Solver;
    using Solver.Forms;
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
                    case Stage.WhiteEdgesSubStep: Navigate<WhiteEdges>(currentForm); break;
                    case Stage.WhiteCornersSubStep: Navigate<WhiteCorners>(currentForm); break;
                    case Stage.PermutingCornersSubStep: Navigate<PermutingCorners>(currentForm); break;
                    case Stage.PermutingEdgesSubStep: Navigate<PermutingEdges>(currentForm); break;
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
            if (!newForm.IsDisposed) // to account for outputsolution navigating back to inputpiece if the input was invalid
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

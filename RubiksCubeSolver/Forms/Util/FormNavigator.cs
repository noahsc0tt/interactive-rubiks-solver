using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms.Util
{
    using Solver;
    using Solver.Forms;
    using System.Linq;
    using SingletonEntry = KeyValuePair<Type, Form>;

    /// <summary>
    /// Provides static methods for navigating between forms in the RubiksCubeSolver application.
    /// Manages singleton forms, transitions, and application exit logic to ensure consistent UI flow.
    /// </summary>
    internal static class FormNavigator
    {
        // indicates whether a navigation operation is currently in progress to avoid running Application.Exit() when a form is closed
        private static bool navigating = false;

        // stores singleton instances of forms that should not be recreated on navigation.
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
            Form newForm;
            try
            {
                newForm = singletons.TryGetValue(typeof(T), out Form singleton) ? singleton :
                    (Form)Activator.CreateInstance(typeof(T), args);
            }
            catch (Exception e) // if Activator.CreateInstance fails
            {
                navigating = false;
                string argsString = args.Length > 0 ? $" with args {string.Join(", ", args.Select(arg => arg?.ToString() ?? "null"))}" : "";
                throw new InvalidOperationException
                    ($"Failed to create form of type {typeof(T).Name}{argsString}.", e);
            }

            ExitOnUserClose(newForm);
            if (!newForm.IsDisposed) // to allow OutputSolution to immediately navigate back to InputPiece if the piece was invalid
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

        /// <summary>
        /// Attaches an event handler to exit the application when the user closes a form, unless a navigation operation is in progress.
        /// </summary>
        private static void ExitOnUserClose(Form form) =>
            form.FormClosing += (s, e) =>
            {
                if (!navigating && e.CloseReason == CloseReason.UserClosing)
                    Application.Exit();
            };
    }
}

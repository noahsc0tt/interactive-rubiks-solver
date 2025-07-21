using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;
using System.Linq;

namespace RubiksCubeSolver.Forms.Util
{
    using Solver;
    using Solver.Forms;
    using SingletonEntry = KeyValuePair<Type, Form>;

    /// <summary>
    /// Provides static methods for navigating between forms in the RubiksCubeSolver application.
    /// </summary>
    internal static class FormNavigator
    {
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
            Form newForm;
            try
            {
                newForm = singletons.TryGetValue(typeof(T), out Form singleton) ? singleton :
                    (Form)Activator.CreateInstance(typeof(T), args);
            }
            catch (Exception e) // if Activator.CreateInstance fails
            {
                string argsString = args.Length > 0 ? $" with args {string.Join(", ", args.Select(arg => arg?.ToString() ?? "null"))}" : "";
                throw new InvalidOperationException
                    ($"Failed to create form of type {typeof(T).Name}{argsString}.", e);
            }
            
            ExitOnUserClose(newForm);

            // Avoid ObjectDisposedException if newForm closed itself in its constructor
            // e.g. when OutputSolution navigates back to InputPiece if a solution cannot be found
            if (newForm.IsDisposed)
                currentForm.Close();
            else
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

        /// <summary>
        /// Attaches an event handler to exit the application when the user closes a form
        /// </summary>
        private static void ExitOnUserClose(Form form) =>
            form.FormClosing += (s, e) =>
            {
                // only exit when the last remaining form is being closed by the user (avoids exiting during navigation)
                if (VisibleForms() == 1 && e.CloseReason == CloseReason.UserClosing)
                    Application.Exit();
            };

        private static int VisibleForms() =>
            Application.OpenForms.Cast<Form>().Count(form => form.Visible);
    }
}

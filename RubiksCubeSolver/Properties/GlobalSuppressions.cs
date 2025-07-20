// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "No 2025 machines run on an earlier OS than Windows 6.1")]
[assembly: SuppressMessage("Style", "IDE0130:Namespace does not match folder structure", Justification = "The Solver.Types and Solver.Forms.LastLayer directories are for organisation only", Scope = "namespace", Target = "~N:RubiksCubeSolver.Solver")]
[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "'object sender' and 'EventArgs e' are unused parameters but need to be present for winform signitures", Scope = "namespace", Target = "~N:RubiksCubeSolver.Forms")]
[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "'object sender' and 'EventArgs e' are unused parameters but need to be present for winform signitures", Scope = "namespace", Target = "~N:RubiksCubeSolver.Solver.Forms")]
[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "'object sender' and 'EventArgs e' are unused parameters but need to be present for winform signitures", Scope = "namespace", Target = "~N:RubiksCubeSolver.Timer.Forms")]


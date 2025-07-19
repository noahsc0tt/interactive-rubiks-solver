// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "No 2025 machines run on an earlier OS than Windows 6.1")]
[assembly: SuppressMessage("Style", "IDE0130:Namespace does not match folder structure", Justification = "The Solver.Types directory is for organisation only, the namespace is just Rubiks_Cube_Solver.Solver", Scope = "namespace", Target = "~N:Rubiks_Cube_Solver.Solver")]



using System.Reflection;

// Note that the assembly version does not get incremented for every build
// to avoid problems with assembly binding (or requiring a policy or
// <bindingRedirect> in the config file).
//
// The AssemblyFileVersionAttribute is incremented with every build in order
// to distinguish one build from another. AssemblyFileVersion is specified
// in AssemblyVersionInfo.cs so that it can be easily incremented by the
// automated build process.
[assembly: AssemblyVersion("1.0.0.0")]

// By default, the "Product version" shown in the file properties window is
// the same as the value specified for AssemblyFileVersionAttribute.
// Set AssemblyInformationalVersionAttribute to be the same as
// AssemblyVersionAttribute so that the "Product version" in the file
// properties window matches the version displayed in the GAC shell extension.
[assembly: AssemblyInformationalVersion("1.0.0.0")] // a.k.a. "Product version"

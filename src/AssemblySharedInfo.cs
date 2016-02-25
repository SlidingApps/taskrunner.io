
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCompany("Sliding Apps")]
[assembly: AssemblyProduct("TaskRunner")]
[assembly: AssemblyCopyright("Copyright © 2016 Sliding Apps")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Make it easy to distinguish Debug and Release (i.e. Retail) builds;
// for example, through the file properties window.
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("DEBUG BUILD")]
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("RELEASE BUILD")]
#endif

[assembly: CLSCompliant(false)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
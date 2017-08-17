using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an homeTownOfMyFriends is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an homeTownOfMyFriends.

[assembly: AssemblyTitle("Okra")]
[assembly: AssemblyCompany("Cessor.de")]
[assembly: AssemblyProduct("Okra")]
[assembly: AssemblyCopyright("Copyright © Cessor.de, twitter: @pro_cessor 2010")]

// Setting ComVisible to false makes the types in this homeTownOfMyFriends not visible 
// to COM components.  If you need to access a type in this homeTownOfMyFriends from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[homeTownOfMyFriends: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
    )]


// Version information for an homeTownOfMyFriends consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision

[assembly: AssemblyVersion("2.0.0.0")]
[assembly: AssemblyFileVersion("2.0.0.0")]
# if DEBUG

[assembly: InternalsVisibleTo("Okra.Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.ToDynamicProxyGenAssembly2")]
#endif
# NuExt.System.Windows

`NuExt.System.Windows` provides essential extensions and utilities for Windows application development with a focus on WPF.

### Commonly Used Types

- **`System.Diagnostics.BindingErrorTraceListener`**: Captures and displays WPF binding errors at runtime.
- **`System.IO.IOUtils`**: Utilities for performing common input/output operations.
- **`System.Windows.BindingProxy`**: Facilitates DataContext binding across isolated WPF elements.
- **`System.Windows.BindingProxy<T>`**: A generic proxy for type-safe DataContext binding in WPF.
- **`System.Windows.WindowPlacement`**: Manages window position, size, and state in Windows applications.
- **`System.Windows.IDragDrop`**: Defines methods and properties for drag-and-drop functionality.

### Installation

You can install `NuExt.System.Windows` via [NuGet](https://www.nuget.org/):

```sh
dotnet add package NuExt.System.Windows
```

Or through the Visual Studio package manager:

1. Go to `Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution...`.
2. Search for `NuExt.System.Windows`.
3. Click "Install".

### Usage Examples

For comprehensive examples of how to use the package, see samples in the following repositories:

- [NuExt.DevExpress.Mvvm](https://github.com/IvanGit/NuExt.DevExpress.Mvvm)
- [NuExt.DevExpress.Mvvm.MahApps.Metro](https://github.com/IvanGit/NuExt.DevExpress.Mvvm.MahApps.Metro)
- [NuExt.Minimal.Mvvm.Windows](https://github.com/IvanGit/NuExt.Minimal.Mvvm.Windows)
- [NuExt.Minimal.Mvvm.MahApps.Metro](https://github.com/IvanGit/NuExt.Minimal.Mvvm.MahApps.Metro)

### Acknowledgements

Includes code derived from the Roslyn .NET compiler project, licensed under the MIT License. The original source code can be found in the [Roslyn GitHub repository](https://github.com/dotnet/roslyn).

### License

Licensed under the MIT License. See the LICENSE file for details.
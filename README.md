# ktsu.StrongPaths

> A library providing strong typing for common filesystem paths with compile-time feedback and runtime validation

[![License](https://img.shields.io/github/license/ktsu-dev/StrongPaths)](https://github.com/ktsu-dev/StrongPaths/blob/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/ktsu.StrongPaths.svg)](https://www.nuget.org/packages/ktsu.StrongPaths/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ktsu.StrongPaths.svg)](https://www.nuget.org/packages/ktsu.StrongPaths/)
[![Build Status](https://github.com/ktsu-dev/StrongPaths/workflows/build/badge.svg)](https://github.com/ktsu-dev/StrongPaths/actions)
[![GitHub Stars](https://img.shields.io/github/stars/ktsu-dev/StrongPaths?style=social)](https://github.com/ktsu-dev/StrongPaths/stargazers)

## Introduction

StrongPaths is a collection of classes derived from `ktsu.StrongStrings` with added functionality and helper methods for filesystem paths. It provides strong typing for common filesystem paths, giving you compile-time feedback and runtime validation to help catch path-related errors early in your development cycle.

Get familiar with the [StrongStrings](https://github.com/ktsu-dev/StrongStrings) library to get the most out of StrongPaths.

## Features

- **Strong Typing** for file system paths to prevent type confusion
- **Path Combination** using overloaded operators for intuitive path building
- **Compile-time Safety** to catch type mismatches early
- **Runtime Validation** for path format and structure
- **Relative Path Calculations** between different path types
- **Hierarchical Type System** for flexible parameter constraints

## Installation

### Package Manager Console

```powershell
Install-Package ktsu.StrongPaths
```

### .NET CLI

```bash
dotnet add package ktsu.StrongPaths
```

### Package Reference

```xml
<PackageReference Include="ktsu.StrongPaths" Version="x.y.z" />
```

## Usage Examples

### Basic Example

```csharp
using ktsu.StrongPaths;

// Create strongly-typed paths
AbsoluteDirectoryPath rootDir = (AbsoluteDirectoryPath)@"C:\Projects";
RelativeDirectoryPath subDir = (RelativeDirectoryPath)"MyProject";
FileName configFile = (FileName)"config.json";

// Combine paths with the / operator
AbsoluteFilePath fullPath = rootDir / subDir / configFile;

// Use with standard file operations
File.WriteAllText(fullPath, "{ \"setting\": \"value\" }");
```

### Path Combining with Operators

```csharp
using ktsu.StrongPaths;

public class MyDemoClass
{
    public AbsoluteDirectoryPath OutputDir { get; set; } = (AbsoluteDirectoryPath)@"c:\output";

    public void SaveData(RelativeDirectoryPath subDir, FileName fileName)
    {
        // You can use the / operator to combine paths
        AbsoluteFilePath filePath = OutputDir / subDir / fileName;
        File.WriteAllText(filePath, "Hello, world!");

        // An AbsoluteDirectoryPath combined with a RelativeDirectoryPath returns an AbsoluteDirectoryPath
        AbsoluteDirectoryPath newOutputDir = OutputDir / subDir;

        // An AbsoluteDirectoryPath combined with a FileName returns an AbsoluteFilePath
        AbsoluteFilePath newFilePath = newOutputDir / fileName;
    }
}
```

### Calculating Relative Paths

```csharp
using ktsu.StrongPaths;

AbsoluteDirectoryPath baseDir = (AbsoluteDirectoryPath)@"C:\Projects\MainProject";
AbsoluteDirectoryPath targetDir = (AbsoluteDirectoryPath)@"C:\Projects\MainProject\Submodule\Source";
AbsoluteFilePath targetFile = (AbsoluteFilePath)@"C:\Projects\MainProject\Submodule\Source\Program.cs";

// Get relative paths from one location to another
RelativeDirectoryPath relativeDir = targetDir.RelativeTo(baseDir);  // "Submodule\Source"
RelativeFilePath relativeFile = targetFile.RelativeTo(baseDir);     // "Submodule\Source\Program.cs"
```

## Advanced Usage

### Using Abstract Base Classes

You can use abstract base classes to accept a subset of path types in your method parameters:

```csharp
using ktsu.StrongPaths;

public static class MyDemoClass
{
    public static void SaveData(AnyDirectoryPath outputDir, FileName fileName)
    {
        // You can't use the / operator with the abstract base classes because it has no way of knowing which type to return
        // You have to use the Path.Combine method when using the abstract base classes
        FilePath filePath = (FilePath)Path.Combine(outputDir, fileName);
        File.WriteAllText(filePath, "Hello, World!");
    }

    public static void Demo()
    {
        string storeLocation = "melbourne";
        RelativeDirectoryPath storeDir = (RelativeDirectoryPath)$"store_{storeLocation}";
        FileName fileName = (FileName)$"{DateTime.UtcNow}.json";
        SaveData(storeDir, fileName);
    }
}
```

### Path Validation and Creation

```csharp
using ktsu.StrongPaths;

// Validate paths at creation
try 
{
    // This will throw if the path is invalid
    AbsoluteFilePath invalidPath = (AbsoluteFilePath)"not:a:valid:path";
}
catch (FormatException ex)
{
    Console.WriteLine("Invalid path format: " + ex.Message);
}

// Create a directory if it doesn't exist
AbsoluteDirectoryPath projectDir = (AbsoluteDirectoryPath)@"C:\Projects\NewProject";
if (!Directory.Exists(projectDir))
{
    Directory.CreateDirectory(projectDir);
}
```

## API Reference

### Available Types

#### Concrete Types

| Type | Description |
|------|-------------|
| `AbsolutePath` | Base type for all absolute paths |
| `RelativePath` | Base type for all relative paths |
| `DirectoryPath` | Base type for all directory paths |
| `FilePath` | Base type for all file paths |
| `FileName` | Represents just a filename with extension |
| `FileExtension` | Represents just a file extension |
| `AbsoluteDirectoryPath` | Represents an absolute directory path |
| `RelativeDirectoryPath` | Represents a relative directory path |
| `AbsoluteFilePath` | Represents an absolute file path |
| `RelativeFilePath` | Represents a relative file path |

#### Abstract Base Classes

| Type | Accepted Derived Types |
|------|------------------------|
| `AnyStrongPath` | All concrete path types |
| `AnyRelativePath` | `RelativePath`, `RelativeDirectoryPath`, `RelativeFilePath` |
| `AnyAbsolutePath` | `AbsolutePath`, `AbsoluteDirectoryPath`, `AbsoluteFilePath` |
| `AnyDirectoryPath` | `DirectoryPath`, `AbsoluteDirectoryPath`, `RelativeDirectoryPath` |
| `AnyFilePath` | `FilePath`, `AbsoluteFilePath`, `RelativeFilePath` |

### Key Operations

| Operation | Description |
|-----------|-------------|
| `/` operator | Combines paths with appropriate type safety |
| `RelativeTo(...)` | Calculates a relative path between two locations |
| Type casting | Convert between string and path types with validation |

## Contributing

Contributions are welcome! Please feel free to submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

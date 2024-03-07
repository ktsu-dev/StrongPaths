# StrongPaths

A library that provides strong typing for common filesystem paths providing compile time feedback and runtime validation.

StrongPaths is a collection of classes derived from `ktsu.io.StrongStrings` with added functionality and helper mthods for filesystem paths.

Get familiar with the [StrongStrings](https://github.com/ktsu-io/StrongStrings) library to get the most out of StrongPaths.

## Usage
```csharp
using ktsu.io.StrongPaths;

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

		// You can get a relative path from Absolute/Relative Directory/File paths using the RelativeTo method
		RelativeDirectoryPath relativePath = newOutputDir.RelativeTo(OutputDir);
		RelativeFilePath relativeFilePath = newFilePath.RelativeTo(OutputDir);
		RelativeDirectoryPath relativePath2 = newOutputDir.RelativeTo(filePath);
		RelativeFilePath relativeFilePath2 = newFilePath.RelativeTo(filePath);
	}

	public void Demo()
	{
		string storeLocation = "melbourne";
		RelativeDirectoryPath storeDir = (RelativeDirectoryPath)$"store_{storeLocation}";
		FileName fileName = (FileName)$"{DateTime.UtcNow}.json";
		SaveData(storeDir, fileName);
	}
}

```
## Concrete Types
- `AbsolutePath`
- `RelativePath`
- `DirectoryPath`
- `FilePath`
- `FileName`
- `FileExtension`
- `AbsoluteDirectoryPath`
- `RelativeDirectoryPath`
- `AbsoluteFilePath`
- `RelativeFilePath`

## Abstract Base Classes
You can use these abstract base classes to accept a subset of path types in your method parameters:
- `AnyStrongPath` Accepts any of the concrete types and types derived from them
- `AnyRelativePath` Accepts `RelativePath`, `RelativeDirectroryPath`, `RelativeFilePath`, and types derived from them
- `AnyAbsolutePath` Accepts `AbsolutePath`, `AbsoluteDirectroryPath`, `AbsoluteFilePath`, and types derived from them
- `AnyDirectoryPath` Accepts `DirectoryPath`, `AbsoluteDirectroryPath`, `RelativeDirectroryPath`, and types derived from them
- `AnyFilePath` Accepts `FilePath`, `AbsoluteFilePath`, `RelativeFilePath`, and types derived from them

```csharp
using ktsu.io.StrongPaths;

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

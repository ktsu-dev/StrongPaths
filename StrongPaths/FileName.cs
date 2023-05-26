namespace ktsu.io.StrongPaths;

using StrongStrings;
using Validation;

public interface IFileName : IStrongPath
{
}

/// <summary>
///     Class to represent a FileName that may or may not have an extension, it doesnt really care
/// </summary>
public record FileName : StrongString<FileName, IsPath, IsFile>, IFileName;

/// <summary>
///     Class to represent a FileName that must have an extension
/// </summary>
public record FileNameWithExtension : StrongString<FileNameWithExtension, IsPath, IsFile, HasAnyExtension>, IFileName;

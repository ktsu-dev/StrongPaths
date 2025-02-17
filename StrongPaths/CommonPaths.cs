#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using System.Collections.ObjectModel;

using ktsu.Extensions;

public sealed record class AbsoluteDirectoryPath : AbsolutePathAbstract<AbsoluteDirectoryPath, IsDirectory>
{
	public static AbsoluteFilePath operator /(AbsoluteDirectoryPath left, FileName right) => (AbsoluteFilePath)$"{left}/{right}";
	public static AbsoluteFilePath operator /(AbsoluteDirectoryPath left, RelativeFilePath right) => (AbsoluteFilePath)$"{left}/{right}";
	public static AbsoluteDirectoryPath operator /(AbsoluteDirectoryPath left, RelativeDirectoryPath right) => (AbsoluteDirectoryPath)$"{left}/{right}";
	public RelativeDirectoryPath RelativeTo(AnyStrongPath other) => AnyRelativePath.Make<RelativeDirectoryPath>(from: other, to: this);
	public Collection<AnyAbsolutePath> Contents => AnyDirectoryPath.GetContents((AnyDirectoryPath)WeakString);
	public AbsoluteDirectoryPath Parent => (AbsoluteDirectoryPath)Path.GetDirectoryName(WeakString.Trim(Path.DirectorySeparatorChar).Trim(Path.AltDirectorySeparatorChar));
}
public sealed record class AbsoluteFilePath : AbsolutePathAbstract<AbsoluteFilePath, IsFile>
{
	public RelativeFilePath RelativeTo(AnyStrongPath other) => AnyRelativePath.Make<RelativeFilePath>(from: other, to: this);
	/// <summary>
	///     Returns the last period delimited segment of the FileName including the leading period, or empty if the FileName
	///     has no extension
	/// </summary>
	public FileExtension FileExtension
	{
		get
		{
			string ext = WeakString.Split(separator: '.').Last();
			return ext == WeakString ? (FileExtension)string.Empty : (FileExtension)ext.Prepend(element: '.');
		}
	}

	/// <summary>
	///     Returns all trailing period delimited segments of the FileName including the leading period, or empty if the
	///     FileName has no extensions
	/// </summary>
	public FileExtension FullFileExtension => (FileExtension)((string?)WeakString.Split(separator: '.', count: 2).Skip(count: 1).FirstOrDefault()?.Prepend(element: '.') ?? string.Empty);

	public FileName FileName => (FileName)Path.GetFileName(WeakString);
	public AbsoluteDirectoryPath DirectoryPath => (AbsoluteDirectoryPath)Path.GetDirectoryName(WeakString);

	public AbsoluteFilePath WithFilePrefix(string filePrefix)
	{
		string directory = WeakString.RemoveSuffix(FileName);
		return (AbsoluteFilePath)$"{directory}{filePrefix}{FileName}";
	}
}

public sealed record class RelativeDirectoryPath : RelativePathAbstract<RelativeDirectoryPath, IsDirectory>
{
	public static RelativeFilePath operator /(RelativeDirectoryPath left, FileName right) => (RelativeFilePath)$"{left}/{right}";
	public static RelativeFilePath operator /(RelativeDirectoryPath left, RelativeFilePath right) => (RelativeFilePath)$"{left}/{right}";
	public static RelativeDirectoryPath operator /(RelativeDirectoryPath left, RelativeDirectoryPath right) => (RelativeDirectoryPath)$"{left}/{right}";
	public RelativeDirectoryPath RelativeTo(AnyStrongPath other) => Make<RelativeDirectoryPath>(from: other, to: this);
	public Collection<AnyAbsolutePath> Contents => AnyDirectoryPath.GetContents((AnyDirectoryPath)WeakString);
	public RelativeDirectoryPath Parent => (RelativeDirectoryPath)Path.GetDirectoryName(WeakString.Trim(Path.DirectorySeparatorChar).Trim(Path.AltDirectorySeparatorChar));
}
public sealed record class RelativeFilePath : RelativePathAbstract<RelativeFilePath, IsFile>
{
	public RelativeFilePath RelativeTo(AnyStrongPath other) => Make<RelativeFilePath>(from: other, to: this);

	/// <summary>
	///     Returns the last period delimited segment of the FileName including the leading period, or empty if the FileName
	///     has no extension
	/// </summary>
	public FileExtension FileExtension
	{
		get
		{
			string ext = WeakString.Split(separator: '.').Last();
			return ext == WeakString ? (FileExtension)string.Empty : (FileExtension)ext.Prepend(element: '.');
		}
	}

	/// <summary>
	///     Returns all trailing period delimited segments of the FileName including the leading period, or empty if the
	///     FileName has no extensions
	/// </summary>
	public FileExtension FullFileExtension => (FileExtension)((string?)WeakString.Split(separator: '.', count: 2).Skip(count: 1).FirstOrDefault()?.Prepend(element: '.') ?? string.Empty);

	public FileName FileName => (FileName)Path.GetFileName(WeakString);
	public RelativeDirectoryPath DirectoryPath => (RelativeDirectoryPath)Path.GetDirectoryName(WeakString);

	public RelativeFilePath WithFilePrefix(string filePrefix)
	{
		string directory = WeakString.RemoveSuffix(FileName);
		return (RelativeFilePath)$"{directory}{filePrefix}{FileName}";
	}
}

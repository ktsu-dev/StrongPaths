#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

public record AnyDirectoryPath : StrongPathAbstract<AnyDirectoryPath, IsPath, IsDirectory>
{
	public static Collection<AnyAbsolutePath> GetContents(AnyDirectoryPath directory)
	{
		var contents = new Collection<AnyAbsolutePath>();
		try
		{
			foreach (string path in Directory.GetFileSystemEntries(directory))
			{
				if (File.Exists(path))
				{
					contents.Add((AbsoluteFilePath)path);
				}
				else if (Directory.Exists(path))
				{
					contents.Add((AbsoluteDirectoryPath)path);
				}
			}
		}
		catch (UnauthorizedAccessException)
		{
			// Ignore
		}

		return contents;
	}
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyDirectoryPath<TDerived> : AnyDirectoryPath
	where TDerived : AnyDirectoryPath<TDerived>
{
	public static explicit operator AnyDirectoryPath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyDirectoryPath<TDerived>(string? value) => FromString<TDerived>(value: value);

	public Collection<AnyAbsolutePath> Contents => GetContents(this);
}

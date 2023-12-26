namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyFilePath : StrongPathAbstract<AnyFilePath, IsPath, IsFile>
{
	// ReSharper disable once CollectionNeverUpdated.Global
	public IList<string> ExpectedFileExtensions { get; init; } = new List<string>();

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
	public DirectoryPath DirectoryPath => (DirectoryPath)Path.GetDirectoryName(WeakString);
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyFilePath<TDerived> : AnyFilePath
	where TDerived : AnyFilePath<TDerived>
{
	public static explicit operator AnyFilePath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyFilePath<TDerived>(string? value) => FromString<TDerived>(value: value);
}

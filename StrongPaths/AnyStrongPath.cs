namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;
using StrongStrings;

public abstract record AnyStrongPath : StrongStringAbstract<AnyStrongPath, IsPath>
{
	public bool Exists => Directory.Exists(path: WeakString) || File.Exists(path: WeakString);

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
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public abstract record AnyStrongPath<TDerived> : AnyStrongPath
	where TDerived : AnyStrongPath<TDerived>
{
	public static explicit operator AnyStrongPath<TDerived>(char[]? value) { return FromCharArray<TDerived>(value: value); }
	public static explicit operator AnyStrongPath<TDerived>(string? value) { return FromString<TDerived>(value: value); }
}

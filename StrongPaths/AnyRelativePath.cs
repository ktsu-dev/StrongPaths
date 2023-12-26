namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

public record AnyRelativePath : StrongPathAbstract<AnyRelativePath, IsPath, IsRelative>
{
	//Inspired by: https://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
	public static TDest Make<TDest>(AnyStrongPath from, AnyStrongPath to)
		where TDest : AnyRelativePath
	{
		ArgumentNullException.ThrowIfNull(from, nameof(from));
		ArgumentNullException.ThrowIfNull(to, nameof(to));

		var fromInfo = new FileInfo(fileName: from.ToString(provider: CultureInfo.InvariantCulture)!);
		var toInfo = new FileInfo(fileName: to.ToString(provider: CultureInfo.InvariantCulture)!);

		string fromPath = Path.GetFullPath(path: fromInfo.FullName);
		string toPath = Path.GetFullPath(path: toInfo.FullName);

		var fromUri = new Uri(uriString: fromPath);
		var toUri = new Uri(uriString: toPath);

		var relativeUri = fromUri.MakeRelativeUri(uri: toUri);
		string relativePath = Uri.UnescapeDataString(stringToUnescape: relativeUri.ToString()).Replace(oldChar: '/', newChar: Path.DirectorySeparatorChar).Replace(oldChar: '\\', newChar: Path.DirectorySeparatorChar);

		return FromString<TDest>(value: relativePath);
	}
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyRelativePath<TDerived> : AnyRelativePath
	where TDerived : AnyRelativePath<TDerived>
{
	public static explicit operator AnyRelativePath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyRelativePath<TDerived>(string? value) => FromString<TDerived>(value: value);
}

#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyRelativePath : StrongPathAbstract<AnyRelativePath, IsPath, IsRelative>
{
	//Inspired by: https://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
	public static TDest Make<TDest>(AnyStrongPath from, AnyStrongPath to)
		where TDest : AnyRelativePath
	{
		ArgumentNullException.ThrowIfNull(from, nameof(from));
		ArgumentNullException.ThrowIfNull(to, nameof(to));

		var fromInfo = new FileInfo(fileName: Path.GetFullPath(from));
		var toInfo = new FileInfo(fileName: Path.GetFullPath(to));

		// defining our own directory separator chars because theyre not defined during unit tests which causes the tests to fail
		// we'll use unix style separators because they work on windows too
		const string separator = "/";
		const string altSeparator = "\\";

		string fromPath = Path.GetFullPath(path: fromInfo.FullName).Replace(oldValue: altSeparator, newValue: separator, StringComparison.Ordinal);
		string toPath = Path.GetFullPath(path: toInfo.FullName).Replace(oldValue: altSeparator, newValue: separator, StringComparison.Ordinal);

		bool fromIsDirectory = from switch
		{
			AnyDirectoryPath => true,
			AbsoluteDirectoryPath => true,
			RelativeDirectoryPath => true,
			_ => false
		};

		bool toIsDirectory = to switch
		{
			AnyDirectoryPath => true,
			AbsoluteDirectoryPath => true,
			RelativeDirectoryPath => true,
			_ => false
		};

		if (fromIsDirectory && !fromPath.EndsWith(value: separator, StringComparison.Ordinal))
		{
			fromPath += separator;
		}

		if (toIsDirectory && !toPath.EndsWith(value: separator, StringComparison.Ordinal))
		{
			toPath += separator;
		}

		var fromUri = new Uri(uriString: fromPath);
		var toUri = new Uri(uriString: toPath);

		var relativeUri = fromUri.MakeRelativeUri(uri: toUri);
		string relativePath = Uri.UnescapeDataString(stringToUnescape: relativeUri.ToString());
		relativePath = relativePath.Replace(oldValue: altSeparator, newValue: separator, StringComparison.Ordinal);
		return FromString<TDest>(value: relativePath);
	}
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyRelativePath<TDerived> : AnyRelativePath
	where TDerived : AnyRelativePath<TDerived>
{
	public static explicit operator AnyRelativePath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: MakeCanonical(value));
	public static explicit operator AnyRelativePath<TDerived>(string? value) => FromString<TDerived>(value: MakeCanonical(value));
}

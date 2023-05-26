namespace ktsu.io.StrongPaths;

using System.Globalization;

public record AnyRelativePath : StrongPathAbstract<AnyRelativePath, IsPath, IsRelative>
{
	//Inspired by: https://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
	internal static TDest Make<TDest>(AnyStrongPath from, AnyStrongPath to)
		where TDest : AnyRelativePath
	{
		var fromInfo = new FileInfo(fileName: from.ToString(provider: CultureInfo.InvariantCulture)!);
		var toInfo = new FileInfo(fileName: to.ToString(provider: CultureInfo.InvariantCulture)!);

		string fromPath = Path.GetFullPath(path: fromInfo.FullName);
		string toPath = Path.GetFullPath(path: toInfo.FullName);

		var fromUri = new Uri(uriString: fromPath);
		var toUri = new Uri(uriString: toPath);

		Uri relativeUri = fromUri.MakeRelativeUri(uri: toUri);
		string relativePath = Uri.UnescapeDataString(stringToUnescape: relativeUri.ToString()).Replace(oldChar: '/', newChar: Path.DirectorySeparatorChar).Replace(oldChar: '\\', newChar: Path.DirectorySeparatorChar);

		return FromString<TDest>(value: relativePath);
	}
}

public record AnyRelativePath<TDerived> : AnyRelativePath
	where TDerived : AnyRelativePath<TDerived>;

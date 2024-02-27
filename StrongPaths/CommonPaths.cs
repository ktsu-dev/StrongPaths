#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "We're abusing the divide operator here for path syntax so the Divide method doesnt make sense")]
public sealed record class AbsoluteDirectoryPath : StrongPathAbstract<AbsoluteDirectoryPath, IsDirectory, IsAbsolute>
{
	public static AbsoluteFilePath operator /(AbsoluteDirectoryPath left, FileName right) => (AbsoluteFilePath)$"{left}/{right}";
	public static AbsoluteFilePath operator /(AbsoluteDirectoryPath left, RelativeFilePath right) => (AbsoluteFilePath)$"{left}/{right}";
	public static AbsoluteDirectoryPath operator /(AbsoluteDirectoryPath left, RelativeDirectoryPath right) => (AbsoluteDirectoryPath)$"{left}/{right}";
}
public sealed record class AbsoluteFilePath : StrongPathAbstract<AbsoluteFilePath, IsFile, IsAbsolute> { }

[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "We're abusing the divide operator here for path syntax so the Divide method doesnt make sense")]
public sealed record class RelativeDirectoryPath : StrongPathAbstract<RelativeDirectoryPath, IsDirectory, IsRelative>
{
	public static RelativeFilePath operator /(RelativeDirectoryPath left, FileName right) => (RelativeFilePath)$"{left}/{right}";
	public static RelativeFilePath operator /(RelativeDirectoryPath left, RelativeFilePath right) => (RelativeFilePath)$"{left}/{right}";
	public static RelativeDirectoryPath operator /(RelativeDirectoryPath left, RelativeDirectoryPath right) => (RelativeDirectoryPath)$"{left}/{right}";
}
public sealed record class RelativeFilePath : StrongPathAbstract<RelativeFilePath, IsFile, IsRelative> { }

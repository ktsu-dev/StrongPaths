#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Collections.ObjectModel;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "We're abusing the divide operator here for path syntax so the Divide method doesnt make sense")]
public sealed record class AbsoluteDirectoryPath : AbsolutePathAbstract<AbsoluteDirectoryPath, IsDirectory>
{
	public static AbsoluteFilePath operator /(AbsoluteDirectoryPath left, FileName right) => (AbsoluteFilePath)$"{left}/{right}";
	public static AbsoluteFilePath operator /(AbsoluteDirectoryPath left, RelativeFilePath right) => (AbsoluteFilePath)$"{left}/{right}";
	public static AbsoluteDirectoryPath operator /(AbsoluteDirectoryPath left, RelativeDirectoryPath right) => (AbsoluteDirectoryPath)$"{left}/{right}";
	public RelativeDirectoryPath RelativeTo(AnyStrongPath other) => AnyRelativePath.Make<RelativeDirectoryPath>(from: this, to: other);
	public Collection<AnyAbsolutePath> Contents => AnyDirectoryPath.GetContents((AnyDirectoryPath)WeakString);
}
public sealed record class AbsoluteFilePath : AbsolutePathAbstract<AbsoluteFilePath, IsFile>
{
	public RelativeFilePath RelativeTo(AnyStrongPath other) => AnyRelativePath.Make<RelativeFilePath>(from: this, to: other);
}

[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "We're abusing the divide operator here for path syntax so the Divide method doesnt make sense")]
public sealed record class RelativeDirectoryPath : RelativePathAbstract<RelativeDirectoryPath, IsDirectory>
{
	public static RelativeFilePath operator /(RelativeDirectoryPath left, FileName right) => (RelativeFilePath)$"{left}/{right}";
	public static RelativeFilePath operator /(RelativeDirectoryPath left, RelativeFilePath right) => (RelativeFilePath)$"{left}/{right}";
	public static RelativeDirectoryPath operator /(RelativeDirectoryPath left, RelativeDirectoryPath right) => (RelativeDirectoryPath)$"{left}/{right}";
	public RelativeDirectoryPath RelativeTo(AnyStrongPath other) => Make<RelativeDirectoryPath>(from: this, to: other);
	public Collection<AnyAbsolutePath> Contents => AnyDirectoryPath.GetContents((AnyDirectoryPath)WeakString);
}
public sealed record class RelativeFilePath : RelativePathAbstract<RelativeFilePath, IsFile>
{
	public RelativeFilePath RelativeTo(AnyStrongPath other) => Make<RelativeFilePath>(from: this, to: other);
}

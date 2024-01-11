namespace ktsu.io.StrongPaths;

public sealed record class AbsoluteDirectoryPath : StrongPathAbstract<AbsoluteDirectoryPath, IsDirectory, IsAbsolute> { }
public sealed record class AbsoluteFilePath : StrongPathAbstract<AbsoluteFilePath, IsFile, IsAbsolute> { }
public sealed record class RelativeDirectoryPath : StrongPathAbstract<RelativeDirectoryPath, IsDirectory, IsRelative> { }
public sealed record class RelativeFilePath : StrongPathAbstract<RelativeFilePath, IsFile, IsRelative> { }

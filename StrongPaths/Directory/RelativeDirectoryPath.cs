namespace ktsu.io.StrongPaths
{
	/// <summary>
	/// A DirectoryPath that is relative to some other StrongPath
	/// </summary>
	public sealed record class RelativeDirectoryPath : RelativePath<RelativeDirectoryPath>, IRelativePath
	{
		public RelativeDirectoryPath Combine(DirectoryName directoryName) => (RelativeDirectoryPath)Path.Combine(Path.GetFullPath(this), directoryName);
		public RelativeFilePath Combine(FileName fileName) => (RelativeFilePath)Path.Combine(Path.GetFullPath(this), fileName);
		public RelativeFilePath Combine(RelativeFilePath relativeFilePath) => (RelativeFilePath)Path.Combine(Path.GetFullPath(this), relativeFilePath);
		public static RelativeDirectoryPath Make(IStrongPath from, DirectoryPath to)
		{
			return from is null
				? throw new ArgumentNullException(nameof(from))
				: to is null
				? throw new ArgumentNullException(nameof(to))
				: RelativePathFactory.Make<RelativeDirectoryPath>(from, to);
		}

		public static RelativeDirectoryPath Make(IStrongPath from, RelativeDirectoryPath to)
		{
			return from is null
				? throw new ArgumentNullException(nameof(from))
				: to is null
				? throw new ArgumentNullException(nameof(to))
				: RelativePathFactory.Make<RelativeDirectoryPath>(from, to);
		}
	}
}

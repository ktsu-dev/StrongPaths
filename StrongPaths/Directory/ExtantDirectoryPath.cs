namespace ktsu.io.StrongPaths
{
	public sealed record class ExtantDirectoryPath : StrongPath<ExtantDirectoryPath>
	{
		//TODO: validate on creation that this path is a directory and that it is absolute and that it exists
		public DirectoryPath Combine(DirectoryName directoryName) => (DirectoryPath)Path.GetFullPath(Path.Combine(Path.GetFullPath(this), directoryName));
		public DirectoryPath Combine(RelativeDirectoryPath relativeDirectoryPath) => (DirectoryPath)Path.GetFullPath(Path.Combine(Path.GetFullPath(this), relativeDirectoryPath));
		public FilePath Combine(FileName fileName) => (FilePath)Path.Combine(Path.GetFullPath(this), fileName);
		public FilePath Combine(RelativeFilePath relativeFilePath) => (FilePath)Path.Combine(Path.GetFullPath(this), relativeFilePath);
	}
}

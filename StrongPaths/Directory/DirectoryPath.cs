namespace ktsu.io.StrongPaths
{
	public interface IDirectoryPath : IStrongPath { }

	public sealed record class DirectoryPath : StrongPath<DirectoryPath>, IDirectoryPath
	{
		//TODO: validate on creation that this path is a directory and that it is absolute
		public DirectoryPath Combine(DirectoryName directoryName) => (DirectoryPath)Path.GetFullPath(Path.Combine(Path.GetFullPath(this), directoryName));
		public DirectoryPath Combine(RelativeDirectoryPath relativeDirectoryPath) => (DirectoryPath)Path.GetFullPath(Path.Combine(Path.GetFullPath(this), relativeDirectoryPath));
		public FilePath Combine(FileName fileName) => (FilePath)Path.Combine(Path.GetFullPath(this), fileName);
		public FilePath Combine(RelativeFilePath relativeFilePath) => (FilePath)Path.Combine(Path.GetFullPath(this), relativeFilePath);
	}
}

namespace ktsu.io.StrongPaths
{
	public interface IFilePath : IStrongPath { }

	public abstract record class FilePath<T> : StrongPath<FilePath<T>>, IFilePath where T : FilePath<T>
	{
		public FileExtension RequiredExtension { get; init; } = (FileExtension)string.Empty;
		public FileName FileName => (FileName)Path.GetFileName(this);
		public abstract DirectoryPath DirectoryPath { get; } // => (DirectoryPath)Path.GetDirectoryName(Path.GetFullPath(this)); //TODO: make this respect relative/absolute
		public override bool IsValid() => base.IsValid() && !string.IsNullOrEmpty(Path.GetFileName(Value));
	}
}

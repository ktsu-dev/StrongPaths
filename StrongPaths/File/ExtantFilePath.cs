namespace ktsu.io.StrongPaths
{
	public sealed record class ExtantFilePath : StrongPath<ExtantFilePath>
	{
		//TODO: validate on creation that this path is a file and that it is absolute and that it exists
		public FileName FileName => (FileName)Path.GetFileName(this);
		public DirectoryPath DirectoryPath => (DirectoryPath)Path.GetDirectoryName(Path.GetFullPath(this));
		public override bool IsValid()
		{
			if (!base.IsValid())
			{
				return false;
			}

			try
			{
				bool isFullyQualified = Path.IsPathFullyQualified(Value);
				bool hasFileName = !string.IsNullOrEmpty(Path.GetFileName(Value));

				FileInfo fileInfo = new(Value);

				return isFullyQualified && !hasFileName;


			}
			catch (NotSupportedException) { }
			catch (PathTooLongException) { }

			return false;
		}
	}
}

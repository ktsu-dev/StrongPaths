namespace ktsu.io.StrongPaths
{
	/// <summary>
	/// A FilePath that is relative to some other StrongPath
	/// </summary>
	public sealed record class RelativeFilePath : RelativePath<RelativeFilePath>, IFilePath
	{
		public static RelativeFilePath Make(IStrongPath from, IFilePath to)
		{
			return from is null
				? throw new ArgumentNullException(nameof(from))
				: to is null
				? throw new ArgumentNullException(nameof(to))
				: RelativePathFactory.Make<RelativeFilePath>(from, to);
		}
	}
}

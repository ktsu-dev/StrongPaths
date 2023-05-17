namespace ktsu.io.StrongPaths
{
	public sealed record class FileExtension : StrongPath<FileExtension>
	{
		public override bool IsValid() => base.IsValid() && Value.StartsWith(".", StringComparison.Ordinal);
	}
}

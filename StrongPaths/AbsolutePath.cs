namespace ktsu.io.StrongPaths
{
	public interface IAbsolutePath : IStrongPath { }

	public abstract record class AbsolutePath<T> : StrongPath<AbsolutePath<T>>, IAbsolutePath where T : AbsolutePath<T>
	{
		public override bool IsValid() => base.IsValid() && Path.IsPathFullyQualified(Value);
	}
}

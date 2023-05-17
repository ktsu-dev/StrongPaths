using ktsu.io.StrongStrings;

namespace ktsu.io.StrongPaths
{
	public interface IStrongPath : IStrongString { }

	public record class StrongPath<T> : StrongString<T>, IStrongPath where T : StrongPath<T>
	{
		public override bool IsValid()
		{
			return base.IsValid()
				&& !string.IsNullOrWhiteSpace(Value)
				&& Value.Length <= 256
				&& !Value.Intersect(Path.GetInvalidPathChars()).Any();
		}
	}
}

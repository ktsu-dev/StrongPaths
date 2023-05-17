namespace ktsu.io.StrongPaths
{
	public interface IRelativePath : IStrongPath { }

	/// <summary>
	/// A base class to derive the other relative path classes from.
	/// </summary>
	/// <typeparam name="T">The type of the derived class inheriting from this class.</typeparam>
	public abstract record class RelativePath<T> : StrongPath<RelativePath<T>>, IRelativePath where T : RelativePath<T>
	{
		public override bool IsValid() => base.IsValid() && !Path.IsPathFullyQualified(Value);

		/// <summary>
		/// A helper class to make relative paths from two IStrongPaths.
		/// Called by the Make methods in the derived RelativePath classes.
		/// </summary>
		protected static class RelativePathFactory
		{
			//Inspired by: https://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
			internal static TDest Make<TDest>(IStrongPath from, IStrongPath to) where TDest : RelativePath<T>, new()
			{
				var fromInfo = new FileInfo(from.ToString()!);
				var toInfo = new FileInfo(to.ToString()!);

				string fromPath = Path.GetFullPath(fromInfo.FullName);
				string toPath = Path.GetFullPath(toInfo.FullName);

				var fromUri = new Uri(fromPath);
				var toUri = new Uri(toPath);

				var relativeUri = fromUri.MakeRelativeUri(toUri);
				string relativePath = Uri.UnescapeDataString(relativeUri.ToString())
					.Replace('/', Path.DirectorySeparatorChar)
					.Replace('\\', Path.DirectorySeparatorChar);

				return (TDest)new TDest().FromString(relativePath);
			}
		}
	}
}

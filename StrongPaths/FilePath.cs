namespace ktsu.io.StrongPaths
{
	using StrongStrings;
	using Validation;

	public interface IFilePath : IStrongPath
	{
	}

	namespace Internal
	{
		using StrongStrings;
		using Validation;

		public abstract record FilePathBase : StrongString<FilePath, IsPath, IsFile>, IFilePath;
	}

	public record FilePath : StrongString<FilePath, IsPath, IsFile>, IFilePath;

	public record FilePath<TValidator> : StrongString<FilePath<TValidator>, IsPath, IsFile, TValidator>, IFilePath
		where TValidator : IValidator;

	public record FilePath<TValidator1, TValidator2> : StrongString<FilePath<TValidator1, TValidator2>, IsPath, IsFile, TValidator1, TValidator2>, IFilePath
		where TValidator1 : IValidator
		where TValidator2 : IValidator;

	public record FilePath<TValidator1, TValidator2, TValidator3> : StrongString<FilePath<TValidator1, TValidator2, TValidator3>, IsPath, IsFile, TValidator1, TValidator2, TValidator3>, IFilePath
		where TValidator1 : IValidator
		where TValidator2 : IValidator
		where TValidator3 : IValidator;
}

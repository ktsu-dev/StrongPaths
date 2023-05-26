namespace ktsu.io.StrongPaths;

using StrongStrings;
using Validation;

public interface IAbsolutePath : IStrongPath
{
}

public record AbsolutePath : StrongString<AbsolutePath, IsPath, IsAbsolute>, IAbsolutePath;

public record AbsolutePath<TValidator> : StrongString<AbsolutePath<TValidator>, IsPath, IsAbsolute, TValidator>, IAbsolutePath
	where TValidator : IValidator;

public record AbsolutePath<TValidator1, TValidator2> : StrongString<AbsolutePath<TValidator1, TValidator2>, IsPath, IsAbsolute, TValidator1, TValidator2>, IAbsolutePath
	where TValidator1 : IValidator
	where TValidator2 : IValidator;

public record AbsolutePath<TValidator1, TValidator2, TValidator3> : StrongString<AbsolutePath<TValidator1, TValidator2, TValidator3>, IsPath, IsAbsolute, TValidator1, TValidator2, TValidator3>, IAbsolutePath
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator;

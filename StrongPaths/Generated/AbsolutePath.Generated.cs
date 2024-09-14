#pragma warning disable CS1591
// Generated code. Do not modify.
namespace ktsu.StrongPaths;

public sealed record AbsolutePath
		: AbsolutePathAbstract<AbsolutePath>;

public sealed record AbsolutePath<TValidator>
		: AbsolutePathAbstract<AbsolutePath<TValidator>, TValidator>
		where TValidator : ktsu.StrongStrings.IValidator;

public sealed record AbsolutePath<TValidator1, TValidator2>
	: AbsolutePathAbstract<AbsolutePath<TValidator1, TValidator2>, TValidator1, TValidator2>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator;

public sealed record AbsolutePath<TValidator1, TValidator2, TValidator3>
	: AbsolutePathAbstract<AbsolutePath<TValidator1, TValidator2, TValidator3>, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator;

public sealed record AbsolutePath<TValidator1, TValidator2, TValidator3, TValidator4>
	: AbsolutePathAbstract<AbsolutePath<TValidator1, TValidator2, TValidator3, TValidator4>, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
	where TValidator4 : ktsu.StrongStrings.IValidator;

public sealed record AbsolutePath<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	: AbsolutePathAbstract<AbsolutePath<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
	where TValidator4 : ktsu.StrongStrings.IValidator
	where TValidator5 : ktsu.StrongStrings.IValidator;
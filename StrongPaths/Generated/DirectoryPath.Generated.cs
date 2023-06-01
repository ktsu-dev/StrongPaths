// Generated code. Do not modify.
namespace ktsu.io.StrongPaths;

public sealed record DirectoryPath
		: DirectoryPathAbstract<DirectoryPath>;

public sealed record DirectoryPath<TValidator>
		: DirectoryPathAbstract<DirectoryPath<TValidator>, TValidator>
		where TValidator : ktsu.io.StrongStrings.IValidator;

public sealed record DirectoryPath<TValidator1, TValidator2>
	: DirectoryPathAbstract<DirectoryPath<TValidator1, TValidator2>, TValidator1, TValidator2>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator;

public sealed record DirectoryPath<TValidator1, TValidator2, TValidator3>
	: DirectoryPathAbstract<DirectoryPath<TValidator1, TValidator2, TValidator3>, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator;

public sealed record DirectoryPath<TValidator1, TValidator2, TValidator3, TValidator4>
	: DirectoryPathAbstract<DirectoryPath<TValidator1, TValidator2, TValidator3, TValidator4>, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator;

public sealed record DirectoryPath<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	: DirectoryPathAbstract<DirectoryPath<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator
	where TValidator5 : ktsu.io.StrongStrings.IValidator;
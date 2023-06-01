// Generated code. Do not modify.
namespace ktsu.io.StrongPaths;

public sealed record FileName
		: FileNameAbstract<FileName>;

public sealed record FileName<TValidator>
		: FileNameAbstract<FileName<TValidator>, TValidator>
		where TValidator : ktsu.io.StrongStrings.IValidator;

public sealed record FileName<TValidator1, TValidator2>
	: FileNameAbstract<FileName<TValidator1, TValidator2>, TValidator1, TValidator2>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator;

public sealed record FileName<TValidator1, TValidator2, TValidator3>
	: FileNameAbstract<FileName<TValidator1, TValidator2, TValidator3>, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator;

public sealed record FileName<TValidator1, TValidator2, TValidator3, TValidator4>
	: FileNameAbstract<FileName<TValidator1, TValidator2, TValidator3, TValidator4>, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator;

public sealed record FileName<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	: FileNameAbstract<FileName<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator
	where TValidator5 : ktsu.io.StrongStrings.IValidator;
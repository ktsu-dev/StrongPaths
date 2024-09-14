#pragma warning disable CS1591
// Generated code. Do not modify.
namespace ktsu.StrongPaths;

public abstract record DirectoryPathAbstract<TDerived> : AnyDirectoryPath<TDerived>
	where TDerived : DirectoryPathAbstract<TDerived>;

public abstract record DirectoryPathAbstract<TDerived, TValidator> : AnyDirectoryPath<TDerived>
	where TDerived : DirectoryPathAbstract<TDerived, TValidator>
	where TValidator : ktsu.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator, ktsu.StrongStrings.NoValidator, ktsu.StrongStrings.NoValidator, ktsu.StrongStrings.NoValidator, ktsu.StrongStrings.NoValidator>(value: this); }
}

public abstract record DirectoryPathAbstract<TDerived, TValidator1, TValidator2> : AnyDirectoryPath<TDerived>
	where TDerived : DirectoryPathAbstract<TDerived, TValidator1, TValidator2>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, ktsu.StrongStrings.NoValidator, ktsu.StrongStrings.NoValidator, ktsu.StrongStrings.NoValidator>(value: this); }
}

public abstract record DirectoryPathAbstract<TDerived, TValidator1, TValidator2, TValidator3> : AnyDirectoryPath<TDerived>
	where TDerived : DirectoryPathAbstract<TDerived, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, ktsu.StrongStrings.NoValidator, ktsu.StrongStrings.NoValidator>(value: this); }
}

public abstract record DirectoryPathAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4> : AnyDirectoryPath<TDerived>
	where TDerived : DirectoryPathAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
	where TValidator4 : ktsu.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, ktsu.StrongStrings.NoValidator>(value: this); }
}

public abstract record DirectoryPathAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5> : AnyDirectoryPath<TDerived>
	where TDerived : DirectoryPathAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
	where TValidator4 : ktsu.StrongStrings.IValidator
	where TValidator5 : ktsu.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(value: this); }
}
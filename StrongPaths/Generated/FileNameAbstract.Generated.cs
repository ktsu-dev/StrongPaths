#pragma warning disable CS1591
// Generated code. Do not modify.
namespace ktsu.io.StrongPaths;

public abstract record FileNameAbstract<TDerived> : AnyFileName<TDerived>
	where TDerived : FileNameAbstract<TDerived>;

public abstract record FileNameAbstract<TDerived, TValidator> : AnyFileName<TDerived>
	where TDerived : FileNameAbstract<TDerived, TValidator>
	where TValidator : ktsu.io.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator, ktsu.io.StrongStrings.NoValidator, ktsu.io.StrongStrings.NoValidator, ktsu.io.StrongStrings.NoValidator, ktsu.io.StrongStrings.NoValidator>(value: this); }
}

public abstract record FileNameAbstract<TDerived, TValidator1, TValidator2> : AnyFileName<TDerived>
	where TDerived : FileNameAbstract<TDerived, TValidator1, TValidator2>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, ktsu.io.StrongStrings.NoValidator, ktsu.io.StrongStrings.NoValidator, ktsu.io.StrongStrings.NoValidator>(value: this); }
}

public abstract record FileNameAbstract<TDerived, TValidator1, TValidator2, TValidator3> : AnyFileName<TDerived>
	where TDerived : FileNameAbstract<TDerived, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, ktsu.io.StrongStrings.NoValidator, ktsu.io.StrongStrings.NoValidator>(value: this); }
}

public abstract record FileNameAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4> : AnyFileName<TDerived>
	where TDerived : FileNameAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, ktsu.io.StrongStrings.NoValidator>(value: this); }
}

public abstract record FileNameAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5> : AnyFileName<TDerived>
	where TDerived : FileNameAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator
	where TValidator5 : ktsu.io.StrongStrings.IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(value: this); }
}
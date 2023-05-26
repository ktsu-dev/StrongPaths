namespace ktsu.io.StrongPaths;

using StrongStrings;

public abstract record AnyStrongPath : StrongStringAbstract<AnyStrongPath, IsPath>
{
	public bool Exists => Directory.Exists(path: WeakString) || File.Exists(path: WeakString);

	// ReSharper disable once CollectionNeverUpdated.Global
	public IList<string> ExpectedFileExtensions { get; init; } = new List<string>();

	/// <summary>
	///     Returns the last period delimited segment of the FileName including the leading period, or empty if the FileName
	///     has no extension
	/// </summary>
	public FileExtension FileExtension
	{
		get
		{
			string ext = WeakString.Split(separator: '.').Last();
			return ext == WeakString ? (FileExtension)string.Empty : (FileExtension)ext.Prepend(element: '.');
		}
	}

	/// <summary>
	///     Returns all trailing period delimited segments of the FileName including the leading period, or empty if the
	///     FileName has no extensions
	/// </summary>
	public FileExtension FullFileExtension => (FileExtension)((string?)WeakString.Split(separator: '.', count: 2).Skip(count: 1).FirstOrDefault()?.Prepend(element: '.') ?? string.Empty);
}

public abstract record AnyStrongPath<TDerived> : AnyStrongPath
	where TDerived : AnyStrongPath<TDerived>;

public abstract record AnyStrongPath<TDerived, TValidator> : AnyStrongPath<TDerived>
	where TDerived : AnyStrongPath<TDerived, TValidator>
	where TValidator : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator, NoValidator, NoValidator, NoValidator, NoValidator>(value: this); }
}

public abstract record AnyStrongPath<TDerived, TValidator1, TValidator2> : AnyStrongPath<TDerived>
	where TDerived : AnyStrongPath<TDerived, TValidator1, TValidator2>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, NoValidator, NoValidator, NoValidator>(value: this); }
}

public abstract record AnyStrongPath<TDerived, TValidator1, TValidator2, TValidator3> : AnyStrongPath<TDerived>
	where TDerived : AnyStrongPath<TDerived, TValidator1, TValidator2, TValidator3>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, NoValidator, NoValidator>(value: this); }
}

public abstract record AnyStrongPath<TDerived, TValidator1, TValidator2, TValidator3, TValidator4> : AnyStrongPath<TDerived>
	where TDerived : AnyStrongPath<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator
	where TValidator4 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, NoValidator>(value: this); }
}

public abstract record AnyStrongPath<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5> : AnyStrongPath<TDerived>
	where TDerived : AnyStrongPath<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator
	where TValidator4 : IValidator
	where TValidator5 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(value: this); }
}

// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using System.Diagnostics.CodeAnalysis;

using ktsu.Extensions;
using ktsu.StrongStrings;

public abstract record AnyStrongPath : StrongStringAbstract<AnyStrongPath, IsPath>
{
	public bool Exists => IsDirectory || IsFile;
	public bool IsDirectory => Directory.Exists(path: WeakString);
	public bool IsFile => File.Exists(path: WeakString);

	protected override string MakeCanonical(string input) => base.MakeCanonical(input).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).RemoveSuffix(new string([Path.DirectorySeparatorChar]));
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public abstract record AnyStrongPath<TDerived> : AnyStrongPath
	where TDerived : AnyStrongPath<TDerived>
{
	public static explicit operator AnyStrongPath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyStrongPath<TDerived>(string? value) => FromString<TDerived>(value: value);

	public new TDerived WithPrefix(string prefix) => (TDerived)$"{prefix}{this}";
	public new TDerived WithSuffix(string suffix) => (TDerived)$"{this}{suffix}";
}

// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyFileName : StrongPathAbstract<AnyFileName, IsPath, IsFileName>;

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyFileName<TDerived> : AnyFileName
	where TDerived : AnyFileName<TDerived>
{
	public static explicit operator AnyFileName<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyFileName<TDerived>(string? value) => FromString<TDerived>(value: value);

	public new TDerived WithPrefix(string prefix) => (TDerived)$"{prefix}{this}";
	public new TDerived WithSuffix(string suffix) => (TDerived)$"{this}{suffix}";
}

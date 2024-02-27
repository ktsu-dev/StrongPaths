#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;
using StrongStrings;

public abstract record AnyStrongPath : StrongStringAbstract<AnyStrongPath, IsPath>
{
	public bool Exists => Directory.Exists(path: WeakString) || File.Exists(path: WeakString);
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public abstract record AnyStrongPath<TDerived> : AnyStrongPath
	where TDerived : AnyStrongPath<TDerived>
{
	public static explicit operator AnyStrongPath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyStrongPath<TDerived>(string? value) => FromString<TDerived>(value: value);
}

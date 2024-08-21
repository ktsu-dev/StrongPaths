#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyFileName : StrongPathAbstract<AnyFileName, IsPath, IsFileName>;

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyFileName<TDerived> : AnyFileName
	where TDerived : AnyFileName<TDerived>
{
	public static explicit operator AnyFileName<TDerived>(char[]? value) => FromCharArray<TDerived>(value: MakeCanonical(value));
	public static explicit operator AnyFileName<TDerived>(string? value) => FromString<TDerived>(value: MakeCanonical(value));
}

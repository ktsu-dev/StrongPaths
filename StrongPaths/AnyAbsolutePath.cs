#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyAbsolutePath : StrongPathAbstract<AnyAbsolutePath, IsPath, IsAbsolute>;

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyAbsolutePath<TDerived> : AnyAbsolutePath
	where TDerived : AnyAbsolutePath<TDerived>
{
	public static explicit operator AnyAbsolutePath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: MakeCanonical(value));
	public static explicit operator AnyAbsolutePath<TDerived>(string? value) => FromString<TDerived>(value: MakeCanonical(value));

	public new TDerived WithPrefix(string prefix) => (TDerived)$"{prefix}{this}";
	public new TDerived WithSuffix(string suffix) => (TDerived)$"{this}{suffix}";
}

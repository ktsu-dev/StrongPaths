namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyAbsolutePath : StrongPathAbstract<AnyAbsolutePath, IsPath, IsAbsolute>;

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyAbsolutePath<TDerived> : AnyAbsolutePath
	where TDerived : AnyAbsolutePath<TDerived>
{
	public static explicit operator AnyAbsolutePath<TDerived>(char[]? value) { return FromCharArray<TDerived>(value: value); }
	public static explicit operator AnyAbsolutePath<TDerived>(string? value) { return FromString<TDerived>(value: value); }
}

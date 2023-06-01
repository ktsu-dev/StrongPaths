namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyFilePath : StrongPathAbstract<AnyFilePath, IsPath, IsFile>;

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyFilePath<TDerived> : AnyFilePath
	where TDerived : AnyFilePath<TDerived>
{
	public static explicit operator AnyFilePath<TDerived>(char[]? value) { return FromCharArray<TDerived>(value: value); }
	public static explicit operator AnyFilePath<TDerived>(string? value) { return FromString<TDerived>(value: value); }
}

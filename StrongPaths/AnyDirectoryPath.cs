#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;

public record AnyDirectoryPath : StrongPathAbstract<AnyDirectoryPath, IsPath, IsDirectory>;

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public record AnyDirectoryPath<TDerived> : AnyDirectoryPath
	where TDerived : AnyDirectoryPath<TDerived>
{
	public static explicit operator AnyDirectoryPath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);
	public static explicit operator AnyDirectoryPath<TDerived>(string? value) => FromString<TDerived>(value: value);
}

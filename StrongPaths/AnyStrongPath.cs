#pragma warning disable CS1591

namespace ktsu.io.StrongPaths;

using System.Diagnostics.CodeAnalysis;
using ktsu.io.Extensions;
using StrongStrings;

public abstract record AnyStrongPath : StrongStringAbstract<AnyStrongPath, IsPath>
{
	public bool Exists => IsDirectory || IsFile;
	public bool IsDirectory => Directory.Exists(path: WeakString);
	public bool IsFile => File.Exists(path: WeakString);
	public static string MakeCanonical(string? input)
	{
		ArgumentNullException.ThrowIfNull(input);
		return input.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).RemoveSuffix(new string([Path.DirectorySeparatorChar]));
	}

	public static char[]? MakeCanonical(char[]? input)
	{
		ArgumentNullException.ThrowIfNull(input);
		return MakeCanonical(new string(input)).ToCharArray();
	}
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public abstract record AnyStrongPath<TDerived> : AnyStrongPath
	where TDerived : AnyStrongPath<TDerived>
{
	public static explicit operator AnyStrongPath<TDerived>(char[]? value) => FromCharArray<TDerived>(value: MakeCanonical(value));
	public static explicit operator AnyStrongPath<TDerived>(string? value) => FromString<TDerived>(value: MakeCanonical(value));

	public new TDerived WithPrefix(string prefix) => (TDerived)$"{prefix}{this}";
	public new TDerived WithSuffix(string suffix) => (TDerived)$"{this}{suffix}";
}

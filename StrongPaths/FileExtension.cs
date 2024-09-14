#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using StrongStrings;

public sealed record FileExtension : StrongStringAbstract<FileExtension, IsPath, IsExtension>;

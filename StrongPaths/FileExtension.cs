// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using StrongStrings;

public sealed record FileExtension : StrongStringAbstract<FileExtension, IsPath, IsExtension>;

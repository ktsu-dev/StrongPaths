// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.StrongPaths;

using StrongStrings;

public abstract class IsPath : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || (strongString.Length <= 256 && !strongString.Intersect(second: Path.GetInvalidPathChars()).Any());
	}
}

public abstract class IsRelative : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || !Path.IsPathFullyQualified(path: strongString);
	}
}

public abstract class IsAbsolute : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || Path.IsPathFullyQualified(path: strongString + Path.DirectorySeparatorChar);
	}
}

public abstract class IsDirectory : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || !File.Exists(path: strongString);
	}
}

public abstract class IsFile : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || !Directory.Exists(path: strongString);
	}
}

public abstract class IsFileName : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || (!Directory.Exists(path: strongString) && !strongString.Intersect(second: Path.GetInvalidFileNameChars()).Any());
	}
}

public abstract class DoesExist : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		return strongString switch
		{
			null => throw new ArgumentNullException(paramName: nameof(strongString)),
			AnyStrongPath path => path.Exists,
			_ => false,
		};
	}
}

public abstract class HasAnyExtension : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString is AnyFilePath filePath && string.IsNullOrEmpty(value: filePath.FileExtension);
	}
}

public abstract class HasSpecificExtension : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString is AnyFilePath filePath && filePath.ExpectedFileExtensions.Contains(item: filePath.FileExtension);
	}
}

public abstract class IsExtension : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		ArgumentNullException.ThrowIfNull(strongString);

		return strongString.IsEmpty() || strongString.StartsWith(value: ".", comparisonType: StringComparison.Ordinal);
	}
}

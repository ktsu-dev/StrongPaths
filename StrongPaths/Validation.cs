namespace ktsu.io.StrongPaths;

using StrongStrings;

public abstract class IsPath : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return strongString.Length is > 0 and <= 256 && !strongString.Intersect(second: Path.GetInvalidPathChars()).Any();
	}
}

public abstract class IsRelative : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return !Path.IsPathFullyQualified(path: strongString);
	}
}

public abstract class IsAbsolute : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return Path.IsPathFullyQualified(path: strongString);
	}
}

public abstract class IsDirectory : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return !string.IsNullOrEmpty(value: Path.GetDirectoryName(path: strongString)) && !File.Exists(path: strongString);
	}
}

public abstract class IsFile : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return !string.IsNullOrEmpty(value: Path.GetFileName(path: strongString)) && !Directory.Exists(path: strongString);
	}
}

public abstract class IsFileName : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return !string.IsNullOrEmpty(value: Path.GetFileName(path: strongString)) && !Directory.Exists(path: strongString) && !strongString.Intersect(second: Path.GetInvalidFileNameChars()).Any();
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
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return strongString is AnyFilePath filePath && string.IsNullOrEmpty(value: filePath.FileExtension);
	}
}

public abstract class HasSpecificExtension : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return strongString is AnyFilePath filePath && filePath.ExpectedFileExtensions.Contains(item: filePath.FileExtension);
	}
}

public abstract class IsExtension : IValidator
{
	public static bool IsValid(AnyStrongString? strongString)
	{
		if (strongString is null)
		{
			throw new ArgumentNullException(paramName: nameof(strongString));
		}

		return strongString.StartsWith(value: ".", comparisonType: StringComparison.Ordinal);
	}
}

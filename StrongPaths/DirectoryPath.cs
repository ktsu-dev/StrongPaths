namespace ktsu.io.StrongPaths;

using StrongStrings;
using Validation;

public interface IDirectoryPath : IStrongPath
{
	public IReadOnlyCollection<IFilePath> FindFileInAncestors(FileName fileName)
	{
		HashSet<IFilePath> discoveredFilePaths = new();
		FindFileInAncestorsInternal(fileName: fileName, discoveredFilePaths: discoveredFilePaths);
		return discoveredFilePaths;
	}

	private IReadOnlyCollection<IFilePath> FindFileInAncestorsInternal(FileName fileName, ICollection<IFilePath> discoveredFilePaths)
	{
		//TODO: Implement FindFileInAncestors
		foreach (string filePath in Directory.EnumerateFiles(path: WeakString, searchPattern: fileName, searchOption: SearchOption.TopDirectoryOnly))
		{
			var extantFilePath = (FilePath<IsAbsolute, DoesExist>)filePath;
			if (extantFilePath.FileName == fileName)
			{
				discoveredFilePaths.Add(item: extantFilePath);
			}
		}
	}
}

public record DirectoryPath : StrongString<DirectoryPath, IsPath, IsDirectory>, IAbsolutePath
{
	public static T Combine<T>(T directoryPath, DirectoryName directoryName)
		where T : StrongString<T>, IDirectoryPath
	{
		return (T)Path.GetFullPath(path: Path.Combine(Path.GetFullPath(path: directoryPath), directoryName));
	}

	public static T Combine<T>(T directoryPath, RelativeDirectoryPath relativeDirectoryPath)
		where T : StrongString<T>, IDirectoryPath
	{
		return (T)Path.GetFullPath(path: Path.Combine(Path.GetFullPath(path: directoryPath), relativeDirectoryPath));
	}
}

public record DirectoryPath<TValidator> : StrongString<DirectoryPath<TValidator>, IsPath, IsDirectory, TValidator>, IFilePath
	where TValidator : IValidator;

public record DirectoryPath<TValidator1, TValidator2> : StrongString<DirectoryPath<TValidator1, TValidator2>, IsPath, IsDirectory, TValidator1, TValidator2>, IFilePath
	where TValidator1 : IValidator
	where TValidator2 : IValidator;

public record DirectoryPath<TValidator1, TValidator2, TValidator3> : StrongString<DirectoryPath<TValidator1, TValidator2, TValidator3>, IsPath, IsDirectory, TValidator1, TValidator2, TValidator3>, IFilePath
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator;

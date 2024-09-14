namespace ktsu.StrongPaths.Test;
#pragma warning disable CS0219
#pragma warning disable CS1591

[TestClass]
public class Tests
{
	private static string Yeet => "Yeet";
	private static string DotYeet => ".Yeet";
	private static string KtsuDotIoDotYeet => "ktsu.io.Yeet";
	private static string FullyQualifiedPath => Environment.CurrentDirectory;

	[TestMethod]
	public void TestStrongPath()
	{
		var path1 = (StrongPath)Yeet;
		var path2 = (StrongPath)FullyQualifiedPath;
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => { _ = (StrongPath)(string)null!; });
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (StrongPath)Path.GetInvalidFileNameChars());
	}

	[TestMethod]
	public void TestAbsolutPath()
	{
		var path = (AbsolutePath)FullyQualifiedPath;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (AbsolutePath)Yeet);
	}

	[TestMethod]
	public void TestRelativePath()
	{
		var path = (RelativePath)Yeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (RelativePath)FullyQualifiedPath);
	}

	[TestMethod]
	public void TestFileName()
	{
		var path = (FileName)DotYeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (FileName)Path.GetInvalidFileNameChars());
	}

	[TestMethod]
	public void TestDirectoryPath()
	{
		var path = (DirectoryPath)FullyQualifiedPath;
		var path2 = (DirectoryPath)KtsuDotIoDotYeet;
		File.WriteAllText(path: DotYeet, contents: Yeet);
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (DirectoryPath)DotYeet);
	}

	[TestMethod]
	public void TestFilePath()
	{
		var path = (FilePath)DotYeet;
		Directory.CreateDirectory(path: Yeet);
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (FilePath)Yeet);
	}

	[TestMethod]
	public void TestFileExtension()
	{
		var path = (FileExtension)DotYeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (FileExtension)Yeet);
	}

	[TestMethod]
	public void TestRelativeDirectoryPath()
	{
		var path = (RelativeDirectoryPath)Yeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (RelativeDirectoryPath)FullyQualifiedPath);
	}

	[TestMethod]
	public void TestRelativeFilePath()
	{
		var path = (RelativeFilePath)DotYeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (RelativeFilePath)FullyQualifiedPath);
	}

	[TestMethod]
	public void TestAnyAbsolutePath()
	{
		var path = (AnyAbsolutePath)FullyQualifiedPath;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (AnyAbsolutePath)Yeet);
	}

	[TestMethod]
	public void TestAnyDirectoryPath() => _ = (AnyDirectoryPath)FullyQualifiedPath;

	[TestMethod]
	public void TestAnyRelativePath()
	{
		var path = (AnyRelativePath)Yeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (AnyRelativePath)FullyQualifiedPath);
	}

	[TestMethod]
	public void TestMakeRelativePath()
	{
		var path = AnyRelativePath.Make<RelativeFilePath>(from: (AbsoluteDirectoryPath)FullyQualifiedPath, to: (AbsoluteDirectoryPath)FullyQualifiedPath / (FileName)DotYeet);
		Assert.AreEqual(expected: DotYeet, actual: path);
	}

	[TestMethod]
	public void TestFileRelativeTo()
	{
		var dir = (AbsoluteDirectoryPath)FullyQualifiedPath;
		var file = dir / (FileName)DotYeet;
		var path = file.RelativeTo(other: dir);
		Assert.AreEqual(expected: DotYeet, actual: path);
	}

	[TestMethod]
	public void TestDirectoryRelativeTo()
	{
		var dir = (AbsoluteDirectoryPath)FullyQualifiedPath;
		var file = dir / (FileName)DotYeet;
		var path = dir.RelativeTo(other: file);
		Assert.AreEqual(expected: "./", actual: path);
	}

	[TestMethod]
	public void TestGetContents()
	{
		var path = (AnyDirectoryPath)FullyQualifiedPath;
		var contents = path.Contents;
		var filePath = (AbsoluteDirectoryPath)AppContext.BaseDirectory / (FileName)"ktsu.io.StrongPaths.Test.dll";
		Assert.IsTrue(contents.Contains(filePath));
	}

	[TestMethod]
	public void TestWithFilePrefix()
	{
		var absDirectory = (AbsoluteDirectoryPath)FullyQualifiedPath;
		var absFilePath = absDirectory / (FileName)DotYeet;
		Assert.IsTrue(absFilePath.WithFilePrefix(Yeet) == absDirectory / (FileName)(Yeet + DotYeet));

		var relDirectory = (RelativeDirectoryPath)Yeet;
		var relFilePath = relDirectory / (FileName)DotYeet;
		Assert.IsTrue(relFilePath.WithFilePrefix(Yeet) == relDirectory / (FileName)(Yeet + DotYeet));
	}
}

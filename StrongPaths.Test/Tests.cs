namespace ktsu.io.StrongPaths.Test;

#pragma warning disable CS0219

[TestClass]
public class Tests
{
	private static string Yeet => "Yeet";
	private static string DotYeet => ".Yeet";
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
}

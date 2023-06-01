namespace ktsu.io.StrongPaths.Test;

#pragma warning disable CS0219

[TestClass]
public class Tests
{
	private static string CDrive => @"c:\";
	private static string Yeet => "Yeet";
	private static string DotYeet => ".Yeet";
	private static string CDriveYeet => $"{CDrive}{Yeet}";
	private static string Pipe => "|";
	private static string Colon => ":";
	private static string CDriveWindows => @"c:\Windows";
	private static string CDriveWindowsNotepad => @"c:\Windows\notepad.exe";

	[TestMethod]
	public void TestStrongPath()
	{
		var path1 = (StrongPath)Yeet;
		var path2 = (StrongPath)CDrive;
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => { _ = (StrongPath)(string)null!; });
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (StrongPath)string.Empty);
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (StrongPath)Pipe);
	}

	[TestMethod]
	public void TestAbsolutPath()
	{
		var path = (AbsolutePath)CDriveYeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (AbsolutePath)Yeet);
	}

	[TestMethod]
	public void TestRelativePath()
	{
		var path = (RelativePath)Yeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (RelativePath)CDriveYeet);
	}

	[TestMethod]
	public void TestFileName()
	{
		var path = (FileName)Yeet;
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (FileName)Colon);
	}

	[TestMethod]
	public void TestDirectoryPath()
	{
		var path = (DirectoryPath)CDriveWindows;
		File.WriteAllText(path: DotYeet, contents: Yeet);
		_ = Assert.ThrowsException<FormatException>(action: () => _ = (DirectoryPath)DotYeet);
	}

	[TestMethod]
	public void TestFilePath()
	{
		var path = (FilePath)CDriveWindowsNotepad;
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

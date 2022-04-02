using System;
using System.IO;
using System.Linq;
using System.Text;

const int maxPathLength = 1024;

try
{
	if (args.Length is 0 or > 3 || args.Contains(@"-h") || args.Contains(@"--help"))
	{
		OutputUsage();
		return 1;
	}

	var exePath = Path.GetFullPath(args[0]);
	var dllPathName = @"bin";
	var oldDllPathName = string.Empty;

	if (args.Length > 1)
	{
		dllPathName = args[1];
	}
	if (args.Length > 2)
	{
		oldDllPathName = args[2];
	}

	if (!File.Exists(exePath))
	{
		throw new FileNotFoundException($@"{exePath} not found!");
	}

	PatchExe(oldDllPathName, dllPathName, exePath);

	MoveDll(oldDllPathName, dllPathName, exePath);

	return 0;
}
catch (Exception ex)
{
	Console.WriteLine(ex);
	return 1;
}

static void OutputUsage()
{
	Console.WriteLine(
@"{ExePath} {DllPathName} [Nullable]{oldDllPathName}
Example:
c:\temp\1.exe bin dll <=> dll\1.dll => bin\1.dll
c:\temp\2.exe bin <=> 2.dll => bin\2.dll");
}

static void MoveDll(string oldDllPathName, string dllPathName, string exePath)
{
	var root = Path.GetDirectoryName(exePath);
	if (root == null)
	{
		throw new InvalidOperationException(@"Wrong exe path");
	}
	if (string.IsNullOrEmpty(oldDllPathName))
	{
		var tempPath = Path.Combine(Path.GetDirectoryName(root)
			?? throw new InvalidOperationException(@"Wrong exe path"), @"tempBin");

		Directory.Move(root, tempPath);

		var newPath = Path.Combine(root, dllPathName);

		if (!string.IsNullOrEmpty(dllPathName))
		{
			Directory.CreateDirectory(root);
		}

		Directory.Move(tempPath, newPath);
		File.Move(Path.Combine(newPath, Path.GetFileName(exePath)), exePath);
	}
	else
	{
		Directory.Move(Path.Combine(root, oldDllPathName), Path.Combine(root, dllPathName));
	}
}

static void PatchExe(string oldDllPathName, string dllPathName, string exePath)
{
	var exeName = Path.GetFileName(exePath);
	var separator = GetSeparator(exeName);

	if (!string.IsNullOrEmpty(oldDllPathName))
	{
		oldDllPathName += separator;
	}
	Span<byte> oldBytes = Encoding.UTF8.GetBytes($"{oldDllPathName}{ChangeExtensionToDll(exeName)}\0");
	if (oldBytes.Length > maxPathLength)
	{
		throw new PathTooLongException(@"old dll path is too long");
	}

	if (!string.IsNullOrEmpty(dllPathName))
	{
		dllPathName += separator;
	}
	Span<byte> newBytes = Encoding.UTF8.GetBytes($"{dllPathName}{ChangeExtensionToDll(exeName)}\0");
	if (newBytes.Length > maxPathLength)
	{
		throw new PathTooLongException(@"new dll path is too long");
	}

	Span<byte> bytes = File.ReadAllBytes(exePath);
	var index = bytes.IndexOf(oldBytes);
	if (index < 0)
	{
		throw new InvalidDataException($@"Could not find old dll path {oldDllPathName}");
	}

	if (index + newBytes.Length > bytes.Length)
	{
		throw new PathTooLongException(@"new dll path is too long");
	}

	using var fs = File.OpenWrite(exePath);
	fs.Write(bytes[..index]);
	fs.Write(newBytes);
	fs.Write(bytes[(index + newBytes.Length)..]);
}

static bool IsWindowsExe(string str)
{
	return str.EndsWith(@".exe", StringComparison.OrdinalIgnoreCase);
}

static string ChangeExtensionToDll(string exeName)
{
	return IsWindowsExe(exeName) ? Path.ChangeExtension(exeName, @".dll") : $@"{exeName}.dll";
}

static string GetSeparator(string exeName)
{
	return IsWindowsExe(exeName) ? @"\" : @"/";
}

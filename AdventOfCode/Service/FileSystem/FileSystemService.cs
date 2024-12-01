namespace AdventOfCode.Service.FileSystem;

internal static class FileSystemService
{
    internal static string GetDataFilePath(int day, string dataFile)
    {
        return $"{AppSettingConstants.BaseDirectory}/{AppSettingConstants.DataDirectory}/{day}/{dataFile}";
    }

    internal static void CreateFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
    }

    internal static void CreateFile(string path, string content)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, content);
        }
    }

    internal static string GetFileContent(string path)
    {
        return File.ReadAllText(path);
    }

    internal static string[] GetFileContentRows(string path)
    {
        return File.ReadAllLines(path);
    }

    internal static void CreateDirectoryIfNotExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Console.WriteLine($"Directory created at: {directoryPath}");
        }
        else
        {
            Console.WriteLine($"Directory already exists at: {directoryPath}");
        }
    }
}
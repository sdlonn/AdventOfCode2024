namespace AdventOfCode.Service.FileSystem;

internal static class FileSystemService
{
    internal static void CreateFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
    }

    internal static void CreateFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    internal static string GetFileContent(string path)
    {
        return File.ReadAllText(path);
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
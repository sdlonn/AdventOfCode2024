using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;
using static AdventOfCode.AppSettingConstants;

namespace AdventOfCode;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = SetUpDependencies();
        CreateFoldersAndFilesIfNotExists();
        SetUpDependencies();

        var application = new AdventOfCodeApp(serviceProvider);
        application.Run();
    }

    private static ServiceProvider SetUpDependencies()
    {
        var serviceProvider = new ServiceCollection();

        var serviceInterface = typeof(IService);
        IEnumerable<Type> implementations = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => serviceInterface.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var implementation in implementations)
        {
            Console.WriteLine(
                $"{implementation.Name} is assignable to IService: {typeof(IService).IsAssignableFrom(implementation)}");
            var implementationName = implementation.Name;
            serviceProvider.AddKeyedTransient<IService>(
                implementationName,
                (a, b) => (IService)Activator.CreateInstance(implementation));
        }

        return serviceProvider.BuildServiceProvider();
    }

    private static void CreateFoldersAndFilesIfNotExists()
    {
        var serviceDirectory = Path.Combine(BaseDirectory, $"{ServiceDirectory}/");
        var templateFilePath = Path.Combine(BaseDirectory, TemplateFilePath);
        var serviceFileContent = FileSystemService.GetFileContent(templateFilePath);

        for (var i = 1; i <= Days; i++)
        {
            try
            {
                var dataDirectory = Path.Combine(BaseDirectory, $"{DataDirectory}/{i}");

                FileSystemService.CreateDirectoryIfNotExists(dataDirectory);

                var dataOne = Path.Combine(dataDirectory, DataFile1);
                var dataTwo = Path.Combine(dataDirectory, DataFile2);

                FileSystemService.CreateFile(dataOne);
                FileSystemService.CreateFile(dataTwo);

                var className = $"{ServiceClassPrefix}{i}";

                var serviceFilePath = Path.Combine(serviceDirectory, className + FileType);
                FileSystemService.CreateFile(serviceFilePath,
                    serviceFileContent.Replace(ServiceClassTemplate, className));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
using AdventOfCode.Service;
using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode;

internal class AdventOfCodeApp
{
    private readonly ServiceProvider _serviceProvider;

    private readonly int _overrideDay = 0;
    private readonly bool _writeResultToFile = true;
    private readonly int _dayToRun;

    public AdventOfCodeApp(ServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _dayToRun = _overrideDay <= 0 ? DateTime.Now.Day : _overrideDay;
    }

    internal void Run()
    {
        var service =
            _serviceProvider.GetKeyedService<IService>($"{AppSettingConstants.ServiceClassPrefix}{_dayToRun}");

        if (service == null)
        {
            Console.WriteLine($"Day: {_dayToRun} Service not found!");
            Environment.ExitCode = -1;
            return;
        }

        try
        {
            Console.WriteLine("Attempt to run first problem.");
            var result = service.FirstProblem();
            var message = $"Answer to first problem:\n '{result}'";
            Console.WriteLine(message);
            if (_writeResultToFile)
            {
                var resultFile = Path.Combine(AppSettingConstants.BaseDirectory,
                    $"{AppSettingConstants.DataDirectory}/{_dayToRun}/Result1.txt");
                FileSystemService.CreateFile(resultFile);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception in first problem: '{e.Message}'");
        }

        try
        {
            Console.WriteLine("Attempt to run second problem.");
            var result = service.FirstProblem();
            var message = $"Answer to second problem:\n '{result}'";
            Console.WriteLine(message);
            if (_writeResultToFile)
            {
                var resultFile = Path.Combine(AppSettingConstants.BaseDirectory,
                    $"{AppSettingConstants.DataDirectory}/{_dayToRun}/Result2.txt");
                FileSystemService.CreateFile(resultFile);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception in second problem: '{e.Message}'");
        }
    }
}
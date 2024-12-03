using System.Text.RegularExpressions;
using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;

namespace AdventOfCode.Service;

public partial class Day3 : IService
{
    public string FirstProblem()
    {
        return ValidMultiplyOperations()
            .Matches(GetInput())
            .Cast<Match>()
            .Select(match => long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[2].Value))
            .Sum()
            .ToString();
    }

    public string SecondProblem()
    {
        throw new NotImplementedException();
    }

    public string GetInput()
    {
        return FileSystemService.GetFileContent(
            FileSystemService.GetDataFilePath(3, AppSettingConstants.DataFile1));
    }

    [GeneratedRegex("mul\\((\\d+),(\\d+)\\)")]
    private static partial Regex ValidMultiplyOperations();
}
using System.Text.RegularExpressions;
using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;

namespace AdventOfCode.Service;

public partial class Day3 : IService
{
    public string FirstProblem()
    {
        return OperationsRegex()
            .Matches(GetInput())
            .Cast<Match>()
            .Select(match => long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[2].Value))
            .Sum()
            .ToString();
    }

    public string SecondProblem()
    {
        return GetValuesFromMatches(DoDoNotOperationsRegex()
            .Matches(GetInput())).ToString();
    }

    public static string GetInput()
    {
        return FileSystemService.GetFileContent(
            FileSystemService.GetDataFilePath(3, AppSettingConstants.DataFile1));
    }

    private static long GetValuesFromMatches(MatchCollection matches)
    {
        var result = 0L;
        var count = true;
        foreach (Match item in matches)
        {
            switch (item.Value)
            {
                case "do()":
                    count = true;
                    break;
                case "don't()":
                    count = false;
                    break;
                default:
                {
                    if (count)
                    {
                        result += long.Parse(item.Groups[3].Value) * long.Parse(item.Groups[4].Value);
                    }

                    break;
                }
            }
        }

        return result;
    }

    [GeneratedRegex("mul\\((\\d+),(\\d+)\\)")]
    private static partial Regex OperationsRegex();

    [GeneratedRegex("(do)\\(\\)|(don't)\\(\\)|mul\\((\\d+),(\\d+)\\)")]
    private static partial Regex DoDoNotOperationsRegex();
}
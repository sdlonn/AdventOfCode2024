using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;

namespace AdventOfCode.Service;

public class Day1 : IService
{
    public string FirstProblem()
    {
        var inputNumbers =
            FileSystemService.GetFileContentRows(FileSystemService.GetDataFilePath("1", AppSettingConstants.DataFile1));
        var left = new List<int>();
        var right = new List<int>();

        foreach (var number in inputNumbers)
        {
            List<string> values = number.Split("  ").Select(x => x.Trim()).ToList();
            left.Add(int.Parse(values[0]));
            right.Add(int.Parse(values[1]));
        }

        left.Sort();
        right.Sort();

        var diff = 0L;

        for (var i = 0; i < left.Count; i++)
        {
            diff += Math.Abs(left[i] - right[i]);
        }

        return diff.ToString();
    }

    public string SecondProblem()
    {
        throw new NotImplementedException();
    }
}
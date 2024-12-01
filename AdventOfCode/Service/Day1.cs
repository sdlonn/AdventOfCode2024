using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;
using AdventOfCode.Service.ServiceModels;

namespace AdventOfCode.Service;

public class Day1 : IService
{
    public string FirstProblem()
    {
        var wrapper = GetNumbers();

        wrapper.Left.Sort();
        wrapper.Right.Sort();

        var diff = 0L;

        for (var i = 0; i < wrapper.Left.Count; i++)
        {
            diff += Math.Abs(wrapper.Left[i] - wrapper.Right[i]);
        }

        return diff.ToString();
    }

    public string SecondProblem()
    {
        var numbers = GetNumbers();
        Dictionary<int, int> occurences = numbers.Right
            .GroupBy(x => x)
            .Select(x => new { key = x.Key, count = x.Count() })
            .ToDictionary(x => x.key, x => x.count);

        var amount = 0L;

        foreach (var number in numbers.Left)
        {
            if (!occurences.ContainsKey(number))
            {
                continue;
            }

            amount += number * occurences[number];
        }

        return amount.ToString();
    }

    private Day1Wrapper GetNumbers()
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

        return new Day1Wrapper(left, right);
    }
}
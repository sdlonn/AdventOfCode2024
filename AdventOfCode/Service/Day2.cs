using AdventOfCode.Service.FileSystem;
using AdventOfCode.Service.Interface;

namespace AdventOfCode.Service;

public class Day2 : IService
{
    public enum Direction
    {
        Ascending,
        Descending
    }

    private const int MaxDiff = 3;

    public string FirstProblem()
    {
        return GetNumbers().LongCount(IsSafe).ToString();
    }

    public string SecondProblem()
    {
        return GetNumbers().LongCount(numbers => IsSafe(numbers) || IsSafeIfRemove(numbers)).ToString();
    }

    private static bool IsSafeIfRemove(IReadOnlyCollection<int> ls)
    {
        for (var i = 0; i < ls.Count; i++)
        {
            var ls1 = new List<int>(ls);
            ls1.RemoveAt(i);
            if (IsSafe(ls1.ToArray()))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsSafe(int[] numbers)
    {
        if (numbers.Length < 2)
        {
            return true;
        }

        var direction = Direction.Ascending;

        if (numbers[0] > numbers[1])
        {
            direction = Direction.Descending;
        }

        for (var i = 0; i < numbers.Length - 1; i++)
        {
            if (!CompareNumbers(direction, numbers, i))
            {
                return false;
            }
        }

        return true;
    }

    private static IEnumerable<int[]> GetNumbers()
    {
        var inputNumbers =
            FileSystemService.GetFileContentRows(FileSystemService.GetDataFilePath(2, AppSettingConstants.DataFile1));
        return inputNumbers.Select(number => number.Split(" ").Select(x => int.Parse(x.Trim())).ToArray());
    }

    private static bool CompareNumbers(Direction direction, IReadOnlyList<int> numbers, int index)
    {
        var a = numbers[index];
        var b = numbers[index + 1];

        if (a == b || Math.Abs(a - b) > MaxDiff)
        {
            return false;
        }

        return direction switch
        {
            Direction.Ascending when a > b => false,
            Direction.Descending when b > a => false,
            _ => true
        };
    }
}
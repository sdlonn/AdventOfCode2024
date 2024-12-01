namespace AdventOfCode.Service.ServiceModels;

internal class Day1Wrapper
{
    public List<int> Left { get; internal set; }
    public List<int> Right { get; internal set; }

    public Day1Wrapper(List<int> left, List<int> right)
    {
        Left = left;
        Right = right;
    }
}
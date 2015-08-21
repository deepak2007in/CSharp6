using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        var primaryInput = Console.ReadLine();
        var width = int.Parse(primaryInput.Split(' ')[0]);
        var testCaseCount = int.Parse(primaryInput.Split(' ')[1]);
        var widthArray = Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray();
        for (int i = 0; i < testCaseCount; i++)
        {
            var input = Console.ReadLine();
            var startIndex = int.Parse(input.Split(' ')[0]);
            var endIndex = int.Parse(input.Split(' ')[1]);
            var laneArray = widthArray.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
            Console.WriteLine(laneArray.Min());
        }
        Console.ReadLine();
    }
}
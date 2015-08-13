using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        var input = new[] { 1, 5, 7, 9, 11 };
        Console.WriteLine(GetMissingSequence(input));

        input = new[] { 1, 3, 7, 9, 11 };
        Console.WriteLine(GetMissingSequence(input));

        input = new[] { 1, 3, 5, 9, 11 };
        Console.WriteLine(GetMissingSequence(input));

        input = new[] { 1, 3, 5, 7, 11 };
        Console.WriteLine(GetMissingSequence(input));

        Console.ReadLine();
    }

    static int GetMissingSequence(int[] sequence)
    {
        var minimumDifference = 0;
        for (int index = sequence.Length - 1; index >= 1; index--)
        {
            if (minimumDifference == 0)
            {
                minimumDifference = sequence[index] - sequence[index - 1];
            }
            else
            {
                if (minimumDifference == sequence[index] - sequence[index - 1])
                {
                    continue;
                }
                else
                {
                    if(minimumDifference > sequence[index] - sequence[index - 1])
                    {
                        return sequence[index] + Math.Min(minimumDifference, sequence[index] - sequence[index - 1]);
                    }
                    else
                    {
                        return sequence[index] - Math.Min(minimumDifference, sequence[index] - sequence[index - 1]);
                    }
                }
            }
        }
        return minimumDifference;
    }
}
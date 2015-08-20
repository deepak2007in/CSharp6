using System;

class Solution
{
    static void Main(string[] args)
    {
        var input = decimal.Parse(Console.ReadLine());
        var output = input;
        for (decimal i = input - 1; i > 1; i--)
        {
            output = output * i;
        }
        Console.WriteLine(output);
        Console.ReadLine();
    }
}
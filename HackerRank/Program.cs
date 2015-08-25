using System;

class Solution
{
    static void Main(string[] args)
    {
        var total = int.Parse(Console.ReadLine());
        for (var i = 0; i < total; i++)
        {
            var input = Console.ReadLine().ToCharArray();
            var reverse = new char[input.Length];
            input.CopyTo(reverse, 0);
            Array.Reverse(reverse);
            var isFunny = true;
            for (var index = input.Length - 1; index > 0; index--)
            {
                var inputDifference = (int)input[index] - (int)input[index - 1];
                var reverseDifference = (int)reverse[index] - (int)reverse[index - 1];
                isFunny = (Math.Abs(inputDifference) == Math.Abs(reverseDifference));
                if (!isFunny)
                {
                    break;
                }
            }
            if (isFunny)
            {
                Console.WriteLine("Funny");
            }
            else
            {
                Console.WriteLine("Not Funny");
            }
        }
        Console.ReadLine();
    }
}
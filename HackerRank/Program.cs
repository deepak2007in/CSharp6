using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        var totalNumberOfTestCase = int.Parse(Console.ReadLine());
        for (int i = 0; i < totalNumberOfTestCase; i++)
        {
            var inputSring = Console.ReadLine();
            var inputDigits = inputSring.ToCharArray().Select(num => int.Parse(num.ToString())).ToList();
            var input = int.Parse(inputSring);
            var validDigitCount = inputDigits.Where(digit => digit > 0 && input % digit == 0).Count();
            Console.WriteLine(validDigitCount);
        }
        Console.ReadLine();
    }
}
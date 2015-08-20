using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        var totalNumberOfTestCase = int.Parse(Console.ReadLine());
        for (int i = 0; i < totalNumberOfTestCase; i++)
        {
            var passingCondition = Console.ReadLine();
            var passingExpectation = int.Parse(passingCondition.Split(' ')[1]);
            var inputValues = Console.ReadLine().Split(' ').Select(num => int.Parse(num));
            var passingActual = inputValues.Where(num => num < 1).Count();
            var isClassCancelled = (passingActual >= passingExpectation) ? "NO" : "YES";
            Console.WriteLine(isClassCancelled);
        }
        Console.ReadLine();
    }
}
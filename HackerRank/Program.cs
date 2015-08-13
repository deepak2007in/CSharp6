using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        var started = DateTimeOffset.Now;
        var input = 100;
        Console.WriteLine(getNumberOfPrimes(input));
        Console.WriteLine((DateTimeOffset.Now - started).TotalMilliseconds);
        input = 1000000;
        Console.WriteLine(getNumberOfPrimes(input));
        Console.WriteLine((DateTimeOffset.Now - started).TotalMilliseconds);
        Console.ReadLine();
    }

    /*
     * Input 100
       Output 25
       Input   1000000
       Output 78498
     */
    static int getNumberOfPrimes(int n) {
        var primeNumbers = new List<int>(new[] { 2, 3, 5 });
        if (n > 5)
        {
            for (var actual = 6; actual < n; actual++)
            {
                var lastDigit = actual % 10;
                if (lastDigit % 2 == 0 || lastDigit % 5 == 0)
                {
                    continue;
                }
                var isPrime = true;
                for (var index = 0; index < primeNumbers.Count; index++)
                {
                    if (actual % primeNumbers[index] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(actual);
                }
            }
        }

        return n < 6 ? 3 : primeNumbers.Count;
    }
}
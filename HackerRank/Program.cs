using System;

class Solution
{
    static void Main(string[] args)
    {
        var input = 100;
        Console.WriteLine(getNumberOfPrimes(input));
        input = 1000000;
        Console.WriteLine(getNumberOfPrimes(input));
        Console.ReadLine();
    }

    /*
     * Input 100
       Output 25
       Input   1000000
       Output 78498
     */
    static int getNumberOfPrimes(int n) {
        var numberOfPrime = 0;
        for (var actual = 1; actual < n; actual++) {
            var isPrime = true;
            for (var devisor = actual - 1; devisor > 1; devisor--) {
                if (actual % devisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) {
                numberOfPrime++;
            }
        }
        return numberOfPrime;
    }
}
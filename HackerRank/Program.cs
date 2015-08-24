using System;

class Solution
{
    static void Main(string[] args)
    {
        try
        {
            var i = 3;
            var j = 0;
            var k = i/j;
        }
        catch
        {
            Console.WriteLine("Exception");
        }
        Console.ReadLine();
    }
}
using System;
using System.Linq;

delegate void Func();
class Solution
{
    static Func[] funcArr = new Func[10];
    static void Main(string[] args)
    {
        var i = 10;
        var j = 9;
        var k = i & j;
        Console.WriteLine(k);
        Console.ReadLine();
    }
}
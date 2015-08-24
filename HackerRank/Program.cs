using System;
using System.Linq;

delegate void Func();
class Solution
{
    static Func[] funcArr = new Func[10];
    static void Main(string[] args)
    {
        for (var i = 0; i < 10; i++)
        {
            int j = i;
            funcArr[i] = delegate () { Console.WriteLine("{0}", j); };
        }
        for (var i = 0; i < funcArr.Length; i++)
        {
            funcArr[i]();
        }
        Console.ReadLine();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

delegate void Func();
class Solution
{
    static Func[] funcArr = new Func[10];
    static void Main(string[] args)
    {
        var dictionary = new Dictionary<string, int>();
        dictionary.Add("Abc", 6);
        dictionary.Add("XYZ", 5);
        dictionary.Add("PQR", 7);
        dictionary.Add("LMN", 4);
        var ordered = dictionary.OrderBy(pair => pair.Value);
        foreach(var pair in ordered)
        {
            Console.WriteLine(pair.Value);
        }
        Console.ReadLine();
    }
}
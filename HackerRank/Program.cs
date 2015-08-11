using System;

class Solution
{
    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for(int t=0; t<n; t++)
        {
            string str = Console.ReadLine();
            String[] strArr = str.Split();
            int a = Convert.ToInt32(strArr[0]);
            int b = Convert.ToInt32(strArr[1]);
            Console.WriteLine(a + b);
        }
    }
}
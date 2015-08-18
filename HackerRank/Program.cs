using System;

class Solution
{
    static void Main(string[] args)
    {
        for(int i=0; i<100; i++)
        {
            for(int a=0; a<1000; a++)
            {
                System.IO.Path.GetRandomFileName();
                System.IO.Path.GetRandomFileName();
            }
            System.Threading.Thread.Sleep(1);
        }

        for(int i=0; i <= GC.MaxGeneration; i++)
        {
            int count = GC.CollectionCount(i);
            Console.WriteLine(count);
        }
        Console.ReadLine();
    }
}
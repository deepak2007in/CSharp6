using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleOutputter
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var i in Enumerable.Range(1, 100))
            {
                if(i % 2 == 1)
                {
                    Console.Out.WriteLine("Standard Output {0}", i);
                }
                else
                {
                    Console.Out.WriteLine("Standard Error {0}", i);
                }
                Thread.Sleep(1000);
            }
        }
    }
}

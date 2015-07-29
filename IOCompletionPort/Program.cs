using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCompletionPort
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint Flags = 128 | (uint)1 << 30;
            Console.WriteLine(Flags);
            Console.ReadLine();
        }
    }
}

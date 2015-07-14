namespace CSharp6
{
    using System.Collections.Generic;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var webErrors = new Dictionary<int, string>
            {
                [404] = "Page not found",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };

            foreach(var key in webErrors.Keys)
            {
                WriteLine(key);
            }

            Read();
        }
    }
}

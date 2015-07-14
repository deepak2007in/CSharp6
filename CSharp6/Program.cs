namespace CSharp6
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point { X = 3, Y = 4 };
            WriteLine(point.Distance);
            Read();
        }
    }
}

namespace CSharp6
{
    using System;
    using System.Diagnostics;
    using static System.Console;
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // var nameless = new EvilGenius(default(string));
                var empty = new EvilGenius("   ");
            }
            catch(Exception e) when (LogException(e))
            {

            }
            catch (ArgumentNullException e) when (e.ParamName == "name")
            {
                WriteLine("Evil genius must have a name");
            }
            catch(ArgumentException e) when (!Debugger.IsAttached)
            {
                WriteLine("We finally found this one");
            }
            Read();
        }

        private static bool LogException(Exception e)
        {
            var oldColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;

            WriteLine("Inside the LogException: Error {0}", e);
            ForegroundColor = oldColor;
            return false;
        }
    }
}

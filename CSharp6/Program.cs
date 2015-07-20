namespace CSharp6
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using static System.Console;
    public class Program
    {
        static void Main(string[] args)
        {
            if (true)
                WriteLine("True");
                
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
            catch (Exception e)
            {
                LogErrorToFileAsync("Bad thing happened", e).Wait();    
            }
            Read();
        }

        private static bool LogException<T>(T e) where T : Exception
        {
            var oldColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;

            WriteLine("Inside the LogException: Error {0}", e);
            ForegroundColor = oldColor;
            return false;
        }

        public static async Task LogErrorToFileAsync(string msg, Exception e)
        {
            using (var file = File.AppendText("errors.log"))
            {
                await file.WriteLineAsync($"{msg}: {e.ToString()}");
            }
        }
    }
}

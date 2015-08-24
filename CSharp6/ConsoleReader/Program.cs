using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ConsoleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = FindChildProcess();
            if(path == null)
            {
                Console.WriteLine("Error ... Could not find ConsoleOutputter.exe");
                return;
            }

            var info = new ProcessStartInfo(path);
            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;

            var process = Process.Start(info);
            var childStdOut = GetLineReader(process.StandardOutput).ToObservable();
            var childStdErr = GetLineReader(process.StandardError).ToObservable();

            Observable.Merge(childStdOut, childStdErr).Subscribe(LineOutputter);

            Console.WriteLine("Press Enter to Close");
            Console.ReadLine();
        }

        private static IEnumerable<string> GetLineReader(StreamReader reader)
        {
            while(reader.BaseStream.CanRead)
            {
                var l = reader.ReadLine();
                if(l == null)
                {
                    break;
                }
                yield return l;
            }
        }

        private static string FindChildProcess()
        {
            var possiblePaths = new string[]
            {
                "ConsoleOutputter.exe",
                @"..\..\..\ConsoleOutputter\bin\debug\ConsoleOutputter.exe"
            };
            var path = possiblePaths.FirstOrDefault(p => File.Exists(p));
            return path;
        }

        private static void LineOutputter(string line)
        {
            Console.WriteLine(line);
        }
    }
}

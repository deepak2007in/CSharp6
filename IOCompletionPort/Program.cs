using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IOCompletionPort
{
    public class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(
        [MarshalAs(UnmanagedType.LPTStr)] string filename,
        [MarshalAs(UnmanagedType.U4)] FileAccess access,
        [MarshalAs(UnmanagedType.U4)] FileShare share,
        IntPtr securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
        IntPtr templateFile);

        static void Main(string[] args)
        {
            var instance = new UnionLike();
            instance.value1 = 5;
            instance.value2 = 10;
            // instance.value3 = Double.MaxValue;
            Console.WriteLine(instance.value1);
            Console.WriteLine(instance.value2);
            // Console.WriteLine(instance.value3);
            Console.ReadLine();
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct UnionLike
        {
            [FieldOffset(0)]
            public int value1;
            [FieldOffset(3)]
            public int value2;
            //[FieldOffset(0)]
            //public double value3;
        }
    }
}

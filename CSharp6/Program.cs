namespace CSharp6
{
    using System.Collections.Generic;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var evil1 = new EvilGenius(name: "");
            evil1.ReplaceHenchman(new EvilGenius.Henchman { AssistantMoniker = "Top" });

            var evil2 = new EvilGenius(name: "Agnihotri");
            WriteLine(EvilGenius.ToJson(new[] { evil1, evil2 }));
            Read();
        }
    }
}

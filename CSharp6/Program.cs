namespace CSharp6
{
    using System.Collections.Generic;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var evil = new EvilGenius(name: "Deepak");
            evil.ReplaceHenchman(new EvilGenius.Henchman { AngryBird = "Top" });
            evil.ReplaceHenchman(new EvilGenius.Henchman { AngryBird = "Bottom" });
            Read();
        }
    }
}

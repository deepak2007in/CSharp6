namespace CSharp6
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var evil1 = new EvilGenius(name: "Deepak");
            evil1.ReplaceHenchman(new EvilGenius.Henchman { AssistantMoniker = "Top" });
            WriteLine(evil1.AssistantHistory());
            evil1.ReplaceHenchman(new EvilGenius.Henchman { AssistantMoniker = "Bottom" });
            WriteLine(evil1.AssistantHistory());

            var evil2 = new EvilGenius(name: "Agnihotri");
            WriteLine(EvilGenius.ToJson(new[] { evil1, evil2 }));
            Read();
        }
    }
}

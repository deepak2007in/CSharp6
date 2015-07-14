using System;
using System.Threading;

namespace CSharp6
{
    public class EvilGenius
    {
        private Henchman henchman;
        public EvilGenius(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Henchman MyHenchman
        {
            get
            {
                return henchman;
            }
        }

        public class Henchman
        {
            public string AngryBird { get; set; }
            public override string ToString() => AngryBird;
        }

        public void ReplaceHenchman(Henchman newHanchman)
        {
            var oldHenchman = Interlocked.Exchange(ref henchman, newHanchman);
            (oldHenchman as IDisposable)?.Dispose();
        }
    }
}

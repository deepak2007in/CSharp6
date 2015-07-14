using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        public static JArray ToJson(IEnumerable<EvilGenius> collection)
        {
            var result = new JArray();
            if(collection != null)
            {
                foreach(var evil in collection)
                {
                    var evilJson = new JObject
                    {
                        [nameof(EvilGenius.Name)] = evil.Name                        
                    };

                    if(evil.MyHenchman != null)
                    {
                        evilJson.Add(nameof(EvilGenius.MyHenchman), new JObject
                        {
                            [nameof(EvilGenius.Henchman.AngryBird)] = evil?.MyHenchman?.AngryBird
                        });
                    }

                    result.Add(evilJson);
                }
            }
            return result;
        }
    }
}

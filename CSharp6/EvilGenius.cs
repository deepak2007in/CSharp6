using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.String;

namespace CSharp6
{
    public class EvilGenius
    {
        private Henchman henchman;
        public EvilGenius(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if(IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(paramName: nameof(name), message: "Evil Genius must have a name.");
            }
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
            public string AssistantMoniker { get; set; }
            public override string ToString() => AssistantMoniker;
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
                            [nameof(EvilGenius.Henchman.AssistantMoniker)] = evil?.MyHenchman?.AssistantMoniker
                        });
                    }

                    result.Add(evilJson);
                }
            }
            return result;
        }
    }
}

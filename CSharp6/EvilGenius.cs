using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using static System.String;

namespace CSharp6
{
    public class EvilGenius
    {
        private List<string> previousMinions = new List<string>();
        private Henchman henchman;
        public EvilGenius(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if (IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(paramName: nameof(name), message: "Evil Genius must have a name.");
            }
            this.Name = name;
        }

        public string Name { get; }

        public Henchman MyHenchman => henchman;

        public class Henchman
        {
            public string AssistantMoniker { get; set; }
            public override string ToString() => AssistantMoniker;
        }

        public string AssistantHistory()
        {
            if(!previousMinions.Any())
            {
                return $"{Name} has had no previous henchman.";
            }
            else
            {
                return $@"{Name} has had {previousMinions.Count} assistant: {previousMinions.Aggregate((memo, current) => $"{memo}, {current}")}";
            }
        }

        public void ReplaceHenchman(Henchman newHanchman)
        {
            var oldHenchman = Interlocked.Exchange(ref henchman, newHanchman);
            if(oldHenchman != null)
            {
                previousMinions.Add(oldHenchman.AssistantMoniker);
            }
            (oldHenchman as IDisposable)?.Dispose();
        }

        public static JArray ToJson(IEnumerable<EvilGenius> collection)
        {
            var result = new JArray();
            if (collection != null)
            {
                foreach (var evil in collection)
                {
                    var evilJson = new JObject
                    {
                        [nameof(EvilGenius.Name)] = evil.Name
                    };

                    if (evil.MyHenchman != null)
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

        public override string ToString() => $"{Name}, {MyHenchman?.AssistantMoniker}";

        public string EvilPoints()
        {
            double evilBase = 23;
            double evilExtra = 19;

            return PointsInGerman($"{evilBase} / {evilExtra} = {evilBase / evilExtra}");
        }

        private string PointsInGerman(FormattableString invariantString) => Format(
                System.Globalization.CultureInfo.GetCultureInfo("de-de"),
                invariantString.Format,
                invariantString.GetArguments());
    }
}

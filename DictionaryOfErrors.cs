using System.Collections.Generic;

namespace Sem_2_Lab_5
{
    class DictionaryOfErrors
    {
        public static Dictionary<string, List<string>> GetDictionary()
        {
            var dictionary = new Dictionary<string, List<string>>();
            dictionary.Add("Достичь", new List<string> { "Достич", "Достичъ" });
            dictionary.Add("баланса", new List<string> { "боланса" });
            dictionary.Add("между", new List<string> { "мешду", "междю" });
            dictionary.Add("слишком", new List<string> { "слешком", "слишкам" });
            dictionary.Add("слабым", new List<string> { "слабим", "злабым" });
            dictionary.Add("сильным", new List<string> { "сыльным", "сильним" });
            dictionary.Add("формализмом", new List<string> { "фармолизмом", "фармализмом", "формолизмом" });
            dictionary.Add("нелегко", new List<string> { "нилегко", "нелигко", "нилигко", "нелехко" });
            dictionary.Add("поговорим", new List<string> { "паговорим", "пагаворим", "погаворим" });
            return dictionary;
        }
    }
}

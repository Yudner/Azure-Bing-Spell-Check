using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSpellCheck.Infrastructure.SpellCheck
{
    public class Suggestion
    {
        public string suggestion { get; set; }
        public float score { get; set; }
    }

    public class FlaggedToken
    {
        public int offset { get; set; }
        public string token { get; set; }
        public string type { get; set; }
        public List<Suggestion> suggestions { get; set; }
    }

    public class SpellCheckModel
    {
        public string _type { get; set; }
        public List<FlaggedToken> flaggedTokens { get; set; }
    }
}

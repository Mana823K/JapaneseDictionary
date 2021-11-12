using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dictionary.Models
{
    [DataContract]
    class DictionaryResult
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "jlpt")]
        public List<string> JLPT { get; set; }

        [DataMember(Name = "japanese")]
        public List<JapaneseDefinition> JapaneseDefinitions { get; set; }

        [DataMember(Name = "senses")]
        public List<EnglishDefinition> EnglishDefinitions { get; set; }

    }
}

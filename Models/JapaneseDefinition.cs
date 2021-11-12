using System.Runtime.Serialization;

namespace Dictionary.Models
{
    [DataContract]
    class JapaneseDefinition
    {
        [DataMember(Name = "word")]
        public string Word { get; set; }

        [DataMember(Name = "reading")]
        public string Reading { get; set; }
    }
}

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dictionary.Models
{
    [DataContract]
    class DictionaryResultModel
    {
        [DataMember(Name = "data")]
        public List<DictionaryResult> DictionaryResults { get; set; }
    }
}

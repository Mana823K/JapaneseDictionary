using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dictionary.Models
{
    [DataContract]
    class EnglishDefinition
    {
        public string Definitions { get; set; }
        public string PartsOfSpeech { get; set; }
        public string Info { get; set; }


        [DataMember(Name = "english_definitions")]
        public List<string> DefinitionsList
        {
            set
            {
                Definitions = ListToString(value);
            }
        }


        [DataMember(Name = "parts_of_speech")]
        public List<string> PartsOfSpeechList
        {
            set
            {
                PartsOfSpeech = ListToString(value);
            }
        }

        [DataMember(Name = "info")]
        public List<string> InfoList
        {
            set
            {
                Info = ListToString(value);
            }
        }

        /// <summary>
        /// Creates a displayable string from the given list.
        /// </summary>
        /// <param name="list">A list of string words</param>
        /// <returns>A string containing the elements of the given list</returns>
        private string ListToString(List<string> list)
        {
            string result = "";

            if(list.Count != 0)
            {
                foreach(string item in list)
                {
                    result += item + ", ";
                }
                result = result[0..^2];
            }

            return result;
        }

    }
}

using Dictionary.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace Dictionary.Services
{
    /// <summary>
    /// Contains methods for searching online dictionary.
    /// </summary>
    class DictionarySearchService
    {
        private readonly HttpClient client;
        private readonly string[] strFilter = { "ている", "です", "でした", "ます", "ました", "られ" };

        public DictionarySearchService()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Gets search results from the API for a certain keyword.
        /// </summary>
        /// <param name="keyword">A keyword to search dictionary</param>
        /// <returns>A List of the dictionary search results</returns>
        public List<DictionaryResult> DictionarySearch(string keyword)
        {
            HttpResponseMessage response = client.GetAsync(@"https://jisho.org/api/v1/search/words?keyword=" + keyword).Result;
            string resultString = response.Content.ReadAsStringAsync().Result;

            DictionaryResultModel searchResult = JsonConvert.DeserializeObject<DictionaryResultModel>(resultString);

            return searchResult.DictionaryResults;
        }

        /// <summary>
        /// Gets search results for multiple words
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="text"></param>
        public ObservableCollection<DictionaryResult> TranslateSearch(string text)
        {
            text = RemoveEmptySubstrings(text);
            ObservableCollection<DictionaryResult> dictionaryResults = new ObservableCollection<DictionaryResult>();

            // Iterate through the whole text. If there is a match, the matched word is cut from the front.
            while (text.Length > 0)
            {
                // Skip separator.
                if (text[0] == ' ')
                {
                    text = text[1..];
                }
                string currentText = text;

                // Iterate through current section. If there is no exact match, the section is shortened from the end.
                while (currentText.Length > 0)
                {
                    bool hit = false;
                    try
                    {
                        List<DictionaryResult> searchResult = DictionarySearch(currentText);
                        foreach (DictionaryResult item in searchResult)
                        {
                            string searchWord;
                            // Check result's slug for match.
                            if (text.Contains(item.Slug))
                            {
                                searchWord = item.Slug;
                                dictionaryResults.Add(item);
                                text = text[(text.IndexOf(searchWord) + searchWord.Length)..];
                                hit = true;
                                break;
                            }
                            // Check result's reading for match (in case hiragana is used instead of kanji).
                            else if (text.Contains(item.JapaneseDefinitions[0].Reading))
                            {
                                searchWord = item.JapaneseDefinitions[0].Reading;
                                dictionaryResults.Add(item);
                                text = text[(text.IndexOf(searchWord) + searchWord.Length)..];
                                hit = true;
                                break;
                            }
                        }
                    }
                    catch { }
                    if (!hit) // Shorten if there was no match.
                    {
                        if (currentText.Length == 1) // If there is only 1 character left of the section, skip to next section (cut first character).
                        {
                            text = text[1..];
                            break;
                        }
                        currentText = currentText[0..^1];
                    }
                    else // Go to next section if there was a match.
                    {
                        break;
                    }
                }
            }
            return dictionaryResults;
        }

        /// <summary>
        /// Removes sections from the text that wouldn't return useful search results. (digits, punctuations, conjugations)
        /// </summary>
        /// <param name="text">Text to be cleaned</param>
        /// <returns>Clean text for multiple-word search</returns>
        private string RemoveEmptySubstrings(string text)
        {
            string result = "";

            foreach (char c in text)
            {
                if (!(char.IsDigit(c) || char.IsPunctuation(c)))
                {
                    result += c;
                }
            }

            foreach (string item in strFilter)
            {
                int index;
                while ((index = result.IndexOf(item)) >= 0)
                {
                    string a = result[..index];
                    string b = result[(index + item.Length)..];
                    result = a + " " + b; // Add separator instead (Otherwise text on both sides could be handled as one word)
                }
            }

            return result;
        }

    }
}

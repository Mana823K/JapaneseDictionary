using Dictionary.Commands;
using Dictionary.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    class DictionaryViewModel : BaseViewModel
    {
        private string _message;
        private List<DictionaryResult> _dictionaryResults;

        public ICommand DictionarySearchCommand { get; set; }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public List<DictionaryResult> SearchResults
        {
            get { return _dictionaryResults; }
            set
            {
                _dictionaryResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }


        public DictionaryViewModel()
        {
            DictionarySearchCommand = new DictionarySearchCommand(this);
        }
    }
}

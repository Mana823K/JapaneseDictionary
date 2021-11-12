using Dictionary.Commands;
using Dictionary.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    class TranslateViewModel : BaseViewModel
    {
        private string _browseTextBox;
        private string _translateText;
        private string _searchTextBox;
        private string _message;
        private ObservableCollection<DictionaryResult> _searchResults;

        public ICommand BrowseTextCommand { get; set; }
        public ICommand TranslateSearchCommand { get; set; }

        public string BrowseTextBox
        {
            get { return _browseTextBox; }
            set
            {
                _browseTextBox = value;
                OnPropertyChanged(nameof(BrowseTextBox));
            }
        }

        public string TranslateText
        {
            get { return _translateText; }
            set
            {
                _translateText = value;
                OnPropertyChanged(nameof(TranslateText));
            }
        }

        public string SearchTextBox
        {
            get { return _searchTextBox; }
            set
            {
                _searchTextBox = value;
                OnPropertyChanged(nameof(SearchTextBox));
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ObservableCollection<DictionaryResult> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }


        public TranslateViewModel()
        {
            BrowseTextCommand = new BrowseTextCommand(this);
            TranslateSearchCommand = new TranslateSearchCommand(this);
        }
    }
}

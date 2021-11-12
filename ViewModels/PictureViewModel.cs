using Dictionary.Commands;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    class PictureViewModel : BaseViewModel
    {
        private string _browseTextBox;
        private bool _isVertical;
        private bool _isHorizontal;
        private string _translatedText;
        private string _imageSource;
        private string _message;

        public ICommand ReadPictureCommand { get; set; }
        public ICommand BrowsePictureCommand { get; set; }
        public ICommand SaveTextCommand { get; set; }

        public string BrowseTextBox
        {
            get { return _browseTextBox; }
            set
            {
                _browseTextBox = value;
                OnPropertyChanged(nameof(BrowseTextBox));
            }
        }
        public bool IsVertical
        {
            get { return _isVertical; }
            set
            {
                _isVertical = value;
                OnPropertyChanged(nameof(IsVertical));
            }
        }

        public bool IsHorizontal
        {
            get { return _isHorizontal; }
            set
            {
                _isHorizontal = value;
                OnPropertyChanged(nameof(IsHorizontal));
            }
        }

        public string TranslatedText
        {
            get { return _translatedText; }
            set
            {
                _translatedText = value;
                OnPropertyChanged(nameof(TranslatedText));
            }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
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


        public PictureViewModel()
        {
            IsHorizontal = true;
            ReadPictureCommand = new ReadPictureCommand(this);
            BrowsePictureCommand = new BrowsePictureCommand(this);
            SaveTextCommand = new SaveTextCommand(this);
        }
    }
}

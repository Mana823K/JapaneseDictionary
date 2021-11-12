using Dictionary.Commands;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public ICommand ChangeViewCommand { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }


        public MainViewModel()
        {
            ChangeViewCommand = new ChangeViewCommand(this);
            SelectedViewModel = new DictionaryViewModel();
        }

    }
}

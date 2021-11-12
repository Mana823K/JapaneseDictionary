using Dictionary.ViewModels;
using System;
using System.Windows.Input;

namespace Dictionary.Commands
{
    class ChangeViewCommand : ICommand
    {
        private readonly MainViewModel viewModel;

        public ChangeViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

#pragma warning disable CS0067 // The event 'ChangeViewCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'ChangeViewCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Picture":
                    viewModel.SelectedViewModel = new PictureViewModel();
                    break;
                case "Translate":
                    viewModel.SelectedViewModel = new TranslateViewModel();
                    break;
                case "Dictionary":
                    viewModel.SelectedViewModel = new DictionaryViewModel();
                    break;
            }
        }
    }
}

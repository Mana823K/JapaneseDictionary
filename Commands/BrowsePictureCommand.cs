using Dictionary.Services;
using Dictionary.ViewModels;
using System;
using System.Windows.Input;

namespace Dictionary.Commands
{
    /// <summary>
    /// Opens file dialog and displays chosen file's file path.
    /// </summary>
    class BrowsePictureCommand : ICommand
    {
        private readonly PictureViewModel viewModel;
        private const string BrowseFilter = "All files (*.*)|*.*|jpg files (*.jpg)|*jpg|tiff files (*.tiff)|*.tiff|gif files (*.gif)|*.gif|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png";

        public BrowsePictureCommand(PictureViewModel vm)
        {
            viewModel = vm;
        }


#pragma warning disable CS0067 // The event 'BrowsePictureCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'BrowsePictureCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialogueService openFileDialogue = new OpenFileDialogueService();
            viewModel.BrowseTextBox = openFileDialogue.GetFilePath(BrowseFilter);
            viewModel.ImageSource = viewModel.BrowseTextBox;
        }
    }
}

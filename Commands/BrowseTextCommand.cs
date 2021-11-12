using Dictionary.Services;
using Dictionary.ViewModels;
using System;
using System.IO;
using System.Windows.Input;

namespace Dictionary.Commands
{
    /// <summary>
    /// Opens file dialog and display chosen text file's content.
    /// </summary>
    class BrowseTextCommand : ICommand
    {
        private readonly TranslateViewModel viewModel;
        private const string BrowseFilter = "txt files (*.txt)|*.txt";

        public BrowseTextCommand(TranslateViewModel vm)
        {
            viewModel = vm;
        }

#pragma warning disable CS0067 // The event 'BrowseTextCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'BrowseTextCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Message = "";
            OpenFileDialogueService openFileDialogue = new OpenFileDialogueService();
            viewModel.BrowseTextBox = openFileDialogue.GetFilePath(BrowseFilter);

            if (viewModel.BrowseTextBox == null)
            {
                return;
            }

            try { viewModel.TranslateText = File.ReadAllText(viewModel.BrowseTextBox); }
            catch { viewModel.Message = "Unable to open file."; }
        }
    }
}

using Dictionary.Services;
using Dictionary.ViewModels;
using System;
using System.IO;
using System.Windows.Input;

namespace Dictionary.Commands
{
    /// <summary>
    /// Opens file dialog, and saves given text parameter to the chosen file path.
    /// </summary>
    class SaveTextCommand : ICommand
    {
        private const string DialogueFilter = "text file (*.txt)|*.txt";
        private readonly PictureViewModel viewModel;

        public SaveTextCommand(PictureViewModel vm)
        {
            viewModel = vm;
        }

#pragma warning disable CS0067 // The event 'SaveTextCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'SaveTextCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Message = "";
            Mouse.OverrideCursor = Cursors.Wait;

            // Check if given text is not empty.
            if (parameter == null || (string)parameter == "")
            {
                viewModel.Message = "There is no text to save.";
                Mouse.OverrideCursor = null;
                return;
            }
            OpenFileDialogueService openFileDialogue = new OpenFileDialogueService();

            try { File.WriteAllText(openFileDialogue.SaveFilePath(DialogueFilter), parameter.ToString()); }
            catch { viewModel.Message = "Unable to save text."; }

            Mouse.OverrideCursor = null;
        }
    }
}

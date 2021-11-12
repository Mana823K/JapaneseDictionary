using Dictionary.Services;
using Dictionary.ViewModels;
using System;
using System.Windows.Input;

namespace Dictionary.Commands
{
    /// <summary>
    /// Searches dictionary for given word, and displays the results.
    /// </summary>
    class DictionarySearchCommand : ICommand
    {
        private readonly DictionarySearchService searchService;
        private readonly DictionaryViewModel viewModel;

        public DictionarySearchCommand(DictionaryViewModel vm)
        {
            searchService = new DictionarySearchService();
            viewModel = vm;
        }

#pragma warning disable CS0067 // The event 'DictionarySearchCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'DictionarySearchCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            viewModel.SearchResults = searchService.DictionarySearch(parameter.ToString());
            if (viewModel.SearchResults.Count == 0)
            {
                viewModel.Message = "No result";
            }
            else
            {
                viewModel.Message = "";
            }
            Mouse.OverrideCursor = null;
        }
    }
}

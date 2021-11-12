using Dictionary.Services;
using Dictionary.ViewModels;
using System;
using System.Windows.Input;

namespace Dictionary.Commands
{
    /// <summary>
    /// Gets search results of a short text.
    /// </summary>
    class TranslateSearchCommand : ICommand
    {
        private readonly TranslateViewModel viewModel;
        private readonly DictionarySearchService searchService;

        public TranslateSearchCommand(TranslateViewModel vm)
        {
            viewModel = vm;
            searchService = new DictionarySearchService();
        }

#pragma warning disable CS0067 // The event 'TranslateSearchCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'TranslateSearchCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            string text = parameter.ToString();
            viewModel.SearchResults = searchService.TranslateSearch(text);
            Mouse.OverrideCursor = null;
        }
    }
}

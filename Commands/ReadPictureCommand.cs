using Dictionary.ViewModels;
using IronOcr;
using System;
using System.Windows.Input;

namespace Dictionary.Commands
{
    /// <summary>
    /// Reads text from a picture at a given file path, and displays the text.
    /// </summary>
    class ReadPictureCommand : ICommand
    {
        private readonly PictureViewModel viewModel;

        public ReadPictureCommand(PictureViewModel vm)
        {
            viewModel = vm;
        }

        /// <summary>
        /// Check for changes in the interface to update CanExecute status.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Checks if the given parameter is empty. Can only execute if there is a file path to use.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if ((string)parameter == "" || parameter == null)
            {
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            string filePath = parameter.ToString();
            IronOcr.Installation.LicenseKey = "IRONOCR.TÓTHALEXANDRA.614-B200231D73-DEQLURZQYT4BQVA-ALYGKIAKFEOT-6NEUVIGTUVJS-VW2P357342MO-7K6EQ3FS6NVN-VPFNNQ-TDA3RXUG2GSCUA-DEPLOYMENT.TRIAL-54DF4V.TRIAL.EXPIRES.09.NOV.2021";
            var Ocr = new IronTesseract();
            Mouse.OverrideCursor = Cursors.Wait;

            // Set horizontal or vertical reading based on user input.
            if (viewModel.IsVertical)
            {
                Ocr.Language = OcrLanguage.JapaneseVerticalBest;
            }
            else
            {
                Ocr.Language = OcrLanguage.JapaneseBest;
            }

            using var input = new OcrInput();

            try
            {
                input.AddImage(filePath);
            }
            catch
            {
                viewModel.Message = "File not found or invalid.";
                viewModel.TranslatedText = "";
                Mouse.OverrideCursor = null;
                return;
            }
            string result = Ocr.Read(input).Text;

            string finalResult = "";

            // Remove white space (OCR adds spaces between characters)
            foreach (char c in result)
            {
                if (!char.IsSeparator(c))
                {
                    finalResult += c;
                }
            }

            viewModel.Message = "";
            viewModel.TranslatedText = finalResult;
            Mouse.OverrideCursor = null;
        }
    }
}

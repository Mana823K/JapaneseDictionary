using Microsoft.Win32;

namespace Dictionary.Services
{
    /// <summary>
    /// Contains methods to get file path for saving and loading files.
    /// </summary>
    class OpenFileDialogueService
    {
        /// <summary>
        /// Gets file path for loading files.
        /// </summary>
        /// <param name="filter">Sets file type filtering</param>
        /// <returns>File path as a string</returns>
        public string GetFilePath(string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        /// <summary>
        /// Gets file path for saving files
        /// </summary>
        /// <param name="filter">Sets file type filtering</param>
        /// <returns>File path as a string</returns>
        public string SaveFilePath(string filter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }
    }
}

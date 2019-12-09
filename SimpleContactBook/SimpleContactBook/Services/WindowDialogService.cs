

using Microsoft.Win32;

namespace SimpleContactBook.Services
{
    public class WindowDialogService : IDialogService
    {
        public string OpenFile(string filter)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }

        public void ShowMessageBox(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}

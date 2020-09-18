using System.Windows;

namespace ZbW.Testing.Dms.Client.Services
{
    public class ShowMessageBox : IMessage
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

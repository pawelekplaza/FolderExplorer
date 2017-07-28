using System.Windows.Media.Imaging;

namespace FolderExplorer.ViewModels
{
    public class FileItemViewModel : BaseViewModel
    {
        private DirectoryItem _directoryItem;

        public FileItemViewModel(string fullPath)
        {
            _directoryItem = new DirectoryItem(fullPath);
        }

        public BitmapSource Icon
        {
            get { return _directoryItem.Icon; }
            set { _directoryItem.Icon = value; }
        }

        public string Name
        {
            get { return _directoryItem.Name; }
            set { _directoryItem.Name = value; }
        }
    }
}

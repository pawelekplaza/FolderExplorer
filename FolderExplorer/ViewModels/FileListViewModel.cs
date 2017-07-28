using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace FolderExplorer.ViewModels
{
    public class FileListViewModel : BaseViewModel
    {
        private ObservableCollection<FileItemViewModel> _items;

        public FileListViewModel(string path)
        {
            var listOfFiles = Directory.GetFiles(path);
            Items = new ObservableCollection<FileItemViewModel>(listOfFiles.Select(element => new FileItemViewModel(element)));
        }

        public ObservableCollection<FileItemViewModel> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ObservableCollection<FileItemViewModel>();                    
                }
                return _items;
            }
            set { _items = value; }
        }
    }
}

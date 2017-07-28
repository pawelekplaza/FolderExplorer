using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderExplorer.ViewModels
{
    public class FileListViewModel : ViewModelBase
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
            set { _items = value; RaisePropertyChanged(nameof(Items)); }
        }
    }
}

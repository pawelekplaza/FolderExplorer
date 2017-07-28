using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FolderExplorer.ViewModels
{
    public class FileItemViewModel : ViewModelBase
    {
        private DirectoryItem _directoryItem;

        public FileItemViewModel(string fullPath)
        {
            _directoryItem = new DirectoryItem(fullPath);
        }

        public BitmapSource Icon
        {
            get { return _directoryItem.Icon; }
            set { _directoryItem.Icon = value; RaisePropertyChanged(nameof(Icon)); }
        }

        public string Name
        {
            get { return _directoryItem.Name; }
            set { _directoryItem.Name = value; RaisePropertyChanged(nameof(Name)); }
        }
    }
}

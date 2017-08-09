using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FolderExplorer.ViewModels
{
    public class FileItemViewModel : BaseViewModel
    {
        private DirectoryItem _directoryItem;

        public FileItemViewModel(string fullPath)
        {
            FullPath = fullPath;
            _directoryItem = new DirectoryItem(FullPath);

            OpenFileCommand = new RelayCommand(() =>
            {
                CmdHelper.Run(FullPath);
            });

            ShowFilePropertiesCommand = new RelayCommand(() =>
            {
                FilePropertiesHelper.ShowFileProperties(FullPath);
            });
        }

        public ICommand OpenFileCommand { get; set; }
        public ICommand ShowFilePropertiesCommand { get; set; }        

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

        public string FullPath { get; set; }
    }
}

using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderExplorer.ViewModels
{
    public class DirectoryStructureViewModel : ViewModelBase
    {
        private DirectoryStructure _directoryStructure;
        private ObservableCollection<DirectoryItemViewModel> _items;

        public DirectoryStructureViewModel()
        {
            _directoryStructure = new DirectoryStructure();            
            Items = new ObservableCollection<DirectoryItemViewModel>(_directoryStructure.Items.Select(drive => new DirectoryItemViewModel(drive.FullPath)));
        }


        public ObservableCollection<DirectoryItemViewModel> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(nameof(Items)); }
        }        
    }
}

using System.Collections.ObjectModel;
using System.Linq;

namespace FolderExplorer.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
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
            set { _items = value; }
        }        
    }
}

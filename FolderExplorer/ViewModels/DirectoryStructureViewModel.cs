using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FolderExplorer.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        private DirectoryStructure _directoryStructure;
        private ObservableCollection<DirectoryItemViewModel> _items;

        public event EventHandler<SelectedEventArgs> Selected;

        public DirectoryStructureViewModel()
        {
            _directoryStructure = new DirectoryStructure();          
            Items = new ObservableCollection<DirectoryItemViewModel>(_directoryStructure.Items.Select(drive => new DirectoryItemViewModel(drive.FullPath)));
            foreach (var item in Items)
            {
                item.Selected += (s, e) => Selected?.Invoke(s, e);
            }
        }


        public ObservableCollection<DirectoryItemViewModel> Items
        {
            get { return _items; }
            set { _items = value; }
        }        
    }
}

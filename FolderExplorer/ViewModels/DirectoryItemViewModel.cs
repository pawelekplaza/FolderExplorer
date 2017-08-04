using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FolderExplorer.ViewModels
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        private DirectoryItem _directoryItem;
        private ObservableCollection<DirectoryItemViewModel> _children;
        private bool _isExpanded;
        private bool _isSelected;

        public event EventHandler<SelectedEventArgs> Selected;

        public DirectoryItemViewModel(string fullPath)
        {
            _directoryItem = new DirectoryItem(fullPath);
            ExpandCommand = new RelayCommand(() =>
            {
                Expand();
            });            

            ClearChildren();
        }

        public DirectoryType Type
        {
            get { return _directoryItem.Type; }
            set { _directoryItem.Type = value; }
        }
        public string FullPath
        {
            get { return _directoryItem.FullPath; }
            set { _directoryItem.FullPath = value; }
        }

        public string Name
        {
            get { return _directoryItem.Name; }
            set { _directoryItem.Name = value; }
        }

        public BitmapSource Icon
        {
            get { return _directoryItem.Icon; }
            set { _directoryItem.Icon = value; }
        }
        
        public ObservableCollection<DirectoryItemViewModel> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new ObservableCollection<DirectoryItemViewModel>();
                }
                return _children;
            }
            set { _children = value; }
        }

        public bool CanExpand
        {
            get { return Type != DirectoryType.File; }
        }
        
        public bool IsExpanded
        {
            get { return Children?.Count(v => v != null) > 0; }
            set
            {
                if (value == true)
                {
                    Expand();
                }
                else
                {
                    ClearChildren();
                }
                                
                _isExpanded = value;
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == true)
                {
                    Selected?.Invoke(this, new SelectedEventArgs { FullPath = this.FullPath });
                }

                _isSelected = value;
            }
        }

        public ICommand ExpandCommand { get; set; }

        private void Expand()
        {
            if (Type == DirectoryType.File)
            {
                return;
            }
            
            var children = DirectoryHelper.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(children.Select(content =>
            {
                var viewModel = new DirectoryItemViewModel(content.FullPath);
                viewModel.Selected += (s, e) => Selected?.Invoke(s, e);
                return viewModel;
            }));
            
            RemoveHiddenItems();            
        }

        private void ClearChildren()
        {
            Children.Clear();
            if (Type == DirectoryType.File)
            {
                return;
            }

            if (DirectoryHelper.HasVisibleContent(FullPath))
            {
                Children.Add(null);                
            }
        }              

        private void RemoveHiddenItems()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>(Children.Where(item => DirectoryHelper.IsHidden(item.FullPath) == false));
        }
    }
}

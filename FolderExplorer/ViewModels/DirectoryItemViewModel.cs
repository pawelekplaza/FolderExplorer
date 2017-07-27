using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class DirectoryItemViewModel : ViewModelBase
    {
        private DirectoryItem _directoryItem;
        private ObservableCollection<DirectoryItemViewModel> _children;
        private bool _isExpanded;
        private ICommand _expandCommand;

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
            set { _directoryItem.Type = value; RaisePropertyChanged(nameof(Type)); }
        }
        public string FullPath
        {
            get { return _directoryItem.FullPath; }
            set { _directoryItem.FullPath = value; RaisePropertyChanged(nameof(FullPath)); }
        }

        public string Name
        {
            get { return _directoryItem.Name; }
            set { _directoryItem.Name = value; RaisePropertyChanged(nameof(Name)); }
        }

        public BitmapSource Icon
        {
            get { return _directoryItem.Icon; }
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
            set { _children = value; RaisePropertyChanged(nameof(Children)); }
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
                _isExpanded = value; RaisePropertyChanged(nameof(IsExpanded));
            }
        }
        
        public ICommand ExpandCommand
        {
            get { return _expandCommand; }
            set { _expandCommand = value; RaisePropertyChanged(nameof(ExpandCommand)); }
        }

        private void Expand()
        {
            if (Type == DirectoryType.File)
            {
                return;
            }
            
            var children = DirectoryHelper.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(children.Select(content => new DirectoryItemViewModel(content.FullPath)));
            
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

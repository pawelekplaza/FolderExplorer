using System;

namespace FolderExplorer
{
    public class SelectedEventArgs : EventArgs
    {
        public string FullPath { get; set; }
    }
}

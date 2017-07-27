using System.Collections.Generic;

namespace FolderExplorer
{
    public class DirectoryStructure
    {
        public List<DirectoryItem> Items { get; set; }

        public DirectoryStructure()
        {
            Items = DirectoryHelper.GetLogicalDrives();
        }
    }
}

using System.Windows.Media.Imaging;

namespace FolderExplorer
{
    public class DirectoryItem
    {
        public DirectoryType Type { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public BitmapSource Icon { get; set; }

        public DirectoryItem(string fullPath)
        {
            FullPath = fullPath;
            Name = DirectoryHelper.GetDirectoryName(FullPath);
            Type = DirectoryHelper.GetDirectoryType(FullPath);
            Icon = DirectoryHelper.GetDirectoryIcon(this);
        }
    }
}

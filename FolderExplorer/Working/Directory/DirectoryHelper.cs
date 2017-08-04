using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace FolderExplorer
{
    public static class DirectoryHelper
    {
        private static string _folderIconName => "Images/folder.png";    
        private static string _driveIconName => "Images/hard-drive.png";
        private static BitmapImage _folderIcon = new BitmapImage(new Uri($"pack://application:,,,/{ _folderIconName }"));        
        private static BitmapImage _driveIcon = new BitmapImage(new Uri($"pack://application:,,,/{ _driveIconName }"));


        public static List<DirectoryItem> GetLogicalDrives()
        {            
            var drives = DriveInfo.GetDrives();
            var validItems = drives.Where(item => item.DriveType == DriveType.Fixed);

            return validItems.Select(item => new DirectoryItem(item.Name)).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = Directory.GetDirectories(fullPath);
            return items.Select(item => new DirectoryItem(item)).ToList();
        }

        public static string GetDirectoryName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace('/', '\\');
            var backSlashIndex = normalizedPath.LastIndexOf('\\');

            if (backSlashIndex <= 0)
            {
                return path;
            }

            if (path.Substring(backSlashIndex + 1) == "")
            {
                return path;
            }

            return path.Substring(backSlashIndex + 1);
        }

        public static DirectoryType GetDirectoryType(string fullPath)
        {
            if (!(new FileInfo(fullPath).Attributes.HasFlag(FileAttributes.Directory)))
            {
                return DirectoryType.File;
            }

            if (GetDirectoryName(fullPath).Equals(fullPath))
            {
                return DirectoryType.Drive;
            }

            return DirectoryType.Folder;
        }

        public static BitmapSource GetDirectoryIcon(DirectoryItem item)
        {
            switch (item.Type)
            {
                case DirectoryType.Drive:
                    return _driveIcon;
                    
                case DirectoryType.File:
                    return GetFileIcon(item.FullPath);

                default:
                    return _folderIcon;
            }
        }

        public static bool IsHidden(string fullPath)
        {
            var info = new FileInfo(fullPath);
            return info.Attributes.HasFlag(FileAttributes.Hidden);
        }

        public static bool HasVisibleContent(string fullPath)
        {
            try
            {                
                return Directory.EnumerateFileSystemEntries(fullPath).Any(item => !IsHidden(item));
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static BitmapSource GetFileIcon(string filePath)
        {
            var icon = Icon.ExtractAssociatedIcon(filePath);
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}

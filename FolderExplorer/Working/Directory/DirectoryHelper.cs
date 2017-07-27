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
        public static string FolderIconName => "Images/folder.png";    
        public static string FolderOpenedIconName => "Images/folder-opened.png";
        public static string FolderWithFilesIconName => "Images/folder-with-files.png";
        public static string DriveIconName => "Images/hard-drive.png";

        public static List<DirectoryItem> GetLogicalDrives()
        {
            var items = Directory.GetLogicalDrives();
            return items.Select(item => new DirectoryItem(item)).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = Directory.GetFileSystemEntries(fullPath);
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
                    return new BitmapImage(new Uri($"pack://application:,,,/{ DriveIconName }"));                
                case DirectoryType.File:
                    return GetFileIcon(item.FullPath);
                default:
                    return new BitmapImage(new Uri($"pack://application:,,,/{ FolderIconName }"));
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

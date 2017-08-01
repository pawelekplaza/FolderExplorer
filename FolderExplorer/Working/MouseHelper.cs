using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FolderExplorer
{
    public static class MouseHelper
    {
        public static Point GetPosition(Window window)
        {
            var position = Mouse.GetPosition(window);
            if (window.WindowState != WindowState.Maximized)
            {
                return new Point(window.Left + position.X, window.Top + position.Y);
            }

            return new Point(position.X, position.Y);
        }
    }
}

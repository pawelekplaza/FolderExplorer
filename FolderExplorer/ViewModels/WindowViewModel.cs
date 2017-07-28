using System.Windows;

namespace FolderExplorer.ViewModels
{
    /// <summary>
    /// The view model for the custom main window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window _window;
        private int _outerMarginSize = Properties.Settings.Default.OuterMarginSize;
        private int _windowRadius = Properties.Settings.Default.WindowRadius;

        public int TitleHeight { get; set; } = Properties.Settings.Default.TitleHeight;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight); } }

        public int ResizeBorder { get; set; } = Properties.Settings.Default.ResizeBorder;
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get { return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize; }
            set { _outerMarginSize = value; }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public int WindowRadius
        {
            get { return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius; }
            set { _windowRadius = value; }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public WindowViewModel(Window window)
        {
            _window = window;

            _window.StateChanged += (s, e) =>
            {
                RaisePropertyChanged(nameof(ResizeBorderThickness));
                RaisePropertyChanged(nameof(OuterMarginSizeThickness));
                RaisePropertyChanged(nameof(WindowCornerRadius));                
            };
        }
    }
}

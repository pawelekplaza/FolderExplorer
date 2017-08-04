using System;
using System.Windows;
using System.Windows.Input;

namespace FolderExplorer.ViewModels
{
    /// <summary>
    /// The view model for the custom main window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {        
        private Window _window;
        private int _outerMarginSize = Properties.Settings.Default.OuterMarginSize;
        private int _windowRadius = Properties.Settings.Default.WindowRadius;

        public int WindowMinimumWidth { get; set; } = 320;
        public int WindowMinimumHeight { get; set; } = 240;
        public int InnerContentPadding { get; set; } = 10;

        public int TitleHeight { get; set; } = Properties.Settings.Default.TitleHeight;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

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

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public WindowViewModel(Window window)
        {
            _window = window;

            _window.StateChanged += (s, e) =>
            {
                RaisePropertyChanged(nameof(ResizeBorderThickness));
                RaisePropertyChanged(nameof(OuterMarginSizeThickness));
                RaisePropertyChanged(nameof(WindowCornerRadius));                
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => Environment.Exit(0));
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, MouseHelper.GetPosition(_window)));               
        }        
    }
}

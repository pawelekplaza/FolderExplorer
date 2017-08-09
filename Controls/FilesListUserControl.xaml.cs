using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Interaction logic for FilesList.xaml
    /// </summary>
    public partial class FilesListUserControl : UserControl
    {
        public FilesListUserControl()
        {
            InitializeComponent();
        }



        public string FullPath
        {
            get { return (string)GetValue(FullPathProperty); }
            set { SetValue(FullPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FullPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FullPathProperty =
            DependencyProperty.Register("FullPath", typeof(string), typeof(FilesListUserControl), new PropertyMetadata(""));
    }
}

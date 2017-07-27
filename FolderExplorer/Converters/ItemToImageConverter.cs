using FolderExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FolderExplorer.Converters
{
    [ValueConversion(typeof(DirectoryItem), typeof(BitmapSource))]
    public class ItemToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sender = value as DirectoryItemViewModel;
            if (sender == null)
            {
                return null;
            }

            return sender.Icon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

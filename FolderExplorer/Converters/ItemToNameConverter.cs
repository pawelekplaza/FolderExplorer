using FolderExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FolderExplorer.Converters
{
    [ValueConversion(typeof(DirectoryItem), typeof(string))]
    public class ItemToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sender = value as DirectoryItemViewModel;
            if (sender == null)
            {
                return string.Empty;
            }

            return sender.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Samples.Cross.WPF.Presentation.Shell.ValuesConverters
{
    public class EnabledToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool)value;
            return b ? new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush(Colors.PaleVioletRed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

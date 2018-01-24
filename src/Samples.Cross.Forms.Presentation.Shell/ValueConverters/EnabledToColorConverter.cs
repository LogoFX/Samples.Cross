using System;
using System.Globalization;
using Xamarin.Forms;

namespace Samples.Cross.Forms.Presentation.Shell.ValueConverters
{
    public class EnabledToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool)value;
            return b ? Color.LightBlue : Color.PaleVioletRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using Samples.Cross.Model.Contracts;
#if NETSTANDARD2_0
using Xamarin.Forms;
#elif NET
using System.Windows.Data;
#endif

namespace Samples.Cross.Forms.Presentation.Shell.ValueConverters
{
    public class ConnectedToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var connectionStatus = (ConnectionStatus)value;
            switch (connectionStatus)
            {
                case ConnectionStatus.Disconnected: return "is not connected";
                case ConnectionStatus.Connected: return "is connected";
                case ConnectionStatus.Error: return "failed to connect";
                default: throw new NotSupportedException(value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

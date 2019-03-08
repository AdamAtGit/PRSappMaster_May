using System;
using Windows.UI.Xaml.Data;

namespace PRSapp.UWP.ViewModels.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string sTime = null;

            return sTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

            if (value != null)
            {
                // TimeSpan;
            }
            return null;
        }
    }
}

using System;
using Windows.UI.Xaml.Data;

namespace PRSapp.UWP.ViewModels.Converters
{
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, string language)
        {
            try
            {
                DateTime dt = (DateTime)value;
                TimeSpan ts = dt - dt.Date;
                return ts;
            }
            catch (Exception)
            {
                return TimeSpan.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType,
                              object parameter, string language)
        {
            //To go from a vm or m,
            //databind string to a Textblock
            throw new NotImplementedException();
        }
    }
}

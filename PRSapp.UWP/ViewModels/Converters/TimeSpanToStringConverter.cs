using System;
using Windows.UI.Xaml.Data;

namespace PRSapp.UWP.ViewModels.Converters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, string language)
        {
            if (value != null)
            {
                try
                {
                    TimeSpan ts = (TimeSpan)value;
                    string str = ts.ToString("T");
                    return str;
                }
                catch (Exception)
                {
                    return "ts.ToString(\"T\" did not convert";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
                              object parameter, string language)
        {
            //Need to do some parsing or Regex etc
            //to turn String back to TimeSpan
            throw new NotImplementedException();
        }
    }
}

using System.Globalization;

namespace TheWeatherApp.Converters
{
    public class WidthSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!parameter.Equals(null))
            {
                var scale = (string)parameter;
                var size = System.Convert.ToDouble(scale);
                return (App.ScreenSize.Width * size).ToString();
            }
            return "1";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HeightSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!parameter.Equals(null))
            {
                var scale = (string)parameter;
                var size = System.Convert.ToDouble(scale);
                return (App.ScreenSize.Height * size).ToString();
            }
            return "1";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

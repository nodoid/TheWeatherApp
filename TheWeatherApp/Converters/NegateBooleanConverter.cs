﻿namespace TheWeatherApp.Converters
{
    public class NegateBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => !(bool)value;
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => !(bool)value;
    }
}

namespace TrashMobile.Converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        private const string InvertParameter = "invert";

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var booleanValue = value is bool ? (bool)value : false;

            if ((string)parameter == InvertParameter)
            {
                booleanValue = !booleanValue;
            }

            var resultValue = Visibility.Collapsed;

            if (booleanValue)
            {
                resultValue = Visibility.Visible;
            }

            return resultValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}

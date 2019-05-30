namespace TrashMobile.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var doubleValue = System.Convert.ToDouble(value);

            return doubleValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var @string = value.ToString();
            var doubleValue = 0.0;
            if(!string.IsNullOrEmpty(@string))
            {
                try
                {
                    doubleValue = System.Convert.ToDouble(@string);
                }
                catch { }
            }
            return doubleValue;
        }
    }
}

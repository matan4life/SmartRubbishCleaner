namespace TrashMobile.Converters
{
    using TrashMobile.Models.Models.Enums;
    using System;
    using Windows.UI.Xaml.Data;

    public class EnumToStringConverter : IValueConverter
    {
        private const string ConverterParameterMustBeEnumNameException = "Exception: [EnumToBooleanConverter] message: converter parameter must be an enum name";

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumValue = (ViewType)value;
            var @string = enumValue.ToString();
            return @string;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (parameter is string enumString)
            {
                return Enum.Parse(typeof(ViewType), enumString);
            }

            throw new ArgumentException(ConverterParameterMustBeEnumNameException);
        }
    }
}

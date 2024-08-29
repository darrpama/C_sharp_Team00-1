using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace rush00.App.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            else if (value is DateTimeOffset dateTimeOffset)
            {
                return dateTimeOffset.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }

            return value;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var dateTime))
                {
                    return dateTime;
                }
            }
            
            return value;
        }
    }
}
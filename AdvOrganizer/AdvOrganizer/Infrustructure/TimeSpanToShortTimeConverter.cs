using System;
using System.Globalization;
using System.Windows.Data;

namespace AdvOrganizer.Infrustructure
{
    class TimeSpanToShortTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = ((TimeSpan)value);
            string result = time.Hours + ":";
            return (time.Minutes != 0) ? result + time.Minutes : result + "00"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int hour = 0, minute = 0;
            var data = value.ToString().Split(':');

            int.TryParse(data[0], out hour);
            int.TryParse(data[1], out minute);
            
            return new TimeSpan(hour, minute, 0);
        }
    }
}

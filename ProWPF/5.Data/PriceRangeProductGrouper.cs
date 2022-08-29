using System;
using System.Globalization;
using System.Windows.Data;

namespace ProWPF.Data
{
    class PriceRangeProductGrouper : IValueConverter
    {
        public int GroupInterval { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;

            if (price < GroupInterval)
            {
                return string.Format("少于{0:C}", GroupInterval);
            }
            else
            {
                int interval = (int)price / GroupInterval;
                int lowerLimit = interval * GroupInterval;
                int upperLimit = (interval + 1) * GroupInterval;
                return string.Format("{0:C} to {1:C}", lowerLimit, upperLimit);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

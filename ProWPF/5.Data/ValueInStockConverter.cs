using System;
using System.Globalization;
using System.Windows.Data;

namespace ProWPF.Data
{
    class ValueInStockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal unitCost = (decimal)values[0];
            int unitsInStock = (int)values[1];
            return unitCost * unitsInStock;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

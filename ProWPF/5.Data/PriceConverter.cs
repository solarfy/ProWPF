using System;
using System.Globalization;
using System.Windows.Data;

namespace ProWPF.Data
{
    [ValueConversion(typeof(decimal), typeof(string))]
    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            //culture = new CultureInfo("zh-CN");     //指定文化
            return price.ToString("C", culture);    //指定货币格式字符串“C”，根据当前线程的文化设置货币符号            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string price = value.ToString();

            /* decimal.Parse()和decimal.TryParse()方法通常不能处理包含了货币符号的字符串。需要使用重载版本的接受System.Globalization.NumberStyles的值。
             * 使用NumberStyles.Any值，并且存在货币符号，就能成功地略过符号。
             */

            if (decimal.TryParse(price, NumberStyles.Any, culture, out decimal result))
            {
                return result;
            }

            return value;
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace ProWPF.Converters
{
    class CheckedToEnumConverter : IValueConverter
    {
        public Type TargetEnum { get; set; }

        //由源改变自身
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == TargetEnum)
            {
                return value.ToString() == parameter.ToString();
            }

            return false;
        }

        //自身改变源
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked)
            {
                if (isChecked)
                {
                    string arg = parameter.ToString();
                    return Enum.Parse(TargetEnum, arg);
                }
            }

            return null;
        }
    }
}

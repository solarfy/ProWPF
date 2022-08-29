/* 根据数据规则格式化元素中的外观
 * 在此使用的时画刷（Brush）而不是颜色（Color），从而可以使用渐变和背景图像创建更高级的突出效果。
 * 如果希望保持标准的透明背景，只需将DefaultBrush或HighlightBrush属性设置为null即可。
 */

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ProWPF.Data
{
    class PriceToBackgroundConverter : IValueConverter
    {
        public decimal MinimumPriceToHighlight { get; set; }

        public Brush HighlightBrush { get; set; }

        public Brush DefaultBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;

            if (price >= MinimumPriceToHighlight)
            {
                return HighlightBrush;
            }
            else
            {
                return DefaultBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Globalization;
using System.Windows.Controls;

namespace ProWPF.Data
{
    class PositivePriceRule : ValidationRule
    {
        public decimal Min { get; set; } = 0;
        public decimal Max { get; set; } = decimal.MaxValue;

        //IsValid属性指示验证是否成功，如果验证不成功（False），ErrorContent属性会提供描述问题的对象。
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;

            try
            {
                if (((string)value).Length > 0)
                {
                    //如果验证与转换器同时存在，就需要确保存在的货币符号能够成功地进行验证
                    price = decimal.Parse((string)value, NumberStyles.Any, cultureInfo);
                }
            }
            catch
            {
                return new ValidationResult(false, "非法字符");
            }

            if (price < Min || price > Max)
            {
                return new ValidationResult(false, $"超出范围[{Min}, {Max}]");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}

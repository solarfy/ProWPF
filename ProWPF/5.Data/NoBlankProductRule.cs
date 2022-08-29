using StoreDataBase.Model;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProWPF.Data
{
    //当使用绑定组时，Validate()方法接收一个BindingGroup对象，BindingGroup对象封装了绑定数据对象（本例中是Product对象）
    class NoBlankProductRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = (BindingGroup)value;
            Product product = (Product)bindingGroup.Items[0];       //在该集合中只有一个数据对象

            /* 注：Validate()方法使用绑定组时，在默认情况下，接收的数据对象是针对元素对象，没有应用任何新的修改。
             *     为得到希望验证的新值，需要调用BindingGroup.GetValue()方法，并传递数据对象和属性名。
             */

            string modelName = (string)bindingGroup.GetValue(product, "ModelName");
            string modelNumber = (string)bindingGroup.GetValue(product, "ModelNumber");

            if (string.IsNullOrEmpty(modelName) && string.IsNullOrEmpty(modelNumber))
            {
                return new ValidationResult(false, "无效的产品");
            }
            else
            {
                return new ValidationResult(true, null);
            }
            
        }
    }
}

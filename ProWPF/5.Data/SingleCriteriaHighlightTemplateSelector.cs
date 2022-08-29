/* 模板选择器，与样式选择器类似
 * 1.构建继承自DataTemplateSelector类自定义类。
 * 2.重新SelecteTemplate()方法。
 * 
 * 会提供代码的可维护性，尽量使用触发器和样式为模板应用不同的格式。
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using StoreDataBase.Model;

namespace ProWPF.Data
{
    class SingleCriteriaHighlightTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }

        public DataTemplate HighlightTemplate { get; set; }

        public string PropertyToEvaluate { get; set; }

        public string PropertyValuteToHighlight { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Product product = (Product)item;

            Type type = product.GetType();
            PropertyInfo property = type.GetProperty(PropertyToEvaluate);

            if (property.GetValue(product).ToString() == PropertyValuteToHighlight)
            {
                return HighlightTemplate;
            }
            else
            {
                return DefaultTemplate;
            }
        }
    }
}

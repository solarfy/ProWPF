/* 样式选择器--根据提供的数据改变项的样式。
 * 1.构建继承自StylesSelector类的自定义类。
 * 2.重写SelectStyle()方法。
 * 
 * 注：样式选择器过程只执行一次，当第一次绑定列表时执行。如果需要强制WPF重新应用样式，需要将ItemContainerStyleSelector属性设置为null来移除样式，然后再指定样式选择器。
 *          StyleSelector selector = lstProducts.ItemContainerStyleSelector;
 *          lstProducts.ItemContainerStyleSelector = null;
 *          lstProducts.ItemContainerStyleSelector = selector;
 *          
 *    可通过INotifyPropertyChanged接口类引发该事件，或使用DataTable.RowChanged事件，更多的采用Binding.SourceUpdate事件（Binding.NotifyOnSourceUpdate为true时，才会引发该事件）
 */

using StoreDataBase.Model;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Data
{
    class SingleCriteriaHighlightStyleSelector : StyleSelector 
    {
        public Style DefaultStyle { get; set; }

        public Style HighlightStyle { get; set; }

        public string PropertyToEvaluate { get; set; }

        public string PropertyValueToHighlight { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            Product product = (Product)item;

            Type type = product.GetType();
            PropertyInfo property = type.GetProperty(PropertyToEvaluate);

            if (property.GetValue(product).ToString() == PropertyValueToHighlight)
            {
                return HighlightStyle;
            }
            else
            {
                return DefaultStyle;
            }
        }
    }
}

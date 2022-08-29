/* 浏览控件中的模板
 * 1.使用反射扫描PresentationFramework.dll核心程序集（该程序集中定义了控件类）中的所有类型
 * 2.窗口实际显示控件之前，控件的模板为空。使用反射创建控件的一个实例，并将其添加到当前窗口中（Visibility设置为Collapse，使控件不可见）
 * 3.使用XamlWriter.Save()静态方法将ControlTemplate对象转换为XAML标记。使用XamlWriter和XamlWriterSettings对象以确保XAML缩进合理，以便于阅读。
 * 4.异常处理监视不能被创建或不能被添加到Grid面板中的控件（Window或Page）产生的问题。
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace ProWPF.TemplateAndCustom
{
    /// <summary>
    /// ControlTemplateBorwer.xaml 的交互逻辑
    /// </summary>
    public partial class ControlTemplateBrowser : Window
    {
        private class TypeComparer : IComparer<Type>
        {
            public int Compare(Type x, Type y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }

        public ControlTemplateBrowser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>() { };

            //查找程序集中所有定义的控件
            Assembly assembly = Assembly.GetAssembly(controlType);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }

            //根据自定义类进行排序
            derivedTypes.Sort(new TypeComparer());

            //显示类集合
            this.lstTypes.ItemsSource = derivedTypes;
        }

        private void Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //获取选中的类型
                Type type = (Type)this.lstTypes.SelectedItem;

                //实例化类
                ConstructorInfo info = type.GetConstructor(Type.EmptyTypes);        //无参构造函数 同Array.Empty<Type>()
                Control control = (Control)info.Invoke(null);

                //将实例化后的控件加入grid面板中，并隐藏
                control.Visibility = Visibility.Collapsed;
                this.grid.Children.Add(control);

                //获取控件模板
                ControlTemplate template = control.Template;

                //获取模板的XAML标记
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;     //缩进元素的值
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);

                //显示控件模板的XAML标记
                this.txtTemplate.Text = sb.ToString();

                //移除实例化的控件
                this.grid.Children.Remove(control);
            }
            catch (Exception exc)
            {
                this.txtTemplate.Text = $"<< 出错：{exc.Message} >>";
            }
        }
    }
}

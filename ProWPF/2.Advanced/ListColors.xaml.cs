using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ProWPF.Advanced
{
    /// <summary>
    /// ListControls.xaml 的交互逻辑
    /// </summary>
    public partial class ListColors : Window
    {
        public ListColors()
        {
            InitializeComponent();

            //使用ContainerFromElement()方法，检索ListBoxItem的封装器
            //ListBoxItem listBoxItem = (ListBoxItem)this.listColors.ContainerFromElement((DependencyObject)item);
        }

        public static List<FullColor> ListFullColors 
        {
            get
            {
                List<FullColor> colors = new List<FullColor>() { };

                Type t = typeof(Colors);
                PropertyInfo[] properties = t.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    FullColor full = new FullColor()
                    {
                        ColorValue = (Color)property.GetValue(null),
                        ColorName = property.Name,
                    };

                    colors.Add(full);
                }

                return colors;
            }
        }

        private void Examine_Click(object sender, RoutedEventArgs e)
        {
            if (this.listColors.SelectedItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder(8);
                Color color = Colors.Transparent;

                //多重选项，所以使用SelectedItems
                foreach (var item in this.listColors.SelectedItems)
                {
                    if (item is FullColor full)
                    {
                        sb.Append(full.ColorName);
                        sb.Append(",  ");

                        color = color + full.ColorValue;
                    }
                }

                this.runSelectionColors.Text = sb.ToString().Trim(new char[] { ',', ' '});
                this.borderColorsView.Background = new SolidColorBrush(color);
               
            }
            else
            {
                this.runSelectionColors.Text = string.Empty;
                this.borderColorsView.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }

    //自定义值类型。用于存储颜色名称
    public struct FullColor
    {
        //需要用的Blinding，所以设置为属性

        public Color ColorValue { get; set; }
        public string ColorName { get; set; }
    }
}

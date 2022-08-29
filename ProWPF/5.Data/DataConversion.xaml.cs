using System;
using System.Collections.Generic;
using System.Windows;

namespace ProWPF.Data
{
    /// <summary>
    /// DataConversion.xaml 的交互逻辑
    /// </summary>
    public partial class DataConversion : Window
    {
        public int UnitsInStock { get; set; } = 3;

        public DataConversion()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lstProducts.ItemsSource = App.StoreDB.GetProducts();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"获取产品信息出错：{exc.Message}");
            }
        }
    }

    //常用数据格式字符串
    public class CommonFormatString
    {
        //类型
        public string Type { get; set; }
        //格式字符串
        public string Format { get; set; }
        //示例
        public string Example { get; set; }

        public CommonFormatString(string _type, string _format, string _example)
        {
            Type = _type;
            Format = _format;
            Example = _example;
        }

        public static ICollection<CommonFormatString> Commons
        {
            get => GetCommons();
        }

        private static ICollection<CommonFormatString> GetCommons()
        {
            List<CommonFormatString> commons = new List<CommonFormatString>() { };

            commons.Add(new CommonFormatString("货币", "C", "$1 234.50\r\n圆括号表示负值：($1 234.50)\r\n货币符号特定于区域"));
            commons.Add(new CommonFormatString("科学计数法（指数）", "E", "1 234.50E+0.04"));
            commons.Add(new CommonFormatString("百分数", "P", "45.6%"));
            commons.Add(new CommonFormatString("固定小数", "F?", "取决于设置小数位数，F3格式化类似于123.400，F0类似于123"));
            commons.Add(new CommonFormatString("短日期", "d", "M/d/yyyy\r\n例如：01/30/2013"));
            commons.Add(new CommonFormatString("长日期", "D", "dddd,MMMM dd,yyyy\r\n例如：星期三，1月 30号，2013"));
            commons.Add(new CommonFormatString("长日期和短日期", "f", "dddd,MMMM dd,yyyy HH:mm aa\r\n例如：星期三，1月 30号，2013 10:00 AM"));
            commons.Add(new CommonFormatString("长日期和短日期", "F", "dddd,MMMM dd,yyyy HH:mm:ss aa\r\n例如：星期三，1月 30号，2013 10:00:23 AM"));
            commons.Add(new CommonFormatString("ISO Sortable标准", "s", "yyyy-MM-dd HH:mm:ss\r\n例如：2013-01-30 10:00:23"));
            commons.Add(new CommonFormatString("月和日", "M", "MMMM dd\r\n例如：1月 30号"));
            commons.Add(new CommonFormatString("同样格式", "G", "M/d/yyyy HH:mm:ss aa(取决于特定区域设置)\r\n例如：10/30/2013 10:00:23 AM"));

            return commons;
        }
    }
}

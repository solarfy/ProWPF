using System;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Advanced
{
    /// <summary>
    /// DateControl.xaml 的交互逻辑
    /// </summary>
    public partial class DateControl : Window
    {
        public DateControl()
        {
            InitializeComponent();
        }

        //当用户在文本输入部分输入不能被解释为合法时间的值时触发该事件
        private void DatePicker_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            this.textError.Text = $"{e.Text} 不是一个有效值：{e.Exception.Message}";
        }

        //检索选中的日期
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DateTime dt in e.AddedItems)
            {
                //无法选中周一
                if (dt.DayOfWeek == DayOfWeek.Monday)   
                {
                    ((System.Windows.Controls.Calendar)sender).SelectedDates.Remove(dt);
                }
            }
        }
    }    
}

/* 注：使用null值的绑定。绑定表达式中可以使用TargetNullValue，当数据源为null时，将显示所设置的值。
 *     Text = "{Binding Path = Description, TargetNullValue=[No Description Provided]}"  显示[No Description Provided] 方括号是可选的
 *  
 *     TextBox.Text属性在默认情况下使用双向绑定，根据触发方式，其在失去焦点后更新数据。
 *     所以在更新数据库时，需先将焦点转移触发数据更新，在将更新后的数据上传至数据库，可在更新数据库之前使用如下方式转移焦点。
 *     FocusManager.SetFocusedElement(this, (Button)sender);
 *     
 *     将按钮IsDefault属性设置为True，当按下Enter键触发该按钮。
 *     
 *     使用System.ComponentModel.INotifyPropertyChanged接口，引发PropertyChanged事件通知UI界面属性发生了变化
 * 
 */

using StoreDataBase.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProWPF.Data
{
    /// <summary>
    /// BindingProductObject.xaml 的交互逻辑
    /// </summary>
    public partial class BindingProductObject : Window
    {
        public BindingProductObject()
        {
            InitializeComponent();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(this.txtID.Text, out int ID))
            {
                try
                {
                    this.gridProductDetails.DataContext = App.StoreDB.GetProduct(ID);
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"查询出错：{exc.Message}");
                }
            }
            else
            {
                MessageBox.Show("无效的ID");
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, (Button)sender);

            Product product = (Product)this.gridProductDetails.DataContext;

            try
            {
                //更新数据库
            }
            catch (Exception exc)
            {
                MessageBox.Show($"数据更新出错：{exc.Message}");
            }
        }
    }
}

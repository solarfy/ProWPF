using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Data
{
    /// <summary>
    /// DataValidation.xaml 的交互逻辑
    /// </summary>
    public partial class DataValidation : Window
    {
        public DataValidation()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.gridProduct.DataContext = App.StoreDB.GetProduct(355);   //获取产品编号为355的产品
                this.txtUnitCost.DataContext = App.StoreDB.GetProduct(356);
                this.gridProductDtails.DataContext = App.StoreDB.GetProduct(400);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"获取数据出错：{exc.Message}");
            }
        }

        //将Binding.NotifyOnValidationError属性设置为true，当发生错误时将在元素上引发Validation.Error附加事件
        //Validation.Error事件是使用冒泡策略的路由事件，所有可通过在父容器中关联事件处理程序。
        private void UnitCost_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {                
                this.txtblkUnitCostError.Text = e.Error.ErrorContent.ToString();
            }
            else
            {
                this.txtblkUnitCostError.Text = string.Empty;
            }
        }

        //将Binding.NotifyOnValidationError属性设置为true，当发生错误时将在元素上引发Validation.Error附加事件
        private void ModelNumber_Error(object sender, ValidationErrorEventArgs e)
        {
            //检测到正在添加错误
            if (e.Action == ValidationErrorEventAction.Added)
            {
                this.texblkModleNumberError.Text = e.Error.ErrorContent.ToString();
            }
            else
            {
                this.texblkModleNumberError.Text = string.Empty;
            }
        }

        private void GetErrors_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            GetErrors(sb, this.gridProduct);

            this.txtblkErrors.Text = sb.ToString();
        }

        //使用递归遍历整个元素层次
        private void GetErrors(in StringBuilder sb, DependencyObject obj)
        {
            foreach (object child in LogicalTreeHelper.GetChildren(obj))
            {
                if (child is TextBox tb)
                {
                    if (Validation.GetHasError(tb))
                    {
                        sb.Append(tb.Text + " has errors:\r\n");
                        foreach (ValidationError error in Validation.GetErrors(tb))
                        {
                            sb.Append(" " + error.ErrorContent.ToString());
                            sb.Append("\r\n");
                        }
                    }

                    //检查此对象的子对象是否也存在错误
                    GetErrors(sb, tb);
                }
                else if (child is DependencyObject depobj)
                {
                    GetErrors(sb, depobj);
                }
            }
        }

        private void GridProductDtails_LostFocus(object sender, RoutedEventArgs e)
        {
            this.productBindingGroup.CommitEdit();
        }
    }
}

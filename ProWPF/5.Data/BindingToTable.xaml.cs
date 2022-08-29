/* 绑定到ADO.NET对象
 * （一种用于和数据源进行交互的面向对象类库，通常情况下是数据库，也能是文本文件，Excel表格或XML文件）
 * 常用对象DataSet数据集，DataTable数据表，DataRow表中的行
 * 
 * 可检索DataTable对象并使用与绑定ObservableCollection集合几乎完全相同的方式将它绑定到列表上。唯一的区别是不能直接绑定到DataTable本身，
 * 而需使用DataView对象，可以手工创建DataView对象，但通常使用自带的该对象，通过使用DataTable.DefaulteView属性获取该对象。
 * 
 * DataView类实现了IBindingList接口，如果添加新的DataRow对象或删除已有的DataRow对象，DataView类或通知WPF基础结构。
 * 在删除时要注意如果使用以下方式删除
 *          products.Rows.Remove((DataRow)lstProducts.SelectedItem);
 * 该删除方式存在两个问题：1.列表中选择的项不是DataRow对象--而是由DataView对象提供的精简过的DataRowView封装器。
 *                         2.您可能不希望从数据表的行集合中删除DataRow对象，而是希望将它标记为已删除，从而当向数据库提交修改时，删除相应的记录。
 * 修改后的删除
 *          ((DataViewRow)lstProducts.SelectedItem).Row.Delete();
 * 先获取DataViewRow对象，使用该对象的Row属性查找对应的DataRow对象，并调用找到的DataRow对象的Delete()方法将行标识为即将删除。
 * 现在准备删除的DataRow对象从列表中消失了，但从技术上看它仍然位于DataTable.Rows集合中。这是因为DataView中的默认过滤设置隐藏了所有已删除的记录。
 */

using System;
using System.Data;
using System.Windows;

namespace ProWPF.Data
{
    /// <summary>
    /// BindingToTable.xaml 的交互逻辑
    /// </summary>
    public partial class BindingToTable : Window
    {
        public BindingToTable()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lstProducts.ItemsSource = App.StoreDB.GetProductTable().DefaultView;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"加载数据集出错：{exc.Message}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //将选中的项标记为已删除
            if (this.lstProducts.SelectedItem != null)
            {
                ((DataRowView)this.lstProducts.SelectedItem).Row.Delete();
            }
        }
    }
}

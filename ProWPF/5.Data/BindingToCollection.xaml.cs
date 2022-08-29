/* 集合绑定：
 * ItemSource -- 指向的集合包含在列表中显示的所有对象。数据集合需实现IEnumerable接口
 * DisplayMemberPath -- 确定用于为每个项创建显示文本的属性。不设置将会调用项数据的ToString()方法
 * ItemTemplate -- 接受的数据模板用于为每个项创建可视化外观
 * 
 * 对集合的修改，并更新在UI上，需实现INotifyCollectionChanged接口。WPF提供了一个使用INotifyCollectionChanged接口的集合，ObservableCollection类。
 * ObservableCollection继承自List类，为了使其更加通用，可为返回类型使用ICollection<T>，该接口包含了所需要的所有成员。
 * 
 * LINQ的基础是IEnumerable<T>接口，不管使用什么数据源，每个LINQ表达式都返回一些实现IEnumerable<T>接口的对象。
 * 与ObservableCollection集合以及DataTable类不同，IEnumerable<T>接口没有提供添加和删除项的方法，但可以通过使用ToList()或ToArrary()方法将其转换成List集合或数组。
 * 使用ToList()和ToArray()方法使得LINQ表达式被立即计算，最终结果是普通集合。
 */

using StoreDataBase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ProWPF.Data
{
    /// <summary>
    /// BindingToCollection.xaml 的交互逻辑
    /// </summary>
    public partial class BindingToCollection : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Product> products = new ObservableCollection<Product>() { };
        public ObservableCollection<Product> Products 
        {
            get => products;
            set 
            {
                products = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Products"));
            }            
        }

        public BindingToCollection()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Products = (ObservableCollection<Product>)App.StoreDB.GetProducts();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"获取数据列表出错：{exc.Message}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Products.Remove((Product)this.lstProducts.SelectedItem);
        }

        private void Chk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.chkUnitCost.IsChecked == true)
                {
                    List<Product> collection = App.StoreDB.GetProducts().ToList();
                    IEnumerable<Product> matches = from m in collection
                                                   where m.UnitCost >= 100
                                                   select m;

                    Products = new ObservableCollection<Product>(matches);
                }
                else
                {
                    Products = (ObservableCollection<Product>)App.StoreDB.GetProducts();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"获取数据集出错：{exc.Message}");
            }
        }
    }
}

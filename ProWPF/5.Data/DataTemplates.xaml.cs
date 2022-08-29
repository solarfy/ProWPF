using StoreDataBase.Model;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Data
{
    /// <summary>
    /// DataTemplates.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplates : Window
    {
        public DataTemplates()
        {
            InitializeComponent();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Product product = (Product)btn.Tag;
            this.lstProducts.SelectedItem = product;
            MessageBox.Show(product.CategoryName);
        }
    }
}

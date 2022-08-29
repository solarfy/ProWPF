using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Data
{
    /// <summary>
    /// AboutListView.xaml 的交互逻辑
    /// </summary>
    public partial class AboutListView : Window
    {
        public AboutListView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.lstvProducts.ItemsSource = App.StoreDB.GetProducts();
            this.cboxView.SelectionChanged += View_Changed;
        }

        private void View_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)this.cboxView.SelectedItem;
            this.lstvProducts.View = (ViewBase)this.FindResource(selectedItem.Content);
        }
    }
}

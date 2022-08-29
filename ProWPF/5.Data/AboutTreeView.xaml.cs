using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Data
{
    /// <summary>
    /// AboutTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class AboutTreeView : Window
    {
        public AboutTreeView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.tvProducts.ItemsSource = App.StoreDB.GetCategoriesAndProducts();
                DataSet ds = App.StoreDB.GetCategoriesAndProductsDataSet();
                this.tvProductDS.ItemsSource = ds.Tables["Categories"].DefaultView;

                //将驱动器列表添加到TreeView控件中
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeViewItem item = new TreeViewItem();
                    item.Tag = drive;
                    item.Header = drive.ToString();

                    item.Items.Add("*");    //占位符，一旦展开节点，就可以删除占位符并在它的位置添加子目录列表。同时占位符可以使节点处于可打开状态。
                    this.treeFileSystem.Items.Add(item);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"获取数据失败：{exc.Message}");
            }
        }

        private void Item_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();

            DirectoryInfo dir;
            if (item.Tag is DriveInfo drive)
            {
                dir = drive.RootDirectory;  //根目录
            }
            else
            {
                dir = (DirectoryInfo)item.Tag;
            }

            try
            {
                //根据子目录填充树节点
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = subDir;
                    newItem.Header = subDir.ToString();
                    newItem.Items.Add("*");     //占位符，一旦展开节点，就可以删除占位符并在它的位置添加子目录列表。同时占位符可以使节点处于可打开状态。
                    item.Items.Add(newItem);
                }
            }
            catch
            {
                //异常处理
            }
        }
    }
}

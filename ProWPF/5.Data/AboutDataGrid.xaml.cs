using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StoreDataBase.Model;

namespace ProWPF.Data
{
    /// <summary>
    /// AboutDataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class AboutDataGrid : Window
    {
        public AboutDataGrid()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.categoryColumn.ItemsSource = App.StoreDB.GetCategories();
                this.dgProducts.ItemsSource = App.StoreDB.GetProducts();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"获取数据出错：{exc.Message}");
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            //DataGrid列的Visiblity属性使用Binding方式时无效，所以此处采用手动编码的方式
            CheckBox chk = (CheckBox)e.OriginalSource;
            int index = int.Parse(chk.Tag.ToString());
            this.dgProducts.Columns[index].Visibility = (chk.IsChecked == true) ? Visibility.Visible : Visibility.Hidden;
        }
     
        /* LoadingRow事件，它提供了当前行数据对象的访问，允许开发人员执行简单的范围检查、比较以及更复杂的操作。它还提供了行DataGridRow对象，
         * 允许开发人员使用不同的颜色或不同的字体设置行格式（只能设置一行，不能设置单个单元格--可使用DataGridTemplateColumn和自定义的值转换器）。
         * 只用当前可见行引发LoadingRow事件，当用户在网格中滚动时，会连续引发该事件，所以该事件中不能执行耗时的操作。
         * 为降低内存开销，DataGrid控件使用了项容器再循环，所以每次使用DataGridRow对象时，必须明确地将每行恢复至初始状态。         
         */
        private void DataGridProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Product product = (Product)e.Row.DataContext;

            e.Row.Header = e.Row.GetIndex();

            if (product.UnitCost > 100)
            {
                e.Row.Background = new SolidColorBrush(Colors.Orange);
            }
            //使用了项容器在循环，必须将DataGridRow对象恢复初始状态
            else
            {
                e.Row.Background = new SolidColorBrush(Colors.White);
            }
        }
    }

    public class DataGridProperties
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DataGridProperties(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static ICollection<DataGridProperties> Properties 
        {
            get => GetDataGridProperties();
        }

        public static ICollection<DataGridProperties> GetDataGridProperties()
        {
            List<DataGridProperties> list = new List<DataGridProperties>();

            list.Add(new DataGridProperties("RowBackground","绘制每行背景的画刷"));
            list.Add(new DataGridProperties("AlternateRowBackground", "交替行背景"));
            list.Add(new DataGridProperties("ColumnHeaderHeight", "位于DataGrid控件顶部的列标题行的高度"));
            list.Add(new DataGridProperties("RowHeaderWidth", "具有行题头的列的宽度。该列在网格的最左边，不显示任何数据。使用箭头指示当前选择的行，使用圈主的箭头指示正在编辑的行"));
            list.Add(new DataGridProperties("ColumnWidth", "DataGridLength对象，用于设置每列默认宽度的尺寸改变模式"));
            list.Add(new DataGridProperties("RowHeight", "每行的高度。与列不同，用户不能改变行的尺寸"));
            list.Add(new DataGridProperties("GridLineVisiblity", "确定是否显示网格线的DataGridGridlines枚举值（Horizontal、Vertical、None或All）"));
            list.Add(new DataGridProperties("VerticalGridLinesBrush", "绘制列之间网格线的画刷"));
            list.Add(new DataGridProperties("HorizontalGridLinesBrush", "绘制行之间网格线的画刷"));
            list.Add(new DataGridProperties("HeadersVisiblity", "确定显示哪个题头的DataGridHeader枚举值（Column、Row、All、None）"));
            list.Add(new DataGridProperties("HorizontalScrollBarVisiblity\r\nVerticalScrollBarVisiblity", "确定是否显示滚动条的ScrollBarVisiblity枚举值（Auto、Visiblity、Hidden）"));            

            return list;
        }


        public static ICollection<DataGridProperties> Columns
        {
            get => GetDataGridColumns();
        }

        public static ICollection<DataGridProperties> GetDataGridColumns()
        {
            List<DataGridProperties> list = new List<DataGridProperties>();

            list.Add(new DataGridProperties("DataGridTextColumn", "值被转换成文本，并在TextBlock元素中显示。当编辑时，TextBlock元素被替换为标准的文本框"));
            list.Add(new DataGridProperties("DataGridCheckBoxColumn", "复选框，为Boolean(或可空Boolean)值自动使用。可将IsThreeState属性设置为true，可使绑定的值使用null值"));
            list.Add(new DataGridProperties("DataGridHyperlinkColumn", "超链接，可导航到其他URI。仅当在支持导航事件容器（Frame或NavigationWindow）中放置DataGrid控件时，才支持自动导航"));
            list.Add(new DataGridProperties("DataGridComboBox", "编辑时该列会变为下拉的ComboBox控件"));
            list.Add(new DataGridProperties("DataGridTemplateColumn", "自定义数据模板"));

            list.Add(new DataGridProperties("-", "-"));
            
            list.Add(new DataGridProperties("ElementStyle", "创建应用于DataGrid单元格内部的元素的样式。对于DataGridTextColumn，该元素是TextBlock；对于DataGridCheckBoxColumn，该元素是CheckBox；对于DataGridTemplateColumn，该元素是在数据模板中创建的任何元素"));
            list.Add(new DataGridProperties("EditingElementStyle", "为编辑列时使用的元素提供样式。对于DataGridTextColumn，该元素时TextBox"));
            list.Add(new DataGridProperties("ColumnHeaderStyle", "位于网格顶部的列题头的TextBlock"));
            list.Add(new DataGridProperties("RowHeaderStyle", "行题头的TextBlock"));
            list.Add(new DataGridProperties("DragIndicatorStyle", "当用户正在将列题头拖动到新位置时用于列题头的TextBlock"));
            list.Add(new DataGridProperties("RowStyle", "用于普通行（在列中没有通过列的ElementStyle属性明确制定过的行）的TextBlock"));


            return list;
        }
    }        
}

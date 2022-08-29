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
using System.ComponentModel;
using StoreDataBase.Model;
using System.Data;

namespace ProWPF.Data
{
    /// <summary>
    /// DataView.xaml 的交互逻辑
    /// </summary>
    public partial class DataView : Window
    {
        private ListCollectionView view;
        private ProductByPriceFilter filter;
        private BindingListCollectionView bindinView;
        private System.Data.DataView dv;

        //排序规则
        private SortDescription unitCostSort = new SortDescription("UnitCost", ListSortDirection.Ascending);
        //自定义排序规则
        private SortByTextLength<Product> modelNameLengthSort = new SortByTextLength<Product>("ModelName");

        public DataView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ICollection<Product> products = App.StoreDB.GetProducts();
            this.gridProduct.DataContext = products;        //这里使用的集合而不是集合中的某一项，WPF足够智能，自动绑定到集合中的当前项

            view = (ListCollectionView)CollectionViewSource.GetDefaultView(this.gridProduct.DataContext);
            view.CurrentChanged += View_CurrentChanged;
            //view.MoveCurrentToFirst(); //view.MoveCurrentTo(SelectedItem);

            //以声明方式创建数据视图，必须通过CollectionViewSource对象传递数据，而不能直接为列表提供数据
            CollectionViewSource viewSource = (CollectionViewSource)this.FindResource("GroupByRangeView");
            viewSource.Source = products;       //设置数据源

            //使用DataTable对象，该对象使用的BindingListCollectionView视图，并且使用CustomFilter属性进行过滤
            DataTable dtProducts = App.StoreDB.GetProductTable();
            dv = dtProducts.DefaultView;
            this.tableProducts.ItemsSource = dv;
            bindinView = (BindingListCollectionView)CollectionViewSource.GetDefaultView(this.tableProducts.ItemsSource);
        }

        private void View_CurrentChanged(object sender, EventArgs e)
        {
            this.txtPosition.Text = $"Record {view.CurrentPosition + 1} of {view.Count}";
            this.btnPrev.IsEnabled = view.CurrentPosition > 0;
            this.btnNext.IsEnabled = view.CurrentPosition < view.Count - 1;
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToPrevious();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToNext();
        }

        private void TxtMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (view != null)
            {
                if (decimal.TryParse(this.txtMinPrice.Text, out decimal minimumPrice) && filter != null)
                {
                    filter.MinimumPrice = minimumPrice;
                    view.Refresh();     //强制重新过滤列表
                }
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(this.txtMinPrice.Text, out decimal miniPrice))
            {
                if (view != null)
                {
                    filter = new ProductByPriceFilter(miniPrice);
                    view.Filter = new Predicate<object>(filter.FilterItem);
                }
            }
        }

        private void RemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            if (view != null)
            {
                view.Filter = null;     //删除过滤器
            }
        }

        private void TableFilter_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(this.txtMiniTablePrice.Text, out decimal miniPrice))
            {
                if (bindinView!= null)
                {
                    bindinView.CustomFilter = $"UnitCost > {miniPrice}";    //或者 dv.RowFilter = $"UnitCost > {miniPrice}";
                }
            }            
        }

        private void TableRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            if (bindinView != null)
            {
                bindinView.CustomFilter = null;
            }
        }

        private void UnitCostSort_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox chk)
            {
                if (chk.IsChecked == true)
                {
                    view.SortDescriptions.Add(unitCostSort);
                    bindinView.SortDescriptions.Add(unitCostSort);

                }
                else
                {
                    view.SortDescriptions.Remove(unitCostSort);
                    bindinView.SortDescriptions.Remove(unitCostSort);
                }
            }
        }

        private void ModelNameSort_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox chk)
            {
                if (chk.IsChecked == true)
                {
                    view.CustomSort = modelNameLengthSort;
                    dv.Sort = "ModelName ASC";
                    //dv.RowFilter = "Len(ModelName) > 20";
                }
                else
                {
                    view.CustomSort = null;
                    dv.Sort = null;
                }

            }
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            view.SortDescriptions.Clear();
            view.GroupDescriptions.Clear();

            //如果希望对分组进行排序，需确保用于排序的第一个SortDescription对象基于分组字段即可
            view.SortDescriptions.Add(new SortDescription("CategoryName", ListSortDirection.Ascending));
            //对组中的数据进行排序
            view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));

            //分组
            view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));
        }

        private void RangeGroup_Click(object sender, RoutedEventArgs e)
        {
            view.SortDescriptions.Clear();
            view.GroupDescriptions.Clear();

            //先对价格进行排序
            view.SortDescriptions.Add(new SortDescription("UnitCost", ListSortDirection.Ascending));
            //对价格进行范围分组
            PriceRangeProductGrouper grouper = new PriceRangeProductGrouper();
            grouper.GroupInterval = 50;
            view.GroupDescriptions.Add(new PropertyGroupDescription("UnitCost", grouper));
        }

        private void RemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            view.SortDescriptions.Clear();
            view.GroupDescriptions.Clear();
        }

        private void EnabledLive_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox chk)
            {
                if (chk.IsChecked == true)
                {
                    view.IsLiveFiltering = true;
                    view.LiveFilteringProperties.Add("UnitCost");
                }
                else
                {
                    view.IsLiveFiltering = false;
                    view.LiveFilteringProperties.Clear();
                }
            }
        }

        private void EnabledFilter_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox chk)
            {
                if (chk.IsChecked == true)
                {
                    ProductByPriceFilter filter = new ProductByPriceFilter(50);
                    view.Filter = new Predicate<object>(filter.FilterItem);                    
                }
                else
                {
                    view.Filter = null;
                }
            }

        
        }
    }
}

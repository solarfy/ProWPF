using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProWPF.TemplateAndCustom
{
    /// <summary>
    /// VisualTreeDisplay.xaml 的交互逻辑
    /// </summary>
    public partial class VisualTreeDisplay : Window
    {
        public VisualTreeDisplay()
        {
            InitializeComponent();
        }

        public void ShowVisualTree(DependencyObject element)
        {
            this.treeElement.Items.Clear();

            ProcessElement(element, null);
        }

        private void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            //在当前的元素创建一个TreeViewItem
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;

            //如果是null就将其设置为根节点，如果是嵌套的就将其放在嵌套的节点下
            if (previousItem == null)
            {
                this.treeElement.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }

            //检查当前元素中是否嵌套了其它的元素
            for (int i = 0;i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                //递归处理当前元素中每一个嵌套的元素
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }           
        }
    }
}

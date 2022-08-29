using System.Windows;
using System.Windows.Controls;

namespace ProWPF.TemplateAndCustom
{
    /// <summary>
    /// LogicalTreeDisplay.xaml 的交互逻辑
    /// </summary>
    public partial class LogicalTreeDisplay : Window
    {
        public LogicalTreeDisplay()
        {
            InitializeComponent();
        }

        public void ShowLogicalTree(DependencyObject element)
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
            foreach (var child in LogicalTreeHelper.GetChildren(element))
            {
                //递归处理当前元素中每一个嵌套的元素
                if (child is DependencyObject dep)
                {
                    ProcessElement(dep, item);
                }
                else
                {
                    TreeViewItem tvi = new TreeViewItem();
                    tvi.Header = child.GetType().Name;
                    item.Items.Add(tvi);                    
                }
            }
        }
    }
}

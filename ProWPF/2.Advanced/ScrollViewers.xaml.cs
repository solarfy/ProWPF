using System.Windows;

namespace ProWPF.Advanced
{
    /// <summary>
    /// ScrollViewers.xaml 的交互逻辑
    /// </summary>
    public partial class ScrollViewers : Window
    {
        public ScrollViewers()
        {
            InitializeComponent();            
        }

        private void LineUp_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.LineUp();
        }

        private void LineDown_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.LineDown();
        }

        private void PageUp_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.PageUp();
        }

        private void PageDown_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.PageDown();
        }

        private void ScrollToEnd_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.ScrollToEnd();
        }

        private void ScrollToHome_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.ScrollToHome();
        }

        private void ScrollToVerticalOffset_Click(object sender, RoutedEventArgs e)
        {
            this.scrv.ScrollToVerticalOffset(200);  //到达指定位置  
        }
    }
}

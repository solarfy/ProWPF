using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProWPF.Advanced
{
    /// <summary>
    /// StyleAndBehavior.xaml 的交互逻辑
    /// </summary>
    public partial class StyleAndBehavior : Window
    {
        public StyleAndBehavior()
        {
            InitializeComponent();
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.FontSize = (double)this.Resources["BigSize"];            
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.FontSize = (double)this.Resources["NormalSize"];
        }
    }
}

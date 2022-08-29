using System.Windows;
using System.Windows.Media;

namespace ProWPF.TemplateAndCustom
{
    /// <summary>
    /// CustomControlExample.xaml 的交互逻辑
    /// </summary>
    public partial class CustomControlExample : Window
    {
        public CustomControlExample()
        {
            InitializeComponent();
        }

        private void ColorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            this.txtblk.Text = $"选择的颜色是：{e.NewValue}";
        }

        private void Flip1_Click(object sender, RoutedEventArgs e)
        {
            this.flipPanel_1.IsFlipped = !this.flipPanel_1.IsFlipped;
        }

        private void Flip2_Click(object sender, RoutedEventArgs e)
        {
            this.flipPanel_2.IsFlipped = !this.flipPanel_2.IsFlipped;
        }
    }
}

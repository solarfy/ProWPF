using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProWPF.Advanced
{
    /// <summary>
    /// AboutBinding.xaml 的交互逻辑
    /// </summary>
    public partial class AboutBinding : Window
    {
        public AboutBinding()
        {
            InitializeComponent();

            CreateBindingByCode();
        }

        //用代码创建绑定
        private void CreateBindingByCode()
        {
            Binding binding = new Binding();
            binding.Source = this.slider_3;
            binding.Path = new PropertyPath(nameof(this.slider_3.Value));
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            //binding.Delay = 2000;   //2s  手动模式下无效
            this.text_3.SetBinding(TextBox.TextProperty, binding);
            
            this.textblk_3.SetBinding(TextBlock.FontSizeProperty, new Binding() { Source = this.slider_3, Path = new PropertyPath(nameof(this.slider_3.Value)) });
        }

        private void BtnExpliciteUpdate_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = BindingOperations.GetBindingExpression(this.text_3, TextBox.TextProperty);      //获取绑定表达式
            binding.UpdateSource();     //手动触发，更新源属性（目标更改源）
        }
    }
}

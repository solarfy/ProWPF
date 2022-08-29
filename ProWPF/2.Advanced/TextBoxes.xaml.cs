using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Advanced
{
    /// <summary>
    /// TextBoxes.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxes : Window
    {
        public TextBoxes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            string methodName = btn.Content.ToString();

            Type t = typeof(TextBox);
            MethodInfo method = t.GetMethod(methodName);
            method?.Invoke(this.text, Array.Empty<Array>());
        }

        private void Text_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (this.text.SelectionLength > 0)
            {
                this.runSelection.Text = this.text.SelectedText;
            }
        }
    }
}

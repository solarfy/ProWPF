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

namespace ProWPF.TemplateAndCustom
{
    /// <summary>
    /// LogicalAndVisual.xaml 的交互逻辑
    /// </summary>
    public partial class LogicalAndVisual : Window
    {
        public LogicalAndVisual()
        {
            InitializeComponent();
        }

        private void LogicalDisplay_Click(object sender, RoutedEventArgs e)
        {
            LogicalTreeDisplay display = new LogicalTreeDisplay();
            display.Owner = this;
            display.ShowLogicalTree(this);
            display.Show();
        }

        private void VisualDisplay_Click(object sender, RoutedEventArgs e)
        {
            VisualTreeDisplay display = new VisualTreeDisplay();
            display.Owner = this;
            display.ShowVisualTree(this);
            display.Show();
        }
    }
}

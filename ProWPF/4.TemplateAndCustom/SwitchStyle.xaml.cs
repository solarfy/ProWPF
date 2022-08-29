using System;
using System.Windows;

namespace ProWPF.TemplateAndCustom
{
    /// <summary>
    /// SwitchStyle.xaml 的交互逻辑
    /// </summary>
    public partial class SwitchStyle : Window
    {
        public SwitchStyle()
        {
            InitializeComponent();
        }

        private void SolidBrush_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("pack://application:,,,/ProWPFResource;component/Themes/SolidBrushDictionary.xaml", UriKind.Absolute);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void GradientBrush_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("../../ProWPFResource;component/Themes/GradientBrushDictionary.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void SolidBrushDictionary_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries[0] = new ProWPFResource.Themes.SolidBrushDictionary();
        }

        private void GradientBrushDictionary_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries[0] = new ProWPFResource.Themes.GradientBrushDictionary();
        }
    }
}

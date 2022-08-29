using System.Windows;
using System.Windows.Media;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// PathAndGeometry.xaml 的交互逻辑
    /// </summary>
    public partial class PathAndGeometry : Window
    {
        public PathAndGeometry()
        {
            InitializeComponent();
        }

        private void LargeArc_Checked(object sender, RoutedEventArgs e)
        {
            this.arc2.IsLargeArc = true;
            this.arc2.SweepDirection = SweepDirection.Clockwise;
        }

        private void LargeArc_Unchecked(object sender, RoutedEventArgs e)
        {
            this.arc2.IsLargeArc = false;
            this.arc2.SweepDirection = SweepDirection.Counterclockwise;
        }
    }
}

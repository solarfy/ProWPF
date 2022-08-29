using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// PolygonAndPolyline.xaml 的交互逻辑
    /// </summary>
    public partial class PolygonAndPolyline : Window
    {
        public PolygonAndPolyline()
        {
            InitializeComponent();
        }

        private void LineCap_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rb)
            {
                string str = rb.Content.ToString();
                PenLineCap cap = (PenLineCap)Enum.Parse(typeof(PenLineCap), str);
                this.polyline.StrokeStartLineCap = this.polyline.StrokeEndLineCap = cap;
            }
        }

        private void LineJoins_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rb)
            {
                string str = rb.Content.ToString();

                if (Enum.TryParse(str, out PenLineJoin join))
                {
                    this.polyline.StrokeLineJoin = join;
                }
                else
                {
                    this.polyline.StrokeLineJoin = PenLineJoin.Miter;
                    this.polyline.StrokeMiterLimit = 3.0;
                }
            }
        }

        private void StrokeDashArray_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rb)
            {
                DoubleCollection collection = (DoubleCollection)this.Resources[rb.Tag.ToString()];
                this.polyline.StrokeDashArray = collection;
            }
        }

        private void StorkeDashCap_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rb)
            {
                string str = rb.Content.ToString();
                PenLineCap cap = (PenLineCap)Enum.Parse(typeof(PenLineCap), str);
                this.polyline.StrokeDashCap = cap;
            }
        }

        private void StrokDashOffset_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rb)
            {
                string str = rb.Content.ToString();
                this.polyline.StrokeDashOffset = double.Parse(str);
            }
        }
    }
}

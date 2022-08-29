using System;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// AboutBrush.xaml 的交互逻辑
    /// </summary>
    public partial class AboutBrush : Window
    {
        public AboutBrush()
        {
            InitializeComponent();
        }     

        private void Rectangle_DragInCanvas(object sender, EventArgs e)
        {
            Rect rect = new Rect
            {
                Width = this.rectangle.ActualWidth / this.canvas.ActualWidth,
                Height = this.rectangle.ActualHeight / this.canvas.ActualHeight,
                X = (double)this.rectangle.GetValue(Canvas.LeftProperty) / this.canvas.ActualWidth,
                Y = (double)this.rectangle.GetValue(Canvas.TopProperty) / this.canvas.ActualHeight
            };

            this.googleView.Viewbox = rect;
        }
    }
}

using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ProWPF.Behaviors
{
    class WatermarkTexBehavior : Behavior<TextBox>
    {
        public string Watermark { get; set; } = "水印";

        public Brush WatermarkBrush { get; set; } = new SolidColorBrush(Colors.Silver);

        //初始前景画刷
        private Brush originalBrush;

        private bool isDisplayWatermark;

        protected override void OnAttached()
        {
            base.OnAttached();
            
            base.AssociatedObject.LostFocus += AssociatedObject_LostFocus;
            base.AssociatedObject.GotFocus += AssociatedObject_GotFocus;

            originalBrush = base.AssociatedObject.Foreground;

            AssociatedObject_LostFocus(null, null);     //手动执行，判断是否显示水印文字
        }

        protected override void OnDetaching()
        {
            base.AssociatedObject.LostFocus -= AssociatedObject_LostFocus;
            base.AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }

        private void AssociatedObject_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isDisplayWatermark)
            {
                ClearWatermark();
                isDisplayWatermark = false;
            }
        }

        private void AssociatedObject_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (base.AssociatedObject.Text.Length == 0)
            {
                DisplayWatermark();
                isDisplayWatermark = true;
            }
        }

        private void DisplayWatermark()
        {
            base.AssociatedObject.Text = Watermark;
            base.AssociatedObject.Foreground = WatermarkBrush;            
        }

        private void ClearWatermark()
        {
            base.AssociatedObject.Text = string.Empty;
            base.AssociatedObject.Foreground = originalBrush;            
        }
    }
}

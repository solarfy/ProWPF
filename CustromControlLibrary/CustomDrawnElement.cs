/* 自定义绘图元素，OnRender()方法。该方法中不能显示的创建和关闭DrawingContext对象。
 * [也可创建DrawingVisual对象，并使用AddVisualChild()方法未UIElement对象添加可视化对象]
 * 
 * 注：切勿在控件中使用自定义绘图。如果在控件中使用自定义绘图，就违反了WPF无外观控件的承诺，就会使得控件可视化外观的一部分不能通过控件模板进行定制。
 * 
 * 使用自定义绘图元素通常在以下两个方面：
 * 1.绘制一些小的图形细节（例如滚动按钮上的箭头）
 * 2.它们在另一元素的周围提供更加详细的背景或边框。----自定以装饰元素
 */ 

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControlLibrary
{
    //CustomDrawnElement不包含任何子内容，所以它直接继承自FrameworkElement
    public class CustomDrawnElement : FrameworkElement
    {
        public static readonly DependencyProperty BackgroundColorProperty;

        static CustomDrawnElement()
        {
            //使用FrameworkPropertyMetadata.AffectRender标志，无论何时改变了背景色，WPF都会自动调用OnRender()方法
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.AffectsRender = true;
            BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(CustomDrawnElement), metadata);
        }

        public Color BackgroundColor
        {
            get => (Color)base.GetValue(BackgroundColorProperty);
            set => base.SetValue(BackgroundColorProperty, value);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Rect bounds = new Rect(0, 0, base.ActualWidth, base.ActualHeight);
            drawingContext.DrawRectangle(GetForegroundBrush(), null, bounds);
        }

        //当鼠标移动到新的位置时，也需要确保调用OnRender()方法。通过调用InvalidateVisual()方法实现。
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.InvalidateVisual();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.InvalidateVisual();
        }

        private Brush GetForegroundBrush()
        {
            if (!this.IsMouseOver)
            {
                return new SolidColorBrush(BackgroundColor);
            }
            else
            {
                RadialGradientBrush brush = new RadialGradientBrush(Colors.White, BackgroundColor);
                Point absouluteGradientOrigin = Mouse.GetPosition(this);
                Point relativeGradientOrigin = new Point(absouluteGradientOrigin.X / base.ActualWidth, absouluteGradientOrigin.Y / base.ActualHeight);
                brush.GradientOrigin = relativeGradientOrigin;
                brush.Center = relativeGradientOrigin;
                return brush;
            }
        }
    }
}

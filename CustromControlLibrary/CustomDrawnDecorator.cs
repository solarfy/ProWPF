/* 自定义装饰元素，继承自System.Windows.Controls.Decorator
 * 重新MeasureOverride()方法，指定需要的尺寸。所有装饰元素都会考虑它们的子元素(Child)，增加装饰元素所需要的额外控件，然后返回组合之后的尺寸。
 * 被类中使用的是与子元素相同的尺寸，所以不需要额外的控件来绘制边框。
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControlLibrary
{
    public class CustomDrawnDecorator : Decorator
    {
        private Point mousePoint;
        private double radiusX, radiusY;
        private double distanceX, distanceY;
        private bool drawing;

        protected override Size MeasureOverride(Size constraint)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                child.Measure(constraint);
                return child.DesiredSize;
            }
            else
            {
                return new Size();
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            mousePoint = Mouse.GetPosition(this);
            distanceX = Math.Max(mousePoint.X, base.ActualWidth - mousePoint.X);
            distanceY = Math.Max(mousePoint.Y, base.ActualHeight - mousePoint.Y);
            radiusX = radiusY = 0;
            drawing = true;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (drawing)
            {
                this.InvalidateVisual();
            }
            else
            {
                CompositionTarget.Rendering -= CompositionTarget_Rendering;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            double drag = 10;
            radiusX += drag;
            radiusY += drag;

            if (radiusX > distanceX && radiusY > distanceY)
            {
                drawing = false;
                drawingContext.DrawRectangle(null, null, new Rect(0, 0, this.ActualWidth, this.ActualHeight));
            }
            else
            {
                drawingContext.DrawEllipse(Brushes.Green, null, mousePoint, radiusX, radiusY);
            }
        }
    }
}

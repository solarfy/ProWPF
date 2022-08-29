using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ProWPF.Behaviors
{
    class MoveGradientOriginBehavior : Behavior<System.Windows.Shapes.Shape>
    {
        private RadialGradientBrush brush = null;

        protected override void OnAttached()
        {
            base.OnAttached();

            if (base.AssociatedObject.Fill is RadialGradientBrush)
            {
                brush = (RadialGradientBrush)base.AssociatedObject.Fill;
            }

            if (brush != null)
            {
                base.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (brush != null)
            {
                base.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            }
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(base.AssociatedObject);           
            brush.GradientOrigin = new Point(pt.X / base.AssociatedObject.ActualWidth, pt.Y / base.AssociatedObject.ActualHeight);
        }
    }
}

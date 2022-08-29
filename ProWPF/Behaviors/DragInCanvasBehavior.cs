using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ProWPF.Behaviors
{
    class DragInCanvasBehavior : Behavior<FrameworkElement>
    {
        /* 覆盖OnAttached()方法和OnDetaching()方法，OnAttached()关联事件处理程序，OnDetaching()移除事件处理程序
         * AssociatedObject属性表示放置行为的元素
         */

        public EventHandler DragInCanvas { get; set; }

        //拖拽范围
        public Rect DragRange { get; set; } = new Rect(0, 0, double.MaxValue, double.MaxValue);

        protected override void OnAttached()
        {
            base.OnAttached();

            //对于某些控件（如：Button）内部会自动挂起一些事件，所有此处使用隧道事件
            base.AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            base.AssociatedObject.PreviewMouseMove += AssociatedObject_MouseMove;
            base.AssociatedObject.PreviewMouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();

            base.AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            base.AssociatedObject.PreviewMouseMove -= AssociatedObject_MouseMove;
            base.AssociatedObject.PreviewMouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        //元素所处的容器
        private Canvas canvas;
        //点击元素时，记录鼠标点相对于拖拽元素的偏移位置
        private Point mouseOffset;
        //拖拽状态
        private bool isDragging = false;

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (canvas == null)
            {
                canvas = (Canvas)VisualTreeHelper.GetParent(base.AssociatedObject);
            }

            isDragging = true;

            mouseOffset = e.GetPosition(base.AssociatedObject);

            base.AssociatedObject.CaptureMouse();   //捕获鼠标，当鼠标移出窗口外，也能响应鼠标事件
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point point = e.GetPosition(canvas);
                Point position = new Point(point.X - mouseOffset.X, point.Y - mouseOffset.Y);

                if (position.X < DragRange.X)
                {
                    position.X = DragRange.X;
                }
                else if (position.X > DragRange.X + DragRange.Width - base.AssociatedObject.ActualWidth)
                {
                    position.X = DragRange.X + DragRange.Width - base.AssociatedObject.ActualWidth;
                }

                if (position.Y < DragRange.Y)
                {
                    position.Y = DragRange.Y;
                }
                else if (position.Y > DragRange.Y + DragRange.Height - base.AssociatedObject.ActualHeight)
                {
                    position.Y = DragRange.Y + DragRange.Height - base.AssociatedObject.ActualHeight;
                }

                base.AssociatedObject.SetValue(Canvas.LeftProperty, position.X);
                base.AssociatedObject.SetValue(Canvas.TopProperty, position.Y);

                DragInCanvas?.Invoke(sender, e);
            }
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                base.AssociatedObject.ReleaseMouseCapture();    //释放鼠标
                isDragging = false;
            }
        }               
    }
}

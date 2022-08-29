using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProWPF.PerFrameAnimations.ReusableFollowMouse
{
    class FollowMouseCanvas : Canvas
    {
        private Vector velocity = new Vector(0, 0);
        private Point lastMousePosition = new Point(0, 0);
        private TimeSpan lastRendering;
        private Canvas parentCanvas = null;

        //对目标位置的偏移分量
        public Vector Deviation { get; set; } = new Vector(0, 0);

        public FollowMouseCanvas() : base()
        {
            lastRendering = TimeSpan.FromTicks(DateTime.Now.Ticks);
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            //计算时间增量
            RenderingEventArgs args = (RenderingEventArgs)e;
            double deltaTime = (args.RenderingTime - lastRendering).TotalSeconds;
            lastRendering = args.RenderingTime;

            if (parentCanvas == null)
            {
                parentCanvas = VisualTreeHelper.GetParent(this) as Canvas;

                if (parentCanvas == null)
                {
                    //如果不为Canvas，则移除CompositionTarget.Rendering处理时间
                    CompositionTarget.Rendering -= CompositionTarget_Rendering;
                }
                else
                {
                    //如果是Canvas，就开始跟踪鼠标位置
                    parentCanvas.PreviewMouseMove += ParentCanvas_PreviewMouseMove;
                }
            }

            //获取当前的位置
            Point location = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
            //检查Nan并替换为（0，0）
            if (double.IsNaN(location.X) || double.IsNaN(location.Y))
            {
                location = new Point(0, 0);
            }

            //指向鼠标位置的向量
            Vector toMouse = lastMousePosition - location;

            //计算向指定位置移动的具体向量（1.0为完全重合）
            double followForce = 1.0;
            toMouse += Deviation;   //自定义的偏移量
            velocity += toMouse * followForce;

            //每次移动的分量
            double drag = 0.9;
            velocity *= drag;

            //根据时间增量以及移动分量计算出目的位置
            location += velocity * deltaTime;

            //更新位置
            Canvas.SetLeft(this, location.X);
            Canvas.SetTop(this, location.Y);
        }

        private void ParentCanvas_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (parentCanvas == null) return;
            lastMousePosition = e.GetPosition(parentCanvas);
        }
    }
}

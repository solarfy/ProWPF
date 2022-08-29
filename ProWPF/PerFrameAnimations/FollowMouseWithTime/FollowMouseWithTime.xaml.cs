using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProWPF.PerFrameAnimations.MouseFollowWithTime
{
    /// <summary>
    /// MouseFollowWithTime.xaml 的交互逻辑
    /// </summary>
    public partial class FollowMouseWithTime : Page
    {
        private Point lastMousePosition = new Point(0, 0);
        private Vector followPathVelocity = new Vector(0, 0);

        //记录上一次渲染的时间。由时间决定动画速度。
        private TimeSpan lastRender;

        public FollowMouseWithTime()
        {
            InitializeComponent();
            lastRender = TimeSpan.FromTicks(DateTime.Now.Ticks);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }
       
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
        }

        private void Page_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            lastMousePosition = e.GetPosition(this.canvas);
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RenderingEventArgs renderArgs = (RenderingEventArgs)e;

            //时间增量
            double deltaTime = (renderArgs.RenderingTime - lastRender).TotalSeconds;
            lastRender = renderArgs.RenderingTime;

            Point location = new Point(Canvas.GetLeft(this.followPath), Canvas.GetTop(this.followPath));

            //指向鼠标位置的向量
            Vector toMouse = lastMousePosition - location;

            //添加向鼠标方向的力 （鼠标与跟随块同步）
            double followForce = 1.0;
            followPathVelocity += toMouse * followForce;

            //降低速度以增加稳定性    （每次移动的距离）
            double drag = 0.9;
            followPathVelocity *= drag;

            //根据速度更新位置  （时间越长，更新量就越大）
            location += followPathVelocity * deltaTime;

            //设置新的位置
            Canvas.SetLeft(this.followPath, location.X);
            Canvas.SetTop(this.followPath, location.Y);
        }

    }
}

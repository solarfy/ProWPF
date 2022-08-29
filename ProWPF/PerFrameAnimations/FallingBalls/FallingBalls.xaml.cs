using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProWPF.PerFrameAnimations.FallingBalls
{
    /// <summary>
    /// FallingBalls.xaml 的交互逻辑
    /// </summary>
    public partial class FallingBalls : Page
    {
        private List<EllipseInfo> balls = new List<EllipseInfo>() { };

        private double accelerationY = 0.1;
        private int minStartingSpeed = 1;
        private int maxStartingSpeed = 50;
        private double speedRatio = 0.1;
        private int minBalls = 100;
        private int maxBalls = 200;
        private int ellipseRadius = 10;

        private bool rendering = false;

        public FallingBalls()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //清空集合，并将事件处理程序关联到CompositionTarget.Rendering事件
            if (!rendering)
            {
                balls.Clear();
                this.canvas.Children.Clear();

                CompositionTarget.Rendering += CompositionTarget_Rendering;
                rendering = true;
            }
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            //如果椭圆不存在，就创建随机数量的椭圆，并使用它们具有相同的尺寸和颜色，将它们放置在Canvas面板的顶部，随机的X轴。
            if (balls.Count == 0)
            {
                int halfCanvasWidth = (int)this.canvas.ActualWidth / 2;

                Random rand = new Random();
                int ballCount = rand.Next(minBalls, maxBalls + 1);
                for (int i = 0; i < ballCount; i++)
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Fill = Brushes.LimeGreen;
                    ellipse.Width = ellipseRadius;
                    ellipse.Height = ellipseRadius;

                    Canvas.SetLeft(ellipse, halfCanvasWidth + rand.Next(-halfCanvasWidth, halfCanvasWidth));
                    Canvas.SetTop(ellipse, 0);
                    this.canvas.Children.Add(ellipse);

                    EllipseInfo ball = new EllipseInfo(ellipse, speedRatio * rand.Next(minStartingSpeed, maxStartingSpeed));
                    balls.Add(ball);
                }
            }
            //如果椭圆已存在，便根据指定速度下落椭圆。
            else
            {
                //为提高性能，一旦椭圆到达Canvas面板的底部，就从跟踪的集合中删除椭圆。所以为了能够工作而不会导致丢失位置，需要向后迭代，从集合末尾向起始位置迭代。
                for (int i = balls.Count - 1; i >= 0; i--)
                {
                    EllipseInfo ball = balls[i];
                    double top = Canvas.GetTop(ball.Ball);
                    Canvas.SetTop(ball.Ball, top + 1 * ball.VelocityY);     //根据速度移动椭圆
                    
                    if (top >= (this.canvas.ActualHeight - ellipseRadius * 2))
                    {
                        balls.Remove(ball);     //并没有在Canvas面板中移除

                        //如果所有的椭圆都从集合中删除，就移除事件处理程序，然后结束动画。
                        if (balls.Count == 0)
                        {
                            CompositionTarget.Rendering -= CompositionTarget_Rendering;
                            rendering = false;
                        }
                    }
                    else
                    {
                        //如果椭圆尚未达到Canvas面板的底部，代码会提高速度（为了获得磁吸效果，还可以根据椭圆与Canvas面板底部的距离来设置速度）
                        ball.VelocityY += accelerationY;
                    }
                }
            }
        }
    }

    public class EllipseInfo
    {
        //球（椭圆）的引用
        public Ellipse Ball { get; set; }

        //Y轴下落的速度
        public double VelocityY { get; set; }

        public EllipseInfo(Ellipse ball, double velocityY)
        {
            Ball = ball;
            VelocityY = velocityY;
        }
    }
}

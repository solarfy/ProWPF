using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ProWPF.PerFrameAnimations.MouseFollow
{
    /// <summary>
    /// MouseFlow.xaml 的交互逻辑
    /// </summary>
    public partial class FollowMouse : Page
    {
        private Point lastMousePosition = new Point(0, 0);
        private Vector followPathVelocity = new Vector(0, 0);

        public FollowMouse()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
        }

        //需设置Canvas.Backgtound属性，才能获取到鼠标事件
        private void Page_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            lastMousePosition = e.GetPosition(this.canvas);
        }

        private void RandColors()
        {
            Random rand = new Random();
            //this.followPath.Stroke = new SolidColorBrush(Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
            //this.followPath.Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
            ((DropShadowEffect)this.followPath.Effect).Color = Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RandColors();
            
            Point location = new Point(Canvas.GetLeft(this.followPath), Canvas.GetTop(this.followPath));

            //指向鼠标位置的向量
            Vector toMouse = lastMousePosition - location;      //向哪个方向的向量，就将哪个方向的点作为终点，用终点减去起点。

            //添加一个向鼠标移动的力 (若为1跟随块将与鼠标同步)
            double followForce = 0.01;
            followPathVelocity += followForce * toMouse;        //向量乘以常数还是向量，向量方向不变，向量模是原向量模乘以常数；向量的加减就是向量对应分量的加减。

            //降低速度以增加稳定性 （若不进行该操作，更随块块将会一直处于匀速状态无法停止）
            double drag = 0.8;
            followPathVelocity *= drag;

            //根据速度更新位置 （没次向目标位置进行靠拢，drag每次靠拢的分量）
            location += followPathVelocity;

            //设置新的位置
            Canvas.SetLeft(this.followPath, location.X);
            Canvas.SetTop(this.followPath, location.Y);
        }

        
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// BasicAnimation.xaml 的交互逻辑
    /// </summary>
    public partial class BasicAnimation : Window
    {
        public BasicAnimation()
        {
            InitializeComponent();
            //System.Windows.Media.RenderCapability.Tier
            DrawLinesInCanvas();
        }

        private void StartAnimations()
        {
            /* 每个依赖属性每次只能相应一个动画，如果开始第二个动画，将自动放弃第一个动画。
             * 动画结束后，无论怎样的行为都会将属性值设置为动画前的值，如果希望保存动画目标值，可在动画对象中添加Completed处理事件。
             */ 

            //From值是Width属性的开始值，如果多次单击按钮，每次单击时，都会将Width属性重写设置为160，并且重新开始运行动画。            
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.From = 160;            
            widthAnimation.To = 30;
            widthAnimation.Duration = TimeSpan.FromSeconds(5);
            this.btn1.BeginAnimation(Button.WidthProperty, widthAnimation);

            //可将From值设为ActualWidth解决上述情况，该属性给出的是当前的渲染值
            widthAnimation = new DoubleAnimation();
            widthAnimation.From = this.btn2.ActualWidth;
            widthAnimation.To = 30;
            widthAnimation.Duration = TimeSpan.FromSeconds(5);
            this.btn2.BeginAnimation(Button.WidthProperty, widthAnimation);

            //通过硬编码Width的值，忽略From属性，将默认使用当前值作为From值（否则Width值为NaN，not a number）
            //注：当使用当前值作为动画起点时，将会拖慢动画的运行速度，因为未调整动画的持续时间，使得动画在最初值和最终值直接跨度变小了，即变换速率下降了。
            widthAnimation = new DoubleAnimation();
            widthAnimation.To = 30;
            widthAnimation.Duration = TimeSpan.FromSeconds(5);
            this.btn3.BeginAnimation(Button.WidthProperty, widthAnimation);

            //忽略From属性和To属性。From属性使用当前的Width值（例如将按钮拉宽，From将使用拉宽后的按钮值），To属性使用最后一次在代码中、元素标签中或样式中的值
            //如果From与To值相等时将不发生动画
            widthAnimation = new DoubleAnimation();
            widthAnimation.Duration = TimeSpan.FromSeconds(5);
            this.btn4.BeginAnimation(Button.WidthProperty, widthAnimation);

            //使用By属性，使得比当前尺寸大-50个单位；（多次点击按钮后，该按钮将消失）
            widthAnimation = new DoubleAnimation();
            widthAnimation.By = -50;     //widthAnimation.To = this.btn5.Width + 10;     //能够实现同样的效果
            widthAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.btn5.BeginAnimation(Button.WidthProperty, widthAnimation);

            //使用IsAdditive = True；当前值被自动添加到From值和To值。
            //该动画起始值为当前值加10个单位，结束值为当前值加50个单位。（如果将From设置为0，起始值就为当前值）
            widthAnimation = new DoubleAnimation();
            widthAnimation.IsAdditive = true;
            widthAnimation.From = 10;
            widthAnimation.To = 50;
            widthAnimation.Duration = TimeSpan.FromSeconds(0.5);
            //widthAnimation.Completed += WidthAnimation_Completed;
            this.btn6.BeginAnimation(Button.WidthProperty, widthAnimation);
            
        }

        private void WidthAnimation_Completed(object sender, EventArgs e)
        {
            double curretnWidth = this.btn6.Width;      //记录当前动画的值
            //使用BeginAnimation()方法渲染不活动的动画，传递Null动画对象；根据依赖属性每次只能使用一个动画规则，此处删除掉第一个动画，第二个动画为Null所有不执行
            this.btn6.BeginAnimation(Button.WidthProperty, null);       
            this.btn6.Width = curretnWidth;     //手动设置新值，从第一个动画对象中获取到的值
        }

        private void UniformGrid_Click(object sender, RoutedEventArgs e)
        {
            StartAnimations();
        }

        /// <summary>
        /// 控制动画的播放速率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpeedRatio_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.storyboardBegin.Storyboard;
            Button btn = (Button)sender;

            if (btn.Content.ToString() == "快放")
            {
                btn.Content = "正常";
                sb.SpeedRatio = 4.0;      //如果是在执行中的动画这样设置只能作用于新的动画，无法更正正在运行的动画
                sb.SetSpeedRatio(this, sb.SpeedRatio);        //第一个参数是顶级动画容器（本例中是窗口），第二参数是新的速率
            }
            else
            {
                btn.Content = "快放";
                sb.SpeedRatio = 1.0;
                sb.SetSpeedRatio(this, sb.SpeedRatio);
            }
        }

        /// <summary>
        /// 监视动画进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            Clock storyboardClock = (Clock)sender;

            if (storyboardClock.CurrentProgress == null)
            {
                this.tbTime.Text = "[停止]";
                this.progressBar.Value = 0;
            }
            else
            {
                this.tbTime.Text = storyboardClock.CurrentTime.Value.ToString("hh\\:mm\\:ss\\.ff");
                this.progressBar.Value = storyboardClock.CurrentProgress.Value;
            }

        }

        /// <summary>
        /// 在Canvas面板中绘制随机线段
        /// </summary>
        private void DrawLinesInCanvas()
        {
            PathGeometry geometry = new PathGeometry();

            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(0, 0);

            PathSegmentCollection segmentCollection = new PathSegmentCollection();
            Random rand = new Random();
            int maxWidth = this.canvas.ActualWidth == 0 ? 790 : (int)this.canvas.ActualWidth;
            int maxHeight = this.canvas.ActualHeight == 0 ? 380 : (int)this.canvas.ActualHeight;
            for (int i = 0; i < 500; i++)
            {
                LineSegment line = new LineSegment();
                line.Point = new Point(rand.Next(0, maxWidth), rand.Next(0, maxHeight));
                segmentCollection.Add(line);     //上一条线段的终点是下一条线段的起点
            }

            figure.Segments = segmentCollection;
            geometry.Figures.Add(figure);
            this.pathBackground.Data = geometry;
        }
      
        private void CacheMode_Click(object sender, RoutedEventArgs e)
        {
            if (this.chxEnableCache.IsChecked == true)
            {
                BitmapCache bitmapCache = new BitmapCache();
                bitmapCache.RenderAtScale = this.chxScale.IsChecked == true ? 10 : 1;

                this.pathBackground.CacheMode = bitmapCache;      //启用位图缓存
                this.chxScale.Visibility = Visibility.Visible;
            }
            else
            {
                this.pathBackground.CacheMode = null;
                this.chxScale.Visibility = Visibility.Hidden;
                this.chxScale.IsChecked = false;
            }
        }
    }
}

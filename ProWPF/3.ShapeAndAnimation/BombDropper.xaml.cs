using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// BombDropper.xaml 的交互逻辑
    /// </summary>
    public partial class BombDropper : Window
    {
        //投掷炸弹定时器
        private DispatcherTimer bombTimer;

        //记录投下和拦截的炸弹数量
        private int droppedCount = 0;
        private int savedCount = 0;

        //初始炸弹每1.3秒落下，3.5秒后落在地上
        private double initialSecondsBetweenBombs = 1.3;
        private double initialSecondsToFail = 3.5;
        private double secondsBetweenBombs;
        private double secondsToFall;

        //每10秒进行一次调整
        private double secondBetweenAdjustments = 10;
        private DateTime lastAdjustmentTime = DateTime.MinValue;
        //每次调整都递减0.1秒
        private double secondsBetweenBombsReduction = 0.1;
        private double secondsToFallReduction = 0.1;

        //当5颗炸弹落下时结束游戏
        private int maxDropped = 5;

        //存储炸弹与故事板集合
        private Dictionary<Bomb, Storyboard> storyboards = new Dictionary<Bomb, Storyboard>() { };

        public BombDropper()
        {
            InitializeComponent();
            bombTimer = new DispatcherTimer();
            bombTimer.Tick += BombTimer_Tick;
        }

        private void BombTimer_Tick(object sender, EventArgs e)
        {
            //创建炸弹
            Bomb bomb = new Bomb();
            bomb.IsFalling = true;

            //放置炸弹
            Random random = new Random();
            Canvas.SetLeft(bomb, random.Next(0, (int)this.canvas.ActualWidth - 50));
            Canvas.SetTop(bomb, -100.0);

            //将炸弹加入Canvas面板
            this.canvas.Children.Add(bomb);

            //创建炸弹左右摇摆动画
            DoubleAnimation wiggleAnimation = new DoubleAnimation();
            wiggleAnimation.To = 40;
            wiggleAnimation.Duration = TimeSpan.FromSeconds(0.5);
            wiggleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            wiggleAnimation.AutoReverse = true;          
            Storyboard.SetTarget(wiggleAnimation, bomb);
            Storyboard.SetTargetProperty(wiggleAnimation, new PropertyPath("RenderTransform.Children[0].Angle"));

            //创建炸弹下落动画
            DoubleAnimation fallAnimation = new DoubleAnimation();
            fallAnimation.To = this.canvas.ActualHeight;
            fallAnimation.Duration = TimeSpan.FromSeconds(secondsToFall);
            Storyboard.SetTarget(fallAnimation, bomb);
            Storyboard.SetTargetProperty(fallAnimation, new PropertyPath("(Canvas.Top)"));      //注意附加属性的写法

            //创建故事板，存放左右摇摆动画和下落动画，并设置动画总时长及动画结束处理
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(wiggleAnimation);
            storyboard.Children.Add(fallAnimation);
            storyboard.Duration = fallAnimation.Duration;
            storyboard.Completed += Storyboard_Completed;       //该事件的定义必须在Begin()方法之前
            storyboard.Begin();

            //将故事板与炸弹添加入字典
            storyboards.Add(bomb, storyboard);

            //添加炸弹点击事件，拦截动画
            bomb.MouseLeftButtonDown += Bomb_MouseLeftButtonDown;

            //每隔一段时间进行调整以增加游戏难度
            if (DateTime.Now.Subtract(lastAdjustmentTime).TotalSeconds > secondBetweenAdjustments)
            {
                lastAdjustmentTime = DateTime.Now;

                secondsBetweenBombs -= secondsBetweenBombsReduction;
                if (secondsBetweenBombs < 1) secondsBetweenBombs = 1;

                secondsToFall -= secondsToFallReduction;
                if (secondsToFall < 1) secondsToFall = 1;

                //重写设置炸弹投掷定时器
                bombTimer.Interval = TimeSpan.FromSeconds(secondsBetweenBombs);

                //更新状态信息
                this.txtblkRate.Text = $"投掷炸弹的时间间隔：{secondsBetweenBombs}秒";
                this.txtblkSpeed.Text = $"炸弹下落的速度：{secondsToFall}秒";
            }
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //元素即使位于Canvas面板的外面，Canvas面板也会绘制其子元素。所以此处限制Canvas面板的绘制区域
            RectangleGeometry rect = new RectangleGeometry();
            rect.Rect = new Rect(0, 0, this.canvas.ActualWidth, this.canvas.ActualHeight);
            this.canvas.Clip = rect;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.btnStart.IsEnabled = false;

            //重置游戏
            droppedCount = 0;
            savedCount = 0;
            secondsBetweenBombs = initialSecondsBetweenBombs;
            secondsToFall = initialSecondsToFail;

            //启动炸弹投掷定时器
            bombTimer.Interval = TimeSpan.FromSeconds(secondsBetweenBombs);
            bombTimer.Start();
        }

        private void Bomb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //获取当前的炸弹对象
            Bomb bomb = (Bomb)sender;
            bomb.IsFalling = false;

            //记录当前位置
            double currentTop = Canvas.GetTop(bomb);
            double currentLeft = Canvas.GetLeft(bomb);

            //根据炸弹对象获取当前的故事板，并停止动画
            Storyboard storyboard = storyboards[bomb];
            storyboard.Stop();
            storyboard.Children.Clear();

            //炸弹移出动画 Y轴
            DoubleAnimation riseAnimation = new DoubleAnimation();
            riseAnimation.From = currentTop;
            riseAnimation.To = 0;
            riseAnimation.Duration = TimeSpan.FromSeconds(1);
            Storyboard.SetTarget(riseAnimation, bomb);
            Storyboard.SetTargetProperty(riseAnimation, new PropertyPath("(Canvas.Top)"));
            //炸弹移出动画 X轴
            DoubleAnimation slideAnimation = new DoubleAnimation();
            if (currentLeft < this.canvas.ActualWidth / 2)
            {
                slideAnimation.To = -100;
            }
            else
            {
                slideAnimation.To = this.canvas.ActualWidth + 100;
            }
            slideAnimation.Duration = TimeSpan.FromSeconds(1);
            Storyboard.SetTarget(slideAnimation, bomb);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("(Canvas.Left)"));

            storyboard.Children.Add(riseAnimation);
            storyboard.Children.Add(slideAnimation);
            storyboard.Duration = slideAnimation.Duration;
            storyboard.Begin();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            ClockGroup clockGroup = (ClockGroup)sender;

            //根据获取到的动画查找对应的Bomb对象
            DoubleAnimation completeAnimation = (DoubleAnimation)clockGroup.Children[1].Timeline;       //下落动画
            Bomb completeBomb = (Bomb)Storyboard.GetTarget(completeAnimation);

            //根据IsFalling属性确定炸弹是被拦截还是被落下
            if (completeBomb.IsFalling)
            {
                droppedCount++;
            }
            else
            {
                savedCount++;
            }

            this.txtblkState.Text = $"拦截的炸弹数：{savedCount}个，投下的炸弹数：{droppedCount}个";

            //当一定数量炸弹落下时结束游戏
            if (droppedCount >= maxDropped)
            {
                bombTimer.Stop();
                this.txtblkState.Text += "\r\n\r\n游戏结束！";
                
                //查找所有正在进行中的动画
                foreach (KeyValuePair<Bomb, Storyboard> item in storyboards)
                {
                    Storyboard storyboard = item.Value;
                    Bomb bomb = item.Key;

                    storyboard.Stop();
                    this.canvas.Children.Remove(bomb);

                    //清空故事板
                    storyboard.Children.Clear();
                    //激活开始按钮
                    this.btnStart.IsEnabled = true;
                }
            }
            else
            {
                //清理当前执行故事板的这颗炸弹，游戏继续
                Storyboard storyboard = (Storyboard)clockGroup.Timeline;
                storyboard.Stop();

                storyboards.Remove(completeBomb);
                this.canvas.Children.Remove(completeBomb);
            }
        }
    }
}

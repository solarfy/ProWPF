using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// AnimationEasing.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationEasing : Window
    {
        public AnimationEasing()
        {
            InitializeComponent();
        }        
    }

    /// <summary>
    /// 以一定的随机量偏移规范化的时间值
    /// </summary>
    class RandomJitterEase : EasingFunctionBase
    {
        public static readonly DependencyProperty JitterPropert = DependencyProperty.Register
        (
            "Jitter",
            typeof(int),
            typeof(RandomJitterEase),
            new UIPropertyMetadata(1000),
            new ValidateValueCallback(ValidateJitter)
        );

        //该属性接受0-2000之间的值
        public int Jitter
        {
            set => SetValue(JitterPropert, value);
            get => (int)GetValue(JitterPropert);
        }

        private static bool ValidateJitter(object value)
        {
            int jitterValue = (int)value;
            return jitterValue <= 2000 && jitterValue >= 0;
        }

        private Random rand = new Random();

        /// <summary>
        /// 提供一个缓动动画实例
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new RandomJitterEase();
        }

        /// <summary>
        /// 采用规范化的时间值，并以某种方式对其进行调整。注：EaseInCore()方法中只实现EaseIn模式下的缓动。其它模式下由WPF自动计算获得
        /// </summary>
        /// <param name="normalizedTime">规范化的时间值[0,1]</param>
        /// <returns>调整后的值。
        /// return 0，动画被返回起始点，
        /// return 1，动画被返回至结束点，
        /// return 1.5，动画过渡运行自身的50%，依次类推
        /// return normalizedTime则对动画不进行缓动
        /// return Math.Pow(normalizedTime, 3)  实现CubicEase函数的效果
        /// </returns>
        protected override double EaseInCore(double normalizedTime)
        {
            //确保jitter不是最终的时间值
            if (normalizedTime == 1) return 1;

            //按随机量偏移该值
            return Math.Abs(normalizedTime - (double)rand.Next(0, 10) / (2010 - Jitter));
        }
    }
}

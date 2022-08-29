using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// AdvancedAnimation.xaml 的交互逻辑
    /// </summary>
    public partial class AdvancedAnimation : Window
    {
        public AdvancedAnimation()
        {
            InitializeComponent();
        }      
           
        //动画结束后隐藏“遮挡物”和Visual画刷；动画开始时显示“遮挡物”和Visual画刷。
        private void SlideVisual_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            Clock clock = (Clock)sender;

            if (clock.CurrentProgress.Value == 0)       //0% 动画开始
            {
                this.rectVisual.Visibility = Visibility.Visible;
                this.rectBlocked.Visibility = Visibility.Visible;
            }
            else if (clock.CurrentProgress.Value == 1)      //100% 动画结束
            {
                this.rectVisual.Visibility = Visibility.Hidden;
                this.rectBlocked.Visibility = Visibility.Hidden;
            }
        }
    }
}

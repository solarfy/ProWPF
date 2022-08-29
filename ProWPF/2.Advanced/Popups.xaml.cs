using System.Windows;
using System.Windows.Input;

namespace ProWPF.Advanced
{
    /// <summary>
    /// Popups.xaml 的交互逻辑
    /// </summary>
    public partial class Popups : Window
    {
        public Popups()
        {
            InitializeComponent();
        }

        private void OpenPopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.popup.IsOpen = true;
        }

        private void OpenNonePopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.popupNone.IsOpen = true;
        }

        private void OpenFadePopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.popupFade.IsOpen = true;
        }

        private void OpenScrollPopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.popupScroll.IsOpen = true;
        }

        private void OpenSlidePopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.popupSlide.IsOpen = true;
        }
    }
}
/* 在程序集间共享资源：
 * 1.定义程序集中类的引用  如：public class CustomResources{ ... }
 * 2.添加描述性的资源ID 如：x:Key="{ComponentResourceKey TypeInTargetAssembly={x:Type local:CustomResources}, ResourcesId=SadTileBrush}"
 * 3.在应用程序集中定义对外部程序集的前缀 如：x:res="clr-namespace:Pro_WPF_Framework;assembly=Pro_WPF_Framework"
 * 4.使用动态资源引用外部程序集资源 如：Background="{DynamicResource {ComponentResourceKey TypeInTargetAssembly={x:Type res:CustomResources}, ResourceId=SadTileBrush}}" 
 */ 

using System.Windows;
using System.Windows.Media;

namespace ProWPF.Advanced
{
    /// <summary>
    /// ObjectResource.xaml 的交互逻辑
    /// </summary>
    public partial class ObjectResource : Window
    {
        private ImageBrush initalBrush;

        public ObjectResource()
        {
            InitializeComponent();

            initalBrush = ((ImageBrush)this.Resources["TileBrush"]).Clone();        //克隆TileBrush
        }

        private void ChangeBrush_Click(object sender, RoutedEventArgs e)
        {
            var currentBrush = this.TryFindResource("TileBrush");       //若没找到资源将会返回null

            if (currentBrush is ImageBrush brush)
            {
                Rect rect = new Rect(0, 0, 5, 5);
                brush.Viewport = brush.Viewport == rect ? initalBrush.Viewport : rect;
            }
        }

        private void ReplaceBrush_Click(object sender, RoutedEventArgs e)
        {
            var currentBrush = this.FindResource("TileBrush");      //若没找到资源将会抛出异常

            if (currentBrush is ImageBrush)
            {
                this.Resources["TileBrush"] = new SolidColorBrush(Colors.LightBlue);
            }
            else if (currentBrush is SolidColorBrush)
            {
                this.Resources["TileBrush"] = initalBrush;
            }
        }

        private void ChangeUnsharedBrush_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = (SolidColorBrush)this.Resources["UnsharedBrush"];
            brush.Color = Colors.Blue;            
        }
    }
}

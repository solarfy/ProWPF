using System.Windows;
using System.Windows.Input;

namespace ProWPF.Advanced
{
    /// <summary>
    /// CustomCursor.xaml 的交互逻辑
    /// </summary>
    public partial class MouseCursor : Window
    {
        public MouseCursor()
        {
            InitializeComponent();

            //使用该属性覆盖每个元素的Cursor属性
            //Mouse.OverrideCursor = Cursors.Arrow;

            //使用自定义的光标 项目中添加cursor.ani文件，Build Aciton设置为Resource
            //Cursor customCursor = new Cursor(System.IO.Path.Combine(applicationDir, "cursor.ani"));
            //this.Cursor = customCursor;

            //System.Windows.Resources.StreamResourceInfo sri = Application.GetResourceStream(new Uri("cursor.ani", UriKind.Relative));
            //Cursor customCursor = new Cursor(sri.Stream);
            //this.Cursor = customCursor;
        }

        private void ChkCustom_Checked(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;    //设置全局光标
        }

        private void ChkCustom_Unchecked(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = null;    //取消全局光标
        }
    }
}

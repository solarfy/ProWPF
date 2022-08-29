using System.Windows;

namespace ProWPF.Advanced
{
    /// <summary>
    /// TextText.xaml 的交互逻辑
    /// </summary>
    public partial class TextText : Window
    {
        /* FontSize:48 * 3/4 = 实际字号:36  
         * 针对字体尺寸小于15个点，文本会变得模糊。通过设置TextOptions.TextFormattingMode = Display（默认为Ideal）属性。大字体则不建议使用该GDI风格的文本渲染。
         * 
         * System.Windows.Media.Fonts.SystemFontFamilies; 获得当前计算机中所安装的字体列表。
         * xmlns:media="clr-namespace:System.Windows.Media;assembly=PresentationCore"
         * FontFamily对象还允许检查其他细节，如行间距和关联的字体。
         * 
         * 嵌入字体：向应用程序添加字体文件（通常是具有.ttf扩展名的文件），并将BuildAction设置为Resource；
         * FontFamily="./字体文件名称（xxx.ttf）" 或者  FontFamily="./#字体名称"   ./表示为当前文件夹。
         * 更普遍的做法是把应用程序编译为.NET程序集，使用特定的URI语法引用编译过的资源  pack://application:,,,/Class/font.xaml
         * 
         */

        public TextText()
        {
            InitializeComponent();
        }
    }
}

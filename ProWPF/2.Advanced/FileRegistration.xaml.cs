/* 使用指定应用程序打开文件：
* 1.右击该文件，选择Open With | Choose Default Program菜单项。
* 2.OpenWith对话框中单击Browse按钮，找到指定的应用程序.exe文件并双击。
* 
* 另一种方法是运行编辑注册表的代码，如该类所示。（使用了Mincrosoft.Win32名称空间中的类注册）
* 注册过程只需执行一次，注册以后只需双击指定的扩展名文件，就会打开指定的.exe应用程序。
* 
* 一般编辑注册表都需要用户提升权限，可通过在项目中添加一个应用程序清单文件（Application Manifest File）改变用户权限。
* 实际使用中可在单独的执行程序中放置需要更高权限的代码，然后在需要时调用这个可执行程序。
*/

using System.Windows;

namespace ProWPF.Advanced
{
    /// <summary>
    /// FileRegistration.xaml 的交互逻辑
    /// </summary>
    public partial class FileRegistration : Window
    {
        public FileRegistration()
        {
            InitializeComponent();
        }

        //使用方法
        private static void Register()
        {
            string extension = ".testDoc";
            string title = nameof(App);     //Application的名称
            string extensionDescription = "一个test文档";
            Tools.FileRegistrationHelper.SetFileAssociation(extension, $"{title}.{extensionDescription}");
        }       
    }
}

using System.Windows;

/* WPF全球化
 * 1.项目本地化：
 *   修改项目的.csproj文件，在第一个<PropertyGroup>元素中的任意地方添加以下元素
 *   <UICulture>zh-CN</UICulture> zh表示语言，CN表示地区/国家
 * 
 * 2.对需要本地化的元素添加Uid特性：
 *   可使用MSBuid工具完成一系列操作，工具 -> 命令行
 *   msbuild /t:updateuid "Pro WPF.csproj"          对所有窗口，所有元素进行添加Uid特性（此处Pro WPF项目名称中具有空格，所以用“”进行包装）
 *   msbuild /t:checkuid "Pro WPF.csproj"           检查所有元素是否都具有唯一的Uid
 *   msbuild /t:removeuid "Pro WPF.csproj"          移除所有的Uid
 *   
 * 3.提取可被本地化的内容：
 *   完成上述步骤后重新生成项目，使用LocBaml命令行工具，将该工具拷贝至编译过的程序集文件夹中（..\bin\Debug）,或者运行时指定locbaml.exe路径
 *   locbaml.exe verbose        查看相关指令
 *   locBaml.exe /parse "zh-CN/WPF Pro.resources.dll" /out:"zh-CN/zh-CN.csv"      提取本地化细节的列表
 * 
 * 4.生成附属程序集
 *   对zh-CN.csv最后一列进行翻译，并生成新的en-US.csv文件，再次使用locbaml工具
 *   locbaml.exe /generate "zh-CN/WPF Pro.resources.dll" /trans:en-US.csv /out:en-US /cul:en-US     使用翻译过的.csv文件生成新的附属程序集，并输入到en-US文件夹，并提供en-US文化
 *   
 * 5.使用
 *   使用控制面板的区域和语言改变文件；或者在创建或显示任意窗口之前进行如下操作
 *   Thread.CurretnThread.CurrentUICulture = new CultureInfo("en-US")
 *   
 */

namespace ProWPF.Advanced
{
    /// <summary>
    /// Localization.xaml 的交互逻辑
    /// </summary>
    public partial class WPFGlobalization : Window
    {
        public WPFGlobalization()
        {
            InitializeComponent();
        }
    }
}

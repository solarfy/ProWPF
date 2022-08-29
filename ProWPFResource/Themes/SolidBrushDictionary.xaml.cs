/* 为字典资源创建隐藏类。可直接实例化该类，而不使用ResourceDictionary.Source属性
 * 
 * 1..cs文件部分需继承ResourceDictionary，并且在构造函数中调用InitializeComponent()方法
 * 2..xaml部分添加x:Class="ProWPFResource.Themes.SolidBrushDictionary"
 * 3.如果想要将.cs文件嵌套入.xaml文件。可在文本编辑器中修改.csproj项目文件，在<ItemGroup>部分，找到隐藏文件
 *              <Compile Include="Themes\SolidBrushDictionary.xaml.cs">
 *              修改为：
 *              <Compile Include="Themes\SolidBrushDictionary.xaml.cs">
 *                  <DependentUpon>Themes\SolidBrushDictionary.xaml</DependentUpon>
 *              </Compile>
 * 4.使用方法
 *  this.Resources.MergedDictionaries[0] = new SolidBrushDictionary();
 */

using System.Windows;

namespace ProWPFResource.Themes
{
    /// <summary>
    /// SolidBrushDictionary.xaml 的交互逻辑
    /// </summary>
    public partial class SolidBrushDictionary : ResourceDictionary
    {
        public SolidBrushDictionary()
        {
            InitializeComponent();
        }
    }
}

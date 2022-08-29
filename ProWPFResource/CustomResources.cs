/* 使用ComponentResourceKey时，需要提供两部分信息：
 * 1.类库程序集中类的引用
 * 2.描述性的资源ID
 * 
 * x:Key="{ComponentResourceKey TypeInTargetAssembly={x:Type local:CustomResources}, ResourcesId=SadTileBrush}"
 */

using System.Windows;

namespace ProWPFResource
{
    public class CustomResources
    {
        public static ComponentResourceKey SadTileBrushKey
        {
            get => new ComponentResourceKey(typeof(CustomResources), "SadTileBrush");
        }
    }
}

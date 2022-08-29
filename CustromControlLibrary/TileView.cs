/* 自定义视图类
 * 该类必须继承自ViewBase类，通常会（不一定）重写DefaultStyleKey和ItemContainerDefaultStyleKey属性
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControlLibrary
{
    public class TileView : ViewBase
    {
        private DataTemplate itemTemplate;

        public DataTemplate ItemTemplate
        {
            get { return itemTemplate; }
            set { itemTemplate = value; }
        }

        private Brush selectedBackground = Brushes.Transparent;

        public Brush SelectedBackground
        {
            get { return selectedBackground; }
            set { selectedBackground = value; }
        }

        private Brush selectedBorderBrushe = Brushes.Black;

        public Brush SelectedBorderBrush
        {
            get { return selectedBorderBrushe; }
            set { selectedBorderBrushe = value; }
        }

        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileView"); }     //ComponentResourceKey从DLL程序集中检索共享资源
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileViewItem"); }
        }
    }
}

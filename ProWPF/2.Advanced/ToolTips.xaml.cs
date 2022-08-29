using System.Windows;
using System.Windows.Controls.Primitives;

namespace ProWPF.Advanced
{
    /// <summary>
    /// ToolTips.xaml 的交互逻辑
    /// </summary>
    public partial class ToolTips : Window
    {
        public ToolTips()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 自定义弹窗位置
        /// </summary>
        /// <param name="popupSize">ToolTip的大小</param>
        /// <param name="targetSize">PlacementTarget的大小</param>
        /// <param name="offset">HorizontalOffset和VerticalOffset创建的一个点</param>
        /// <returns></returns>
        private CustomPopupPlacement[] CustomPlacement(Size popupSize, Size targetSize, Point offset)
        {
            CustomPopupPlacement placement1 = new CustomPopupPlacement(new Point(-50, 100), PopupPrimaryAxis.Vertical);

            CustomPopupPlacement placement2 = new CustomPopupPlacement(new Point(10, 20), PopupPrimaryAxis.Horizontal);

            CustomPopupPlacement[] ttplaces = new CustomPopupPlacement[] { placement1, placement2 };

            return ttplaces;
        }
    }
}

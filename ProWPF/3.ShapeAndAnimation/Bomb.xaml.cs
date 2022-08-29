using System.Windows.Controls;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// Bomb.xaml 的交互逻辑
    /// </summary>
    public partial class Bomb : UserControl
    {
        public Bomb()
        {
            InitializeComponent();
        }

        public bool IsFalling { get; set; }
    }
}

using System.Windows;
using System.Windows.Input;

namespace ProWPF.Basic
{
    /// <summary>
    /// RoutingStrategy.xaml 的交互逻辑
    /// </summary>
    public partial class RoutingStrategy : Window
    {
        private int eventCounter, prvEventCounter;

        public RoutingStrategy()
        {
            InitializeComponent();

            //通过AddHandler的重载版本第三个参数设置为true，可处理挂起的事件（Handled=true）
            //this.btnClear.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(Something_MouseUp), true);

            //只能通过AddHandler的方式添加附加事件
            //this.AddHandler(System.Windows.Controls.Button.ClickEvent, new RoutedEventHandler(CmdClear_Click));   //此处为btnClear添加Click事件            
        }

        private void Something_MouseUp(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;

            string message = $"#{eventCounter}:\r\nSender: {sender}\r\nSource: {e.Source}\r\nOriginal Source: {e.OriginalSource}";
            this.lstMessages.Items.Add(message);

            e.Handled = (bool)this.chkHandle.IsChecked;     //Handled为true，终结事件冒泡传递
        }

        //按钮的会挂起MouseUp事件，从而引发更高级的Click事件，所以点击按钮后不会引起Something_MouseUp的处理
        private void CmdClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            this.lstMessages.Items.Clear();
        }

        private void Something_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            prvEventCounter++;

            string message = $"#{prvEventCounter}:\r\nSender: {sender}\r\nSource: {e.Source}\r\nOriginal Source: {e.OriginalSource}";
            this.lstPrvMessages.Items.Add(message);

            e.Handled = (bool)this.chkPrvHandle.IsChecked;     //隧道事件Handled设为true，会同时终结隧道事件链和冒泡事件链，因为这两个事件都共享RoutedEventArg类的同一个实例
            //此处this.chkPrvHandle.IsChecked 选中后将无法取消
        }

        private void PrvCmdClear_Click(object sender, RoutedEventArgs e)
        {
            prvEventCounter = 0;
            this.lstPrvMessages.Items.Clear();
        }
    }
}

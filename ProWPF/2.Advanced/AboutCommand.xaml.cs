using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProWPF.Advanced
{
    /// <summary>
    /// AboutCommand.xaml 的交互逻辑
    /// </summary>
    public partial class AboutCommand : Window
    {
        public AboutCommand()
        {
            InitializeComponent();
        }

        private void CreateCommandByCode()
        {
            //1.创建一个命令绑定
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            //2.附加事件处理程序
            binding.Executed += NewCommand_Executed;    //冒泡路由
            //binding.PreviewExecuted += NewCommand_Executed;   //隧道路由，首先在最高层次的容器中引发事件，然后隧道至目标元素；RoutedEventHandled设为True，将不会引发Executed事件
            //3.注册命令
            this.CommandBindings.Add(binding);
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"New command triggered by {e.Source.ToString()}, commmand parameter: {e.Parameter.ToString()}");
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            //this.CommandBindings[0].Command.Execute(null);    //不需要使用目标元素，会自动将公开自动使用的CommandBindings集合的元素设置为目标元素
            //或
            ApplicationCommands.New.Execute("手动触发命令", sender as Button);
        }

        private void UpdateCanExecute_Click(object sender, RoutedEventArgs e)
        {
            //调用该方法，使其触发RequerySuggested事件，然后通知窗口中的命令源，此后命令源会重新查询它们链接的命令并相应的更新它们的状态
            CommandManager.InvalidateRequerySuggested();
        }
    }
}

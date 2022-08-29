using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProWPF.Advanced
{
    /// <summary>
    /// CommandHistory.xaml 的交互逻辑
    /// </summary>
    public partial class CommandHistory : Window
    {
        //自定义一个撤销命令
        private static RoutedUICommand applicationUndo;
        public static RoutedUICommand ApplicationUndo
        {
            get => applicationUndo ?? (applicationUndo = new RoutedUICommand("自定义撤销", "ApplicationUndo", typeof(CommandHistory)));
        }

        //历史命令
        public ObservableCollection<CommandHistoryItem> CommandCollection { get; private set; } = new ObservableCollection<CommandHistoryItem>() { };
        
        public CommandHistory()
        {
            InitializeComponent();

            //使用AddHandler：CommandManager类挂起了Executed事件，所以使用UIElement.AddHandler()方法关联事件处理程序
            //使用PreviewExecutedEvent：Executed事件是在命令执行完后被触发的，这是已来不及在命令历史中保存被影响的控件的状态了，所以使用PreveiwExecutedEvent
            //参数True：即使事件已经被处理（Handled=true），仍可接收到该事件
            this.AddHandler(CommandManager.PreviewExecutedEvent, new ExecutedRoutedEventHandler(CommandExecuted), true);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            this.RemoveHandler(CommandManager.PreviewExecutedEvent, new ExecutedRoutedEventHandler(CommandExecuted));
        }

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //当单价工具栏上的按钮时，CommandExecuted事件将被引发两次，一次针对工具栏按钮，一次是针对文本框
            //忽略工具栏按钮（实现了ICommandSource接口的控件：ButtonBase，ListBoxItem，Hyperlink，MenuItem）
            if (e.Source is ICommandSource) return;

            //忽略掉自定义的撤销命令
            if (e.Command == CommandHistory.ApplicationUndo) return;

            if (e.Source is TextBox text)
            {
                RoutedCommand command = (RoutedCommand)e.Command;
                CommandHistoryItem item = new CommandHistoryItem(command.Name, text, nameof(TextBox.Text), text.Text);
                CommandCollection.Add(item);  
            }
        }

        private void ApplicationUndo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CommandHistoryItem item = CommandCollection[CommandCollection.Count - 1];
            
            if (item.CanUndo)
            {
                item.Undo();
            }

            CommandCollection.Remove(item);
        }

        private void ApplicationUndo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CommandCollection == null || CommandCollection.Count == 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
    }

    public class CommandHistoryItem
    {
        //命令名称
        public string CommandName { get; set; }

        //执行命令的元素
        public UIElement ElementActedOn { get; set; }

        //目标元素被改变的属性
        public string PropertyActedOn { get; set; }

        //保存受影响元素以前状态的对象
        public object PreviousState { get; set; }

        public CommandHistoryItem(string commandName, UIElement elementActedOn, string propertyActedOn, object preivousState)
        {
            CommandName = commandName;
            ElementActedOn = elementActedOn;
            PropertyActedOn = propertyActedOn;
            PreviousState = preivousState;
        }

        public CommandHistoryItem(string commandName) 
            : this(commandName, null, string.Empty, null)
        { }

        public bool CanUndo
        {
            get => (ElementActedOn != null) && (!string.IsNullOrEmpty(PropertyActedOn));
        }

        //利用反射将修改过的属性应用以前的值
        public void Undo()
        {
            Type elementType = ElementActedOn.GetType();
            PropertyInfo property = elementType.GetProperty(PropertyActedOn);
            property.SetValue(ElementActedOn, PreviousState);
        }
    }
}

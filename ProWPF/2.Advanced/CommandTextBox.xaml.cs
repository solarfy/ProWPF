using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProWPF.Advanced
{
    /// <summary>
    /// CommandTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class CommandTextBox : Window
    {
        private static RoutedUICommand printTextCommand;
        public static RoutedUICommand PrintTextCommand { get => printTextCommand ?? (printTextCommand = new RoutedUICommand("显示文本", nameof(PrintTextCommand), typeof(CommandTextBox))); }

        public CommandTextBox()
        {
            InitializeComponent();
        }

        private void PrintTextCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source is TextBox tb)
            {
                this.text.Text = e.Parameter.ToString() + tb.Text;
                this.numberText.Text = tb.Text.Length.ToString();
            }
        }

        private void PrintTextCommand_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((TextBox)e.Source).Text.Length <= 30;                        
        }
       
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.cmdText.Text = this.text.Text = string.Empty;
            this.numberText.Text = "0";
        }
    }

    /// <summary>
    /// 实例了ICommandSource的TextBox，可对其进行命令链接
    /// </summary>
    public class CmdTextBox : TextBox, ICommandSource
    {                
        public static DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(CmdTextBox)
            , new PropertyMetadata((ICommand)null, new PropertyChangedCallback(CommandChanged)));

        public static DependencyProperty CommmandParameterPropety = DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(CmdTextBox)
            , new PropertyMetadata((object)null));
     
        public static DependencyProperty CommandTargetProperty = DependencyProperty.Register(nameof(CommandTarget), typeof(IInputElement), typeof(CmdTextBox)
            , new PropertyMetadata((IInputElement)null));

        private static void CommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CmdTextBox ctb = (CmdTextBox)d;
            ctb.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        //ICommandSource 接口成员，定义成依赖属性，使其能够进行数据绑定
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        //ICommandSource 接口成员，定义成依赖属性，使其能够进行数据绑定
        public object CommandParameter
        {
            get
            {
                return GetValue(CommmandParameterPropety);
            }
            set
            {
                SetValue(CommmandParameterPropety, value);
            }
        }

        //ICommandSource 接口成员，定义成依赖属性，使其能够进行数据绑定
        public IInputElement CommandTarget
        {
            get
            {
                return (IInputElement)GetValue(CommandTargetProperty);
            }
            set
            {
                SetValue(CommandTargetProperty, value);
            }
        }

        public CmdTextBox()
            : base()
        {
            CommandTarget = this;   //默认执行命令的目标是自身
        }

        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
            {
                RemoveCommand(oldCommand);
            }
            AddCommand(newCommand);
        }

        private void RemoveCommand(ICommand command)
        {
            command.CanExecuteChanged -= CanExecutedChanged;
        }

        private void AddCommand(ICommand command)
        {
            if (command != null)
            {
                command.CanExecuteChanged += CanExecutedChanged;
            }
        }

        private void CanExecutedChanged(object sender, EventArgs e)
        {
            if (this.Command != null)
            {
                if (this.Command is RoutedCommand routed)
                {
                    this.IsEnabled = routed.CanExecute(CommandParameter, CommandTarget);
                }
                else
                {
                    this.IsEnabled = ((ICommand)this.Command).CanExecute(CommandTarget);
                }
            }
        }

        //如果文本发生了变化将会调用命令
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Command != null)
            {
                if (this.Command is RoutedCommand cmd)
                {
                    cmd.Execute(CommandParameter, CommandTarget);
                }
                else
                {
                    ((ICommand)this.Command).Execute(CommandParameter);
                }
            }
        }

    }
}

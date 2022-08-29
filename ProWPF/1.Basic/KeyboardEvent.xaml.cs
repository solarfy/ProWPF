using System;
using System.Windows;
using System.Windows.Input;

namespace ProWPF.Basic
{
    /// <summary>
    /// KeyboardEvent.xaml 的交互逻辑
    /// </summary>
    public partial class KeyboardEvent : Window
    {
        public KeyboardEvent()
        {
            InitializeComponent();
        }
        
        private void KeyEvent(object sender, KeyEventArgs e)
        {            
            if ((bool)this.chkIgnoreRepeat.IsChecked && e.IsRepeat)     //忽视重复的键
                return;

            //检查修饰键（Shift、Ctrl、Alt等）; 使用位逻辑判断修饰键中是否含有Ctrl键
            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Console.WriteLine("You held the Control key.");
            }

            //检查CapsLock是否处于“打开”状态
            if (e.KeyboardDevice.IsKeyToggled(Key.CapsLock))
            {
                Console.WriteLine("CapsLock is held down.");
            }

            //除了使用KeyEentArgs，还可以使用Keybord获取键盘信息
            if (Keyboard.IsKeyToggled(Key.NumLock))
            {
                Console.WriteLine("NumLock is held down.");
            }

            string message = $"Event: {e.RoutedEvent}  Key: {e.Key}";
            this.lstMessages.Items.Add(message);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            this.lstMessages.Items.Clear();
        }

        /* 注：此处这里不会触发TextbBox的TextInput事件，因为TextBox控件内部挂起了该事件。
         * 同样TextBox控件还挂起了KeyDown事件，如方向键；对应此类情况，通常使用隧道路由事件（PreviewTextInput和PreviewKeyDown）
         * 只有当字符输入到元素中的时候才会触发PreviewTextInput和TextInput事件
         */
        private void Text_TextInput(object sender, TextCompositionEventArgs e)
        {
            string message = $"Event: {e.RoutedEvent}  Text: {e.Text}";
            this.lstMessages.Items.Add(message);
        }
        
        public void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {            
            string message = $"Event: {e.RoutedEvent}  Text: {e.Text}";
            this.lstMessages.Items.Add(message);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.text.PreviewTextInput += OnlyNumber_PreviewTextInput;
            this.text.PreviewKeyDown += OnlyNumber_PreviewKeyDown;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.text.PreviewTextInput -= OnlyNumber_PreviewTextInput;
            this.text.PreviewKeyDown -= OnlyNumber_PreviewKeyDown;
        }

        /* 通常情况下可在TextBox控件中使用PreviewTextInput事件执行验证工作；
         * 对于一些特殊按键如空格键，可直接绕过PreviewTextInput事件，这意味着还需处理PreviewKeyDown事件。
         * 不能直接判断Key，需要判断Key的值；例如 5和% 都公用了一个Key
        */

        //TextBox会挂起TextInput事件所以使用PreviewTextInput隧道事件。
        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Int16.TryParse(e.Text, out _))     //文本不能转成数据，则挂起后续操作
            {
                e.Handled = true;
            }
        }

        //过滤掉特殊按键（非文本按键）；因为特殊按键不会触发隧道事件PreviewTextInput。
        private void OnlyNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}

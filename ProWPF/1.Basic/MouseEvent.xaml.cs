using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProWPF.Basic
{
    /// <summary>
    /// MouseEvent.xaml 的交互逻辑
    /// </summary>
    public partial class MouseEvent : Window
    {
        /* MouseEnter和MouseLeave属于直接事件，不使用冒泡和隧道过程。
         * 与Keyboard类似通过Mouse类获取鼠标信息。
         * 当鼠标被一个元素捕获时，就不能与其他元素进行交互（例如，不能单击其他的按钮）。鼠标捕获用于短时间的操作，如拖放。
         * UIElement.CaptureMouse() 和 Mouse.Capture(UIElement)捕获鼠标，此后就会接收到鼠标的释放和按下事件。
         * UIElement.ReleaseMouseCapture() 和 Mouse.Capture(Null) 释放捕获的鼠标。
         * IsMouseOver:鼠标是否位于某个元素及其子元素上面；IsMouseDirectlyOver:鼠标是否位于某个元素上面，但不位于其子元素上面。
         */ 

        public MouseEvent()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            this.text.Text = $"（{position.X}，{position.Y}）";
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (TextBox)sender;            
            DragDrop.DoDragDrop(tb, tb.Text, DragDropEffects.Copy);     //源，内容，拖拽效果
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;
            DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);    //源，内容，拖拽效果
        }


        /* 将元素的AllowDrop属性设置为True时，就将元素配置为允许任何类型的信息；
         * 可通过DragEnter事件，有选择的接收内容。
         */ 
        private void LabelTarget_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))    //检查数据格式是否可用，或者是否可以转换成指定格式；数据格式由字符串决定。这里检查是否是文本类型
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void LabelTarget_Drop(object sender, DragEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Content = e.Data.GetData(DataFormats.Text);     //以指定格式转换数据对象
        }
    }
}

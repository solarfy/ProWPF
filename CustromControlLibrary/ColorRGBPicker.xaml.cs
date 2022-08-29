/* 属性封装器不能包含任何逻辑，因为使用DependencyObject基类的SetValue()和GetValue()方法设置和检索属性，当属性变化时通过属性封装器SetValue()方法引发回调函数。
 * WPF不允许重新进入属性变化回调函数。例如，如果改变Color属性，就会触发OnColorChanged()方法。OnColorChanged()方法会修改Red、Green以及Blue属性，
 * 从而触发OnColorChanged()回调方法三次（每个属性触发一次）。然而，OnColorRGBChanged()方法不会再次触发OnColorChanged()方法。
 * 
 * 两个有用的委托RoutedEventHandler(用于不带有额外信息的路由事件)和RoutedPropertyChangedEventHandler(用于提供属性发生变化之后的旧值和新值的路由事件)
 * 本例中使用RoutePropertyChangedEventHandler<Color>委托，是被类型参数化了的泛型委托。所以可为任何属性数据类型使用该委托，而不会牺牲类型安全功能。
 * 无论何时修改Color属性，或者通过Red、Green、Blue都会触发OnColorChanged()回调函数。
 * 
 * 为避免在用户控件的标记中命名用户控件，尽量使用Bind.RelativeSource属性查找元素
 * 
 * 两种方式添加命令支持
 * 1.添加将控件链接到特定命令的绑定。通过这种方法，控件可以响应命令，而且不需要借助于任何外部代码。
 * 2.为命令创建新的RoutedUICommand对象，作为自定义控件的静态字段。然后为这个命令对象添加命令绑定。这种方式可使自定义控件自动支持没有在基本命令集合中定义的命令。
 * 这里采用的第一种方式，将Application.Commands.Undo命令（Ctrl+Z）绑定到控件，并且使用静态构造函数。
 * 如果使用非静态方法，这使得命令比较脆弱，用户可自由地修改CommandBindings集合。
 * 此外这种技术不局限于命令，如果希望将事件处理逻辑硬编码到自定义控件，可通过EventManager.RegisterClassHandler()方法使用事件处理程序。
 * 类事件处理程序总在实例事件处理程序之前调用，从而允许开发人员很容易的抑制事件。
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControlLibrary
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorRGBPicker : UserControl
    {
        #region Static

        public static readonly DependencyProperty ColorProperty;
        public static readonly DependencyProperty RedProperty;
        public static readonly DependencyProperty GreenProperty;
        public static readonly DependencyProperty BlueProperty;

        public static readonly RoutedEvent ColorChangedEvent;

        static ColorRGBPicker()
        {
            //注册依赖属性
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorRGBPicker), new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorRGBPicker), new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorRGBPicker), new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorRGBPicker), new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            //注册路由事件
            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorRGBPicker));

            //注册命令
            CommandBinding binding = new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed, UndoCommand_CanExecuted);
            CommandManager.RegisterClassCommandBinding(typeof(ColorRGBPicker), binding);
        }

        //Color属性变化时引起Red、Green、Blue属性变化，并引发ColorChangedEvent事件
        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;

            ColorRGBPicker colorPicker = (ColorRGBPicker)sender;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;

            colorPicker.previousColor = oldColor;

            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldColor, newColor);
            args.RoutedEvent = ColorChangedEvent;
            colorPicker.RaiseEvent(args);
        }

        //当Red、Green、Blue属性变化时引发Color属性变化
        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {            
            ColorRGBPicker colorPicker = (ColorRGBPicker)sender;
            Color color = colorPicker.Color;

            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        private static void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ColorRGBPicker colorPicker = (ColorRGBPicker)sender;
            colorPicker.Color = (Color)colorPicker.previousColor;
        }

        private static void UndoCommand_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            ColorRGBPicker colorPicker = (ColorRGBPicker)sender;
            e.CanExecute = colorPicker.previousColor.HasValue;
        }

        #endregion

        //将字段设置为可空的，因为当第一次创建控件时，还没有设置以前选择的颜色。
        private Color? previousColor;

        public Color Color
        {
            set => SetValue(ColorProperty, value);
            get => (Color)GetValue(ColorProperty);
        }

        public byte Red
        {
            set => SetValue(RedProperty, value);
            get => (byte)GetValue(RedProperty);
        }

        public byte Green
        {
            set => SetValue(GreenProperty, value);
            get => (byte)GetValue(GreenProperty);
        }

        public byte Blue
        {
            set => SetValue(BlueProperty, value);
            get => (byte)GetValue(BlueProperty);
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        public ColorRGBPicker()
        {
            InitializeComponent();

            //安装命令（已通过静态构造函数安装）
            //CommandBinding binding = new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed, UndoCommand_CanExecuted);
            //this.CommandBindings.Add(binding);
                
        }
    }
}

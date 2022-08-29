/* 创建无外观的控件
* 1.为通知WPF正在提供新的样式，需要在自定义控件类的静态构造函数种调用OverrideMetadata()方法，
*   需要在DefaultStyleKeyProperty属性上调用该方法，该属性是为自定义控件定义默认样式的依赖属性。
*   DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
*   
* 2.创建新样式，在项目文件夹的Themes子文件夹中添加Generic.xaml文件。
*   这一设定是由旧式的WPF功能沿用下来的
*   
* 3.自定义控件样式必须使用TargetType特性将自身自动关联到控件自身（本例中的ColorPicker）
*   <Style TargetType="{x:type local:ColorPicker}"/>
*   
*  注：1.当创建链接到父类控件类属性的绑定表达式时，不能使用ElementName属性。而需要使用RelativeSource属性指示希望绑定到父控件。
*      如果单项绑定能够满足需要，可使用轻量级的TemplateBlinding。
*      Padding={TemplateBlinding Margin} 与 Padding={Blinding RelativeSource={RelativeSource TemplatedParent}, Path=Margin} 相同  RelativeSource将绑定执行模板的父元素
*      
*      2.不能在控件模板中关联事件处理程序。相反，需要为元素提供能够识别的名称，并在控件构造函数中通过代码为它们关联事件处理程序。
*      3.除非希望关联事件处理程序或通过代码与它进行交互，否则不要在控件模板中命名元素。当命名使用元素时，使用“PART_元素名”的形式进行命名。 
*      4.在控件自身的初始化代码中配置所有的绑定，这样模板中就不需要指定这些细节。
* 
*  有时需要代码检索默认样式，为此可使用FindResource()方法。例如：Style sytle = Application.Current.FindResource(typeof(Button));
* 
*/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace CustomControlLibrary
{
    [TemplatePart(Name = "PART_RedSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_GreenSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_BlueSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_AlphaSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_PreviewBrush", Type = typeof(SolidColorBrush))]
    public class ColorPicker : Control
    {
        #region Static

        public static readonly DependencyProperty ColorProperty;
        public static readonly DependencyProperty RedProperty;
        public static readonly DependencyProperty GreenProperty;
        public static readonly DependencyProperty BlueProperty;
        public static readonly DependencyProperty AlphaProperty;

        public static readonly RoutedEvent ColorChangedEvent;

        static ColorPicker()
        {
            //应用控件样式
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));

            //注册依赖属性
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker), new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker), new PropertyMetadata(new PropertyChangedCallback(OnColorRGBAChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker), new PropertyMetadata(new PropertyChangedCallback(OnColorRGBAChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker), new PropertyMetadata(new PropertyChangedCallback(OnColorRGBAChanged)));
            AlphaProperty = DependencyProperty.Register("Alpha", typeof(byte), typeof(ColorPicker), new FrameworkPropertyMetadata((byte)255, new PropertyChangedCallback(OnColorRGBAChanged)));

            //注册路由事件
            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        }

        //Color属性变化时引起Red、Green、Blue、Alpha属性变化，并引发ColorChangedEvent事件
        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;

            ColorPicker colorPicker = (ColorPicker)sender;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;
            colorPicker.Alpha = newColor.A;

            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldColor, newColor);
            args.RoutedEvent = ColorChangedEvent;
            colorPicker.RaiseEvent(args);
        }

        //当Red、Green、Blue、Alpha属性变化时引发Color属性变化
        private static void OnColorRGBAChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;

            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            else if (e.Property == AlphaProperty)
                color.A = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        #endregion

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

        public byte Alpha
        {
            set => SetValue(AlphaProperty, value);
            get => (byte)GetValue(AlphaProperty);
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        //如果需要在模板中查找元素并关联事件处理程序或添加数据绑定表达式，应重写该方法。在该方法中可以使用GetTemplateChild()方法查找所需的元素
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
           
            //这里使用RangeBase类提供了需要的最小功能（本例中Value属性），通过尽可能提高代码的通用性，控件使用者可获得更大的自由
            RangeBase slider = GetTemplateChild("PART_RedSlider") as RangeBase;     
            if (slider != null)
            {
                Binding binding = new Binding("Red");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }

            slider = GetTemplateChild("PART_GreenSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Green");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }

            slider = GetTemplateChild("PART_BlueSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Blue");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }

            slider = GetTemplateChild("PART_AlphaSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Alpha");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }

            SolidColorBrush brush = GetTemplateChild("PART_PreviewBrush") as SolidColorBrush;   //Brush没有绑定，此处使用了逆向绑定，将源设置为brush
            if (brush != null)
            {
                Binding binding = new Binding("Color");
                binding.Source = brush;
                binding.Mode = BindingMode.OneWayToSource;
                this.SetBinding(ColorPicker.ColorProperty, binding);
            }
        }
    }
}

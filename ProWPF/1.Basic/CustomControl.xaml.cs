using System.Windows;
using System.Windows.Documents;

namespace ProWPF.Basic
{
    /// <summary>
    /// CustomControl.xaml 的交互逻辑
    /// </summary>
    public partial class CustomControl : Window
    {
        public CustomControl()
        {
            InitializeComponent();
        }

        /* 只能为DependecyObject 对象添加依赖属性
         * CoerceValueCallback; 该回调函数可将新值修改为更能被接受的值，该函数在ValidateValueCallback之前执行；该函数可访问对象的其他属性。
         * ValidateValueCallback; 该回调函数可接受或拒绝新值；该函数只能访问一个属性。   
         */

        #region 自定义依赖属性
        
        private static FrameworkPropertyMetadata metadata;
      
        //属性封装器
        public string Version
        {
            get { return (string)GetValue(VersionProperty); }
            set { SetValue(VersionProperty, value); }
        }
        
        //依赖属性的定义和注册
        public static readonly DependencyProperty VersionProperty =
            DependencyProperty.Register("Version", typeof(string), typeof(CustomControl), metadata, new ValidateValueCallback(ValidateValue));

        static CustomControl()
        {
            metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CoerceValue);
        }

        //d：设置属性的实际对象   baseValue：传入的新值
        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            CustomControl source = (CustomControl)d;
            string str = baseValue.ToString();

            if (str.Contains("%"))
            {
                return source.Version + str;
            }
            else
            {
                //return DependencyProperty.UnsetValue;   //完全拒绝修改
                return baseValue;
            }
        }

        //value：传入的新值
        private static bool ValidateValue(object value)
        {
            return !string.IsNullOrEmpty(value.ToString());
        }
        #endregion

        #region 自定义附加属性 | 附加属性由其他元素中调用，类似Grid.Row之类的
       
        //Get属性封装器
        public static int GetVersionCode(DependencyObject obj)
        {            
            return (int)obj.GetValue(VersionCodeProperty);
        }

        //Set属性封装器
        public static void SetVersionCode(DependencyObject obj, int value)
        {
            obj.SetValue(VersionCodeProperty, value);
        }
       
        //附加属性的定义和注册
        public static readonly DependencyProperty VersionCodeProperty =
            DependencyProperty.RegisterAttached("VersionCode", typeof(int), typeof(CustomControl), new PropertyMetadata(0));
        #endregion

        #region 共享的依赖属性 | 在类之间共享依赖属性的定义

        //将TextElement.FontFamilyProperty的定义共享到自定义的TypeFaceProperty
        public static readonly DependencyProperty TypeFaceProperty = TextElement.FontFamilyProperty.AddOwner(typeof(CustomControl));
        #endregion

        #region 自定义路由事件

        //路由事件的定义和注册
        public static readonly RoutedEvent ReadEvent =
            EventManager.RegisterRoutedEvent("Read", System.Windows.RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomControl));

        //路由事件的封装
        public event RoutedEventHandler Read
        {
            add { AddHandler(ReadEvent, value); }
            remove { RemoveHandler(ReadEvent, value); }
        }

        //路由事件的引发
        protected virtual void ReadEventOnRaise()
        {
            RoutedEventArgs e = new RoutedEventArgs(ReadEvent, this);
            RaiseEvent(e);
        }

        #endregion

        #region 共享的路由事件 | 在类之间共享路由事件的定义
        //将UIElement.MouseUpEvent的定义共享到自定义的WriteEvent
        public static readonly RoutedEvent WriteEvent = UIElement.MouseUpEvent.AddOwner(typeof(CustomControl));
        #endregion
    }

}

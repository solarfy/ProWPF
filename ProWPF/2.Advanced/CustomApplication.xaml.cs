using System;
using System.Windows;

namespace ProWPF.Advanced
{
    /// <summary>
    /// CustomApplication.xaml 的交互逻辑
    /// </summary>
    public partial class CustomApplication : Window
    {
        public CustomApplication()
        {
            InitializeComponent();
        }

        [STAThread]
        static void MyMain_1()
        {
            //启动画面（应为公共语言运行时，首先需要初始化.NET环境，然后启动应用程序。）
            SplashScreen splashScreen = new SplashScreen("splash_screen.png");
            splashScreen.Show(true);    //设置为false时（WPF不会自动淡入初始界面），需要调用Close()方法隐藏初始界面，并提供TimeSpan值来指示经过多长时间淡出初始界面。


            //创建一个应用程序
            Application app = new Application();

            //创建一个窗体
            MainWindow window = new MainWindow();

            //启动应用程序并显示主窗口
            app.Run(window);        //传递的窗口即为主窗口；Application.Current.MainWindow 访问该窗口

            /* Run()方法结束后，仍可继续运行后续代码
             * 
             */
        }

        [STAThread]
        static void MyMain_2()
        {
            //创建一个应用程序
            Application app = new Application();

            //创建，分配，并显示主窗口
            MainWindow window = new MainWindow();
            app.MainWindow = window;
            window.Show();

            //保持应用程序处于运行状态
            app.Run();

            /* Run()方法结束后，仍可继续运行后续代码
             * 
             */
        }        
    }

    class MyApplication : Application
    {
        /* 处理事件时有两种选择：关联事件处理程序或重写相应的受保护方法。（On前缀）
         * 当重写应用程序方法时，最好首先调用基类的实现。通常基类的实现只是引发相应的应用程序事件。         
         * 
         * 添加启动画面：将图片文件设置为SplashScreen。
         */

        private bool unsavedData = false;

        public bool UnsavedData
        {
            get { return unsavedData; }
            set { unsavedData = value; }
        }


        //Application.Run()方法之后，并且在主窗口显示之前（将主窗口传递给Run()方法）发生。
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UnsavedData = e.Args.Length > 0;    //命令行参数

            //该事件没有相应的受保护的虚方法，所以只能使用关联事件处理
            this.DispatcherUnhandledException += MyApplication_DispatcherUnhandledException;
        }

        //在应用程序（主应用程序线程）中的任何位置，只有发生未处理的异常，就会发生该事件（应用程序调度程序会捕获这些异常）。
        private void MyApplication_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"An unhandled {e.Exception.GetType().ToString()} exception was caught and ignored.");
            e.Handled = true;    //继续运行应用程序            
        }

        //Windows对话结束时发生——例如，当用户注销或关闭计算机时（通过检查SessionEndingCancelEventArgs属性可以确定原因）
        //可将SessionEndingCancelEventArgs.Cancel属性设置为True来取消关闭应用程序。否则当该事件处理结束时，WPF将调用Application.ShotDown()方法。
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);

            if (UnsavedData)
            {
                e.Cancel = true;
                MessageBox.Show($"The application attempted to be closed as a result of {e.ReasonSessionEnding}, This is not allowed, as you have unsaved data.");
            }
        }

        //该事件在应用程序关闭时（不管是什么原因关闭），并在Run()方法即将返回之前发生，此时不能取消关闭，但可以通过代码在Mian()方法中重新启动应用程序。
        //可使用Exit事件设置从Run()方法返回的整数类型的退出代码。
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            e.ApplicationExitCode = 1;      //Run()方法返回值
        }

        //激活应用程序中的窗口时发生该事件。当从另一个Windows程序切换到该应用程序时发生该事件。当第一次显示窗口时也会发生该事件。
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        //当取消激活应用程序中的窗口时发生该事件。当切换到另一个Windows程序时也会发生该事件。
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
        }
    }


}

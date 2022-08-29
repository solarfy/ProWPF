using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.ObjectModel;
using System.Windows;

/* 添加一个应用程序的封装器；
 * 当启动应用程序时，将先创建一个应用程序类（封装器），接着该封装器将创建WPF应用程序类。封装器处理实例管理的问题，WPF应用程序处理真正的应用程序。
 *  
 *          WindowsFormApplicationBase                      |            Application
 *      (位于Microsoft.VisalBasic.ApplicationService)       |        (位于System.Window)
 *                                                          |            
 *              OnStartup()                            ---创建-->      OnStartup()            ---创建-->      Windows ...
 *
 *   
 * 具体步骤：
 * 1.添加Microsoft.VisualBasic.dll程序集的引用。
 * 2.从Microsoft.VisualBasic.ApplicationServices.WindowsFormApplicationBase类继承自定义类。
 * 3.自定义类中创建相应的方法，其中OnStartup()方法中启动WPF的Application应用程序。
 * 4.自定义Main()方法，在Main()中启动自定义类的Application。
 * 
 * Microsoft.VisualBasic.ApplicationServices 命名空间中的类型之前在 .NET Framework 中可用，在.NET 5.0 中暂不可用。
 * 所以此处使用了一个Pro WPF Framework程序集，该程序集采用的是.Net Framework 4.8框架，并引用Microsoft.VisualBasic.dll程序集，并将Microsoft.VisualBasic复制到本地，再添加到本项目中。
 * 
 * 由于本项目中，无法触发OnStartupNextInstance()方法，该问题原因能由.NET框架引起的；所以在Pro WPF Framework Programs 类中实现了该功能。
 * 
 */

namespace ProWPF.Advanced
{
    /// <summary>
    /// SingleApplication.xaml 的交互逻辑
    /// </summary>
    public partial class SingleApplication : Window
    {
        public SingleApplication()
        {
            InitializeComponent();
        }
    }

    public class SingleInstanceApplicationWrapper : WindowsFormsApplicationBase
    {
        //启动一个应用程序
        public Action StartupAction;
        //应用程序已存在，再次启动应用程序
        public Action<ReadOnlyCollection<string>> StartupNextInstanceAction;

        public SingleInstanceApplicationWrapper()
        {
            //设置为单实例模式
            this.IsSingleInstance = true;
        }

        //应用程序启动时发生（Run()）
        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
        {
            StartupAction?.Invoke();
            return false;
        }

        //打开新实例的时候发生
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            eventArgs.BringToForeground = true;     //激活主窗体。否则，主窗体处于当前状态。
            StartupNextInstanceAction?.Invoke(eventArgs.CommandLine);
        }
    }
}

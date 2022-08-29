using Microsoft.VisualBasic.ApplicationServices;
using ProWPF.Advanced;
using System;
using System.Collections.ObjectModel;

namespace ProWPF
{
    /// <summary>
    /// 单实例启动
    /// </summary>
    class Program
    {
        //项目-->属性-->应用程序，将启动对象设置该类名的对象。或可通过直接修改.csproj工程文件
        // 另： /main进行编译是指在CMD命令栏使用csc编译多个含Main()函数的类时来指定包含入口点类型 eg： csc t2.cs t3.cs /main:Test2

        [STAThread]
        public static void Main(string[] args)
        {
            //单实例包装器
            SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper();
            wrapper.StartupAction = new Action(OnStartupAction);
            wrapper.StartupNextInstanceAction = new Action<ReadOnlyCollection<string>>(OnStartupNextInstanceAction);
            //wrapper.StartupNextInstance += new StartupNextInstanceEventHandler(OnStartupNextInstanceEvent);
            wrapper.Run(args);
        }

        private static void OnStartupAction()
        {
            //具体的WPF应用程序
            App wpfApp = new App();
            //MainWindow window = new MainWindow();            
            //wpfApp.Run(window);
            wpfApp.Run();
        }

        //注：.NET Framework可以触发 但在.NET框架下该函数无法触发
        private static void OnStartupNextInstanceAction(ReadOnlyCollection<string> commandLines)
        {
            //命令行参数
            if (commandLines.Count > 0)
            {
                //foreach (DocumentViewer viewer in ((App)System.Windows.Application.Current).Documents)
                //{
                //    viewer.SetContent($"Command arg0: {commandLines[0]}.");
                //}

                foreach (string str in commandLines)
                {
                    Console.WriteLine(str);
                }
            }
        }

        //注：.NET Framework可以触发 但在.NET框架下该函数无法触发
        private static void OnStartupNextInstanceEvent(object sender, StartupNextInstanceEventArgs e)
        {
            OnStartupNextInstanceAction(e.CommandLine);
        }

    }
}

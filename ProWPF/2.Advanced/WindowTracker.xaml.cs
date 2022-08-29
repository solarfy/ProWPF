using System;
using System.IO;
using System.Windows;

namespace ProWPF.Advanced
{
    /// <summary>
    /// WindowTracker.xaml 的交互逻辑
    /// </summary>
    public partial class WindowTracker : Window
    {
        public WindowTracker()
        {
            InitializeComponent();            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DocumentViewer viewer = new DocumentViewer();
            viewer.Owner = this;    //使窗口在创建它们的主窗口上显示
            viewer.Show();

            ((App)Application.Current).Documents.Add(viewer);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            foreach (DocumentViewer viewer in ((App)Application.Current).Documents)
            {
                viewer.SetContent($"Refresh at {DateTime.Now.ToLongTimeString()}.");
            }
        }
    }

    public class DocumentViewer : Window
    {
        public DocumentViewer()
        {
            this.Width = 300;
            this.Height = 200;
            this.Content = "Hello, World!";
            this.MouseLeftButtonDown += DocumentViewer_MouseLeftButtonDown;
        }

        private void DocumentViewer_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        public void SetContent(string content)
        {
            this.Content = content;
        }

        public void LoadFile(string path)
        {
            this.Content = File.ReadAllText(path);
            this.Title = path;
        }
    }
}

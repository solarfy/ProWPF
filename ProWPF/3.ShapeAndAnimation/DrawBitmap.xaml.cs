/* 关于WriteableBitmap类
 * 该类具有两个缓冲区，前缓冲区在系统内存中分配，并包含当前显示的内容。元素呈现时将前缓冲区的内容复制到视频内存以供显示。
 * 后缓冲区也由系统内存分配，累积当前未显示的内容。
 * 
 * 需要频繁更新WirteableBitmap对象中的图像数据，并希望再另一个线程中执行这些更新，可以使用WriteableBitmap后台缓冲区。
 * 一个线程将内容写入后台缓冲区。 另一个线程从前缓冲区读取内容，并将其复制到视频内存中。
 * 基本过程是：
 *           1.使用Lock()方法预定后台缓冲区
 *           2.通过访问属性获取指向后缓冲区的BackBuffer指针 
 *           3.将更改写入后台缓冲区。锁定后缓冲区时WriteableBitmap，其他线程可能会向后缓冲区写入更改
 *           4.调用AddDirtyRect()方法以指示已更改的区域
 *           5.调用UnLock()方法释放后台缓冲区域并允许向屏幕呈现
 *           此过程需要不安全代码（属性--生成中勾选不安全代码）
 */

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// DrawBitmap.xaml 的交互逻辑
    /// </summary>
    public partial class DrawBitmap : Window
    {
        private WriteableBitmap wb;

        public DrawBitmap()
        {
            InitializeComponent();            
        }
 
        private void Image_Initialized(object sender, EventArgs e)
        {
            wb = new WriteableBitmap
           (
               (int)this.img.Width,
               (int)this.img.Height,
               96,
               96,
               PixelFormats.Bgr32,
               null
           );

            this.img.Source = wb;
        }

        private void DrawPixel(MouseEventArgs e)
        {
            int row = (int)e.GetPosition(this.img).Y;
            int column = (int)e.GetPosition(this.img).X;

            try
            {
                //预定后台缓冲区
                wb.Lock();

                unsafe
                {
                    //获取指向后缓冲区的指针
                    IntPtr pBackBuffer = wb.BackBuffer;

                    //找到要更新像素的区域
                    pBackBuffer += row * wb.BackBufferStride;  //跨距，每行像素数据所需的字节数
                    pBackBuffer += column * wb.Format.BitsPerPixel / 8;  //所用格式的每像素的字节数（bits / 8 = byte）

                    //计算像素的颜色
                    int colorData = 255 << 16;  //R
                    colorData |= 128 << 8;      //G
                    colorData |= 255 << 0;      //B

                    //将颜色数据指定给像素
                    *((int*)pBackBuffer) = colorData;
                }

                //更改指定的位图区域
                wb.AddDirtyRect(new Int32Rect(column, row, 1, 1));
            }
            finally
            {
                //释放后台缓冲区
                wb.Unlock();
            }
        }

        private void ErasePixel(MouseEventArgs e)
        {
            byte[] colorData = new byte[] { 0, 0, 0, 0 };   //B G R

            Int32Rect rect = new Int32Rect
            (
                (int)e.GetPosition(this.img).X,
                (int)e.GetPosition(this.img).Y,
                1,
                1
            );

            //每行像素的数量乘上所使用格式的每像素位数，然后将所得的结果除以8，进而将其从位数转换成字节数（1byte = 8bits）
            int stride = wb.PixelWidth * wb.Format.BitsPerPixel / 8;    //跨距，每行像素数据所需的字节数

            wb.WritePixels(rect, colorData, stride, 0);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DrawPixel(e);
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ErasePixel(e);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DrawPixel(e);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                ErasePixel(e);
            }
        }

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Matrix m = this.img.RenderTransform.Value;

            if (e.Delta > 0)
            {
                m.ScaleAt(1.5, 1.5, e.GetPosition(this.img).X, e.GetPosition(this.img).Y);
            }
            else
            {
                m.ScaleAt(1.0 / 1.5, 1.0 / 1.5, e.GetPosition(this.img).X, e.GetPosition(this.img).Y);
            }

            this.img.RenderTransform = new MatrixTransform(m);
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();

            //位图图像的UriSource必须位于BeginInit/EndInit块中
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,,/ProWPFResource;component/Images/blue_hills.jpg", UriKind.Absolute);
            bi.EndInit();

            //this.img.Source = bi; //可直接将Bitmap对象设置为Image.Source属性
            wb = new WriteableBitmap(bi);            
            this.img.Source = wb;
        }
    }
}

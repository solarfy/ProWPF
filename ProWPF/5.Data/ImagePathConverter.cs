/* 要将一块二进制数据转换成一副图像，首先必须创建BitmapImage对象，并将图像数据读入到MemoryStream对象中。
 * 然后调用BitmapImage.BeginInit()方法来设置BitmapImage对象的StreamSource属性，使其指向MemoryStream对象，
 * 并调用EndInit()方法来完成图像的加载。
 * 
 * 当试图为不存在的文件创建BitmapImage对象时，会引发异常；当设置DataContext，ItemSource或Source属性时，将接收该异常。
 * 可添加bool类型的SuppressException属性。如果该属性设置为True就可以在Converter()方法中捕获异常，
 * 然后返回Binding.DoNothing值（这会通知WPF暂时认为没有设置数据绑定）。
 * 或者使用一副默认的图片，DefalultImage。
 */

using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProWPF.Data
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    class ImagePathConverter : IValueConverter
    {
        //图片所在的目录（默认使用应用程序当前的目录）
        public string ImageDirectory { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Images");

        //是否抑制异常
        public bool SuppressException { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            //也可直接返回URI，因为Image元素使用类型转换器将Uri转换为它实际所希望的ImageSource对象。
            //如果采用这种方式，可以在ConverterBack()方法中提取文件名。
            //return new Uri(imagePath);    

            try
            {
                string imagePath = Path.Combine(ImageDirectory, (string)value);
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                return bitmap;
            }
            catch (Exception exc)
            {
                if (SuppressException)
                {
                    return Binding.DoNothing;
                }
                else
                {
                    throw exc;
                }
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

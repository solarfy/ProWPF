using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace ProWPF.Advanced
{
    /// <summary>
    /// AssemblyResources.xaml 的交互逻辑
    /// </summary>
    public partial class AssemblyResource : Window
    {
        public AssemblyResource()
        {
            InitializeComponent();            
        }

        private void SetImageSource()
        {            
            //使用相对URI （当前文件所处的文件夹为2.Advanced与Images平级，所以需用..\返回至上级目录）
            //所谓的相对URI，是相对于当前文件到资源文件的路径
            this.image1.Source = new BitmapImage(new Uri(@"..\Images\happyface.png", UriKind.Relative));      //单斜杠 
            //使用绝对URI（Pack Uri）
            this.image1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/happyface.png"));      //正斜杆
            //使用其他程序集中的资源，绝对URI
            this.image1.Source = new BitmapImage(new Uri("pack://application:,,,/ProWPFResource;component/Images/blue_hills.jpg"));
            //使用其他程序集中的资源，相对URI（当前文件位于2.Advancde文件夹内，向上跳一次到达Pro WPF项目内部，再上跳一次找到与Pro WPF平级的ProWPFResource项目）
            this.image1.Source = new BitmapImage(new Uri("../../ProWPFResource;component/Images/winter.jpg", UriKind.Relative));

            //如果使用强命名的程序集，可使用包含版本和/或公钥标记的限定程序集引用代替程序集的名称，使用分号隔离每段信息，并在版本号数字之前添加字母v
            //使用版本号
            this.image1.Source = new BitmapImage(new Uri("../../ProWPFResource;v1.0.0.0;component/Images/blue_hill.jpg", UriKind.Relative));
            //同时使用版本号和公钥标记
            this.image1.Source = new BitmapImage(new Uri("../../ProWPFResource;v1.0.0.0;dc642a7f5bd64912;component/Images/winter.jpg", UriKind.Relative));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.soundStart.Stop();
            this.soundStart.Play();

            Uri baseUri = new Uri("../", UriKind.Relative);

            this.image1.Source = new BitmapImage(new Uri("pack://application:,,,/ProWPFResource;component/Images/blue_hills.jpg"));
            //注意ProWPFResource项目的引用路径，需上跳两次；ProWPFResource项目与Pro WPF处于同级别，该文件处于Pro WPF 2.Advanced文件夹内
            this.image2.Source = new BitmapImage(new Uri("../../ProWPFResource;component/Images/winter.jpg", UriKind.Relative));     
            this.image3.Source = new BitmapImage(new Uri("pack://application:,,,/Images/happyface.png"));
        }

        private void Ding_Click(object sender, RoutedEventArgs e)
        {
            this.soundDing.Stop();
            this.soundDing.Play();

            this.image1.Source = new BitmapImage(new Uri("../Images/happyface.png", UriKind.Relative));
            this.image2.Source = new BitmapImage(new Uri("pack://application:,,,/Images/happyface.png"));
            this.image3.Source = new BitmapImage(new Uri("../../ProWPFResource;v1.0.0.0;component/Images/winter.jpg", UriKind.Relative));
        }


        //程序集中的所有的资源文件
        public static IEnumerable<string> AssemblyAllResource
        {
            get
            {
                IEnumerable<string> query = from DictionaryEntry item in GetAssemblyAllResources()
                            //where item.Key.ToString().EndsWith(".png")
                            orderby item.Key.ToString() ascending
                            select item.Key.ToString();
                return query;
            }
        }

        //获取资源 命名空间为System.Windows.Resources
        private static StreamResourceInfo GetStreamResourceInfo(string path)
        {
            StreamResourceInfo info = Application.GetResourceStream(new Uri(path, UriKind.Relative));        //注：反斜杠(\\ 或 @ \)和正斜杠(/)都可以
            //StreamResourceInfo.ContentType 返回一个描述数据类型的字符串
            //StreamResourceInfo.Stream 使用该对象读取数据，一次读取一个字节

            return info;
        }

        //不使用GetResourceStream()方法，使用具体访问AssemblyName.g.resources资源流（所有存储WPF资源的地方）
        private static List<DictionaryEntry> GetAssemblyAllResources()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(AssemblyResource));
            string resourceName = assembly.GetName().Name + ".g";
            ResourceManager rm = new ResourceManager(resourceName, assembly);

            List<DictionaryEntry> list = new List<DictionaryEntry>() { };     //DictionaryEntry 字典条目

            using (ResourceSet set = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                //使用单独的资源
                //UnmanagedMemoryStream s;
                //s = (UnmanagedMemoryStream)set.GetObject("Images/happyface.png", true);

                foreach (DictionaryEntry res in set)
                {
                    list.Add(res);
                }
            }

            return list;
        }     
    }
}

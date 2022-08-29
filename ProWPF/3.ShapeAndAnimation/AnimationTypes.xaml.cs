using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Animation;
using System.Threading.Tasks;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// AnimationTypes.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationTypes : Window
    {
        //抽象动画基类
        public List<Type> AnimationBaseTypes { get; set; } = new List<Type>() { };
        //线性插值动画
        public List<Type> AnimationLinearTypes { get; set; } = new List<Type>() { };
        //关键帧动画
        public List<Type> AnimationKeyFramesTypes { get; set; } = new List<Type>() { };
        //路径动画
        public List<Type> AnimationPathTypes { get; set; } = new List<Type>() { };

        public AnimationTypes()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly assembly = typeof(DoubleAnimation).Assembly;
            
            Type[] types = assembly.GetTypes();

            await Task.Run(new Action(() => 
            {
                foreach (Type t in types)
                {
                    if (t.Name.EndsWith("AnimationBase"))
                    {
                        AnimationBaseTypes.Add(t);
                    }
                    else if (t.Name.EndsWith("Animation"))
                    {
                        AnimationLinearTypes.Add(t);
                    }
                    else if (t.Name.EndsWith("AnimationUsingKeyFrames"))
                    {
                        AnimationKeyFramesTypes.Add(t);
                    }
                    else if (t.Name.EndsWith("AnimationUsingPath"))
                    {
                        AnimationPathTypes.Add(t);
                    }
                }
            }));
        }
    }
}

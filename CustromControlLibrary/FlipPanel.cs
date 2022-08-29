/* FlipPanel:为驻留的控件提供两个表面，但每次只有一个表面是可见的。为看到其内容，需要在两个表面之间进行“翻转”。
 * 
 * Normal: 正常状态，确保前面的内容是可见的，后面的内容被翻转、淡化或移出视图。
 * Flipped: 翻转状态，确保后面的内容是可见的，前面的内容通过动画被移出视图。
 * FlipButton: 翻转按钮，单击该按钮，将视图从前面移动到后面（或从后面改到前面）。FlipPanel控件通过处理该按钮的事件提供服务。
 * FlipButtonAlternate: 这是一个可选元素，与FlipButton工作方式相同。允许控件使用者在自定义模板中使用两种不同方法。
 * 
 * 注：1.这里没有使用PART_命名语法，该命名语法是在可视化状态模型之前引入的，使用可视化状态模型该命名已变成了更简单的名称。
 *     2.定义状态组，必须在控件模板的根元素中添加VisualStateManager.VisualStateGroups元素。（为给模板添加VisualStateManager元素，模板必须使用布局面板。
 *       布局面板包含控件的可见对象和不可见VisualStateManager元素，VisualStateManager定义具有动画的故事板，控件在合适的时机使用动画改变其外观）
 *     3.使用动画 必须设置VisualTransition.GeneratedDuration属性以匹配动画的持续时间，如果没有设置该细节，VisualStateManager就不能使用自定义过渡，而且将立即应用新状态。
 *       VisualTransition.GeneratedDuration的实际时间值对于自定义过渡仍无效果，因为它只应用于自动生成的动画。
 *     4.使用VisualStateManager.GoToState()，进行可视化状态切换。当调用该方法时，传递正在改变状态的控件对象的引用、新状态的名称以及确定是否显示过渡动画。
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CustomControlLibrary
{
    [TemplateVisualState(Name = "Normal", GroupName = "ViewState")]
    [TemplateVisualState(Name = "Flipped", GroupName = "ViewState")]
    [TemplatePart(Name = "FlipButton", Type = typeof(ToggleButton))]
    [TemplatePart(Name = "FlipButtonAlternate", Type = typeof(ToggleButton))]
    public class FlipPanel : Control
    {
        public static readonly DependencyProperty FrontContentProperty;
        public static readonly DependencyProperty BackContentProperty;
        public static readonly DependencyProperty IsFlippedProperty;
        public static readonly DependencyProperty CornerRadiusProperty;

        static FlipPanel()
        {
            //通知控件从generic.xaml文件获取样式
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel), new FrameworkPropertyMetadata(typeof(FlipPanel)));

            //注册依赖属性
            FrontContentProperty = DependencyProperty.Register(nameof(FrontContent), typeof(object), typeof(FlipPanel), null);
            BackContentProperty = DependencyProperty.Register(nameof(BackContent), typeof(object), typeof(FlipPanel), null);
            IsFlippedProperty = DependencyProperty.Register(nameof(IsFlipped), typeof(bool), typeof(FlipPanel), null);
            CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FlipPanel), null);
        }

        public object FrontContent
        {
            get => base.GetValue(FrontContentProperty);
            set => base.SetValue(FrontContentProperty, value);
        }

        public object BackContent
        {
            get => base.GetValue(BackContentProperty);
            set => base.SetValue(BackContentProperty, value);
        }

        public bool IsFlipped
        {
            get => (bool)base.GetValue(IsFlippedProperty);
            set
            {
                base.SetValue(IsFlippedProperty, value);
                ChangeVisualState(true);
            }
        }

        //Control没有CornerRadius属性，所有自定义一个
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)base.GetValue(CornerRadiusProperty);
            set => base.SetValue(CornerRadiusProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ToggleButton flipButton = base.GetTemplateChild("FlipButton") as ToggleButton;
            if (flipButton != null) flipButton.Click += FlipButton_Click;

            ToggleButton flipButtonAlternate = base.GetTemplateChild("FlipButtonAlternate") as ToggleButton;
            if (flipButtonAlternate != null) flipButtonAlternate.Click += FlipButton_Click;

            ChangeVisualState(false);
        }

        private void FlipButton_Click(object sender, RoutedEventArgs e)
        {
            IsFlipped = !IsFlipped;
            ChangeVisualState(true);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="useTransition">是否显示过渡效果</param>
        private void ChangeVisualState(bool useTransition)
        {
            if (IsFlipped)
            {
                VisualStateManager.GoToState(this, "Flipped", useTransition);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", useTransition);
            }
        }
    }
}

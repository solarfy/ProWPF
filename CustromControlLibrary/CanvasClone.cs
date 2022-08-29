/* 自定义面板
 * 第一阶段--测量阶段，面板决定子元素希望具有多大的尺寸。
 * 重新MeasureOverride()方法，决定每个子元素希望多大的空间。遍历子元素集合InternalChildren，并调用每个子元素的Measure()方法，
 * 当调用Measure()方法时，传递参数为决定每个子控件最大可用空间的Size对象。
 * 在MeasureOverrid()方法的最后，面板返回显示所有子元素所需的空间，并返回它们所期望的尺寸（DesiredSize）。
 * Measure()方法不返回数值，在为每个子元素调用Measure()方法后，子元素的DesiredSize属性提供了请求的尺寸。
 * 许多元素直到调用Measure()方法后才会渲染它们自身，所以必须为每个子元素调用Measure()方法，即使不希望限制子元素的尺寸或使用DesireSizes属性也同样如此。
 * 如果希望子元素获取它们所希望的全部空间，可用传递两个方向上的值都是Double.PositiveInfinity的Siz对象。然后子元素会返回其中所有内容所需的空间，否则，子元素返回其中内容需要的空间或可用空间中的较小者。
 * 
 * 
 * 第二阶段--排列阶段，为每个控件指定边界。
 * 重新ArrangeOverride()方法，为每个子元素调用Arrange()方法，以告诉子元素为它们分配了多大的空间。
 * 当使用Arrange()方法，传递参数为能够定义子元素尺寸和位置的System.Windows.Rect对象。（就像使用Canvas面板风格的X和Y坐标放置每个元素）
 * 排列元素时不能传递无线尺寸，可通过使用DesiredSize属性的值为元素提供它所期望的数值，也可以为元素提供比所需尺寸更大的空间（如果设置Width和Height，仍然可以扩展该元素）。
 * 当元素比所期望的尺寸更大时，就需要使用HorizontalAlignment和VertivalAlignment属性，元素被放置在指定边界内部的某个位置。
 * 因为ArrangeOverrid()方法总是接收定义的尺寸（而非无限的尺寸），所以为了设置面板的最终尺寸，可以返回传递的Size对象。
 * 
 */

using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary
{
    public class CanvasClone : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            //对于Canvas面板子元素可在面板任意位置放置元素，并且具有任意的尺寸，所以子元素具有无限的空间
            Size size = new Size(Double.PositiveInfinity, Double.PositiveInfinity);
            foreach (UIElement element in InternalChildren)
            {
                element.Measure(size);
            }

            //这里返回空的Size对象，这意味着Canvas面板根本不请求任何空间，而是由使用者明确指定尺寸，或者将其放置到布局容器中进行拉伸以填充整个容器的可用空间
            return new Size();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement element in InternalChildren)
            {
                double x = 0;
                double y = 0;
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                double right = Canvas.GetRight(element);
                double bottom = Canvas.GetBottom(element);

                if (!double.IsNaN(left))
                {
                    x = left;
                }
                if (!double.IsNaN(top))
                {
                    y = top;
                }
                if (!double.IsNaN(right))
                {
                    x = finalSize.Width - right;
                }
                if (!double.IsNaN(bottom))
                {
                    y = finalSize.Height - bottom;
                }

                element.Arrange(new Rect(new Point(x, y), element.DesiredSize));
            }

            return finalSize;
        }
    }
}

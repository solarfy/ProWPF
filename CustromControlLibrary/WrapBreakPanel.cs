/* 带断行功能的WrapPanel面板
 * 使用附加属性LineBreakBeforeProperty，当该属性为True时，这个属性会导致在元素之前立即换行。
 */

using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary
{
    public class WrapBreakPanel : Panel
    {
        public static readonly DependencyProperty LineBreakBeforeProperty;

        static WrapBreakPanel()
        {
            //使用FrameworkPropertyMetadata.AffectsMeasure和FrameworkPropertyMetadata.AffectsArrange标志，无论何时设置该属性都会触发新的排列
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.AffectsMeasure = true;
            metadata.AffectsArrange = true;
            LineBreakBeforeProperty = DependencyProperty.RegisterAttached("LineBreakBefore", typeof(bool), typeof(WrapBreakPanel), metadata);
        }

        public static bool GetLineBreakBefore(UIElement element)
        {
            return (bool)element.GetValue(LineBreakBeforeProperty);
        }

        public static void SetLineBreakBefore(UIElement element, bool value)
        {
            element.SetValue(LineBreakBeforeProperty, value);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size currentLineSize = new Size();
            Size panelSize = new Size();

            foreach (UIElement element in InternalChildren)
            {
                element.Measure(availableSize);
                Size desiredSize = element.DesiredSize;

                //如果附加断行属性为True或者当前行的剩余空间无法满足子元素的需求，就发生断行
                if (GetLineBreakBefore(element) || currentLineSize.Width + desiredSize.Width > availableSize.Width)
                {
                    //发生断行后，增大面板的尺寸
                    panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
                    panelSize.Height += currentLineSize.Height;

                    //更新当前行尺寸（当前行的尺寸就为当前元素的尺寸，仅有一个元素）
                    currentLineSize = desiredSize;

                    //如果当前子元素尺寸大于可用大小的尺寸，就扩大其面板，并自动发生断行（该元素占满一行）。当前行尺寸为空，因为未放置新元素。
                    if (desiredSize.Width > availableSize.Width)
                    {
                        panelSize.Width = Math.Max(desiredSize.Width, panelSize.Width);
                        panelSize.Height += desiredSize.Height;
                        currentLineSize = new Size();
                    }
                }
                else
                {
                    //没有发生断行，就将该元素放置在上一个元素的末尾，并且行高设置为最高元素的行高
                    currentLineSize.Width += desiredSize.Width;
                    currentLineSize.Height = Math.Max(desiredSize.Height, currentLineSize.Height);
                }                
            }

            //返回所期望的尺寸以填充所有的元素
            panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
            panelSize.Height += currentLineSize.Height;
            return panelSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size currentLineSize = new Size();
            int firstInLine = 0;
            double accumulatedHeight = 0;

            UIElementCollection elements = InternalChildren;
            for (int i = 0; i < elements.Count; i++)
            {
                Size desiredSize = elements[i].DesiredSize;

                //断行
                if (GetLineBreakBefore(elements[i]) || currentLineSize.Width + desiredSize.Width > finalSize.Width)
                {
                    ArrangeLine(accumulatedHeight, currentLineSize.Height, firstInLine, i);

                    accumulatedHeight += currentLineSize.Height;
                    currentLineSize = desiredSize;

                    //如果子元素所需的空间大于面板的空间，就单独给它一行
                    if (desiredSize.Width > finalSize.Width)
                    {
                        ArrangeLine(accumulatedHeight, desiredSize.Height, i, ++i);
                        accumulatedHeight += desiredSize.Height;
                        currentLineSize = new Size();
                    }

                    firstInLine = i;
                }
                else
                {
                    currentLineSize.Width += desiredSize.Width;
                    currentLineSize.Height = Math.Max(desiredSize.Height, currentLineSize.Height);
                }
            }

            //排列剩余的子元素
            if (firstInLine < elements.Count)
            {
                ArrangeLine(accumulatedHeight, currentLineSize.Height, firstInLine, elements.Count) ;
            }
            
            return finalSize;
        }

        private void ArrangeLine(double y, double lineHeight, int start, int end)
        {
            double x = 0;
            UIElementCollection elements = InternalChildren;
            for (int i = start; i < end; i++)
            {
                UIElement child = elements[i];
                child.Arrange(new Rect(x, y, child.DesiredSize.Width, child.DesiredSize.Height));
                x += child.DesiredSize.Width;
            }

        }
    }
}

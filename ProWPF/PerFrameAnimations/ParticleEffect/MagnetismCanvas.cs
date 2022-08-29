using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProWPF.PerFrameAnimations.ParticleEffect
{
    class MagnetismCanvas : Canvas
    {
        private TimeTracker timeTracker;
        Dictionary<UIElement, Vector> childrenVelocities = new Dictionary<UIElement, Vector>() { };

        public double BorderForce { get; set; } = 1000.0;
        public double ChildForce { get; set; } = 200.0;
        private double Drag { get; set; } = 0.9;

        public MagnetismCanvas() : base()
        {
            CompositionTarget.Rendering += UpdateChildren;
            timeTracker = new TimeTracker();
        }

        private void UpdateChildren(object sender, EventArgs e)
        {
            //更新时间跟踪器
            timeTracker.Update();

            foreach (UIElement child in LogicalTreeHelper.GetChildren(this))
            {
                //获取之前存储的速度，如果没有就使用（0,0）
                Vector velocity = childrenVelocities.ContainsKey(child) ? childrenVelocities[child] : new Vector(0, 0);

                //计算速度阻尼
                velocity *= Drag;

                Point truePosition = GetTruePosition(child);
                Rect childRect = new Rect(truePosition, child.RenderSize);

                Vector forces = new Vector(0, 0);

                //添加排斥墙
                forces.X += BorderForce / Math.Max(1, childRect.Left);
                forces.X -= BorderForce / Math.Max(1, this.RenderSize.Width - childRect.Right);
                forces.Y += BorderForce / Math.Max(1, childRect.Top);
                forces.Y -= BorderForce / Math.Max(1, this.RenderSize.Height - childRect.Bottom);

                //每个子元素根据平方距离推开
                foreach (UIElement otherchild in LogicalTreeHelper.GetChildren(this))
                {
                    //排除自身
                    if (otherchild == child) continue;

                    Point otherchildtruePosition = GetTruePosition(otherchild);
                    Rect otherchildRect = new Rect(otherchildtruePosition, otherchild.RenderSize);

                    //确保矩形不相同
                    if (otherchildRect == childRect) continue;

                    //忽略大小为0的子项
                    if (otherchildRect.Width == 0 && otherchildRect.Height == 0 || childRect.Width == 0 && childRect.Height == 0) continue;

                    //其它子项到当前项的向量
                    Vector toChild;
                    double length;
                    
                    //如果重叠则距离为0
                    if (AreRectsOverlapping(childRect, otherchildRect))
                    {
                        toChild = new Vector(0, 0);
                    }
                    else
                    {
                        toChild = VectorBetweenRects(childRect, otherchildRect);
                    }

                    length = toChild.Length;
                    if (length < 1)
                    {
                        length = 1;
                        Point childCenter = GetCenter(childRect);
                        Point otherchildCenter = GetCenter(otherchildRect);
                        //从两个矩形中心计算到子元素
                        toChild = childCenter - otherchildCenter;
                    }

                    double childpush = ChildForce / length;

                    toChild.Normalize();
                    forces += toChild * childpush;
                }

                //将力添加到速度中，并将其存储以供下一次迭代
                velocity += forces;
                childrenVelocities[child] = velocity;

                //根据物体的速度移动物体
                SetTruePosition(child, truePosition + timeTracker.DeltaSeconds * velocity);
            }
        }

        private Point GetTruePosition(UIElement e)
        {          
            Point offset = GetRenderTransformOffset(e);
            Point location = new Point(Canvas.GetLeft(e) + offset.X, Canvas.GetTop(e) + offset.Y);
            //检查Nan并替换为（0，0）
            if (double.IsNaN(location.X) || double.IsNaN(location.Y))
            {
                location = new Point(0, 0);
            }

            return location;
        }

        private Point GetRenderTransformOffset(UIElement e)
        {
            //确保对象的渲染变换是平移
            TranslateTransform translate = new TranslateTransform(0, 0);

            if (e.RenderTransform is TranslateTransform t)
            {
                translate = t;
            }
            //else if (e.RenderTransform is TransformGroup group)
            //{
            //    IEnumerable<TranslateTransform> result = (IEnumerable<TranslateTransform>)group.Children.Select(x => x.GetType() == typeof(TranslateTransform));

            //    if (result != null)
            //    {
            //        translate = result.FirstOrDefault();
            //    }               
            //}

            return new Point(translate.X, translate.Y);
        }

        private void SetTruePosition(UIElement e, Point p)
        {
            Vector canvasOffset = new Vector(Canvas.GetLeft(e), Canvas.GetTop(e));
            Point renderTranslation = p - canvasOffset;

            SetRenderTransformOffset(e, renderTranslation);
        }

        private void SetRenderTransformOffset(UIElement e, Point offset)
        {
            //确保对象的渲染变换是平移
            TranslateTransform renderTranslation = e.RenderTransform as TranslateTransform;
            if (renderTranslation == null)
            {
                renderTranslation = new TranslateTransform(0, 0);
                e.RenderTransform = renderTranslation;
            }

            //设置新的偏移
            renderTranslation.X = offset.X;
            renderTranslation.Y = offset.Y;
        }

        private bool AreRectsOverlapping(Rect r1, Rect r2)
        {
            if (r1.Bottom < r2.Top) return false;
            if (r1.Top > r2.Bottom) return false;

            if (r1.Right < r2.Left) return false;
            if (r1.Left > r2.Right) return false;

            return true;
        }

        private Vector VectorBetweenRects(Rect r1, Rect r2)
        {
            //找到边缘点并使用这些点测量距离
            Point r1Center = GetCenter(r1);
            Point r2Center = GetCenter(r2);
            Vector between = (r1Center - r2Center);
            between.Normalize();
            Point edge1 = IntersectInsideRect(r1, r1Center, -between);
            Point edge2 = IntersectInsideRect(r2, r2Center, between);
            return edge1 - edge2;
        }

        private Point GetCenter(Rect r)
        {
            return new Point((r.Left + r.Right) / 2.0, (r.Top + r.Bottom) / 2.0);
        }

        private Point IntersectInsideRect(Rect r, Point raystart, Vector raydir)
        {
            double xtop = raystart.X + raydir.X * (r.Top - raystart.Y) / raydir.Y;
            double xbottom = raystart.X + raydir.X * (r.Bottom - raystart.Y) / raydir.Y;
            double yleft = raystart.Y + raydir.Y * (r.Left - raystart.X) / raydir.X;
            double yright = raystart.Y + raydir.Y * (r.Right - raystart.X) / raydir.X;
            Point top = new Point(xtop, r.Top);
            Point bottom = new Point(xbottom, r.Bottom);
            Point left = new Point(r.Left, yleft);
            Point right = new Point(r.Right, yright);
            Vector tv = raystart - top;
            Vector bv = raystart - bottom;
            Vector lv = raystart - left;
            Vector rv = raystart - right;
            
            //分类发散方向
            if (raydir.Y < 0)
            {
                if (raydir.X < 0) //top left
                {

                    if (tv.LengthSquared < lv.LengthSquared)
                        return top;
                    else
                        return left;
                }
                else //top right
                {
                    if (tv.LengthSquared < rv.LengthSquared)
                        return top;
                    else
                        return right;
                }
            }
            else
            {
                if (raydir.X < 0) //bottom left
                {
                    if (bv.LengthSquared < lv.LengthSquared)
                        return bottom;
                    else
                        return left;
                }
                else //bottom right
                {
                    if (bv.LengthSquared < rv.LengthSquared)
                        return bottom;
                    else
                        return right;
                }
            }
        }

        
    }
}

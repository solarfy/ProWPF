using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControlLibrary
{
    public class DrawingCanvas : Canvas
    {
        //可视化对象集合
        private List<Visual> visuals = new List<Visual>() { };
        //存储范围的命中测试的可视化对象集合
        private List<DrawingVisual> hits = new List<DrawingVisual>() { };

        //*重写VisualChildernCount属性
        protected override int VisualChildrenCount => visuals.Count;

        //*重写GetVisualChild方法
        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }
        
        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            //*使用AddVisualChild()和AddLogicalChild()方法注册可视化对象
            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void RemoveVisual(Visual visual)
        {
            if (visuals.Contains(visual))
            {
                visuals.Remove(visual);
                base.RemoveVisualChild(visual);
                base.RemoveLogicalChild(visual);
            }
        }

        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;        //忽略所有的非DrawingVisual类型的命中对象，包括DrawingCanvas本身。
        }

        public List<DrawingVisual> GetVisuals(Geometry region)
        {
            hits.Clear();

            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(HitTestCallback);

            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return hits;
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            DrawingVisual visual = result.VisualHit as DrawingVisual;

            //DrawingVisual类型的可视化对象且处于Geometry命中测试参数内  //Intersets几何图形与可视化对象只是相交 FullyContains几何图形落于可是元素内部
            if (visual != null && geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)  
            {
                hits.Add(visual);
            }

            return HitTestResultBehavior.Continue;      //Continue继续，Stop终止
        }

        #region ShowGridLines
        //是否显示背景格子线
        public bool ShowGridLines { get; set; }

        //在元素呈现时连同背景格子一同呈现（如果有的话）
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            if (ShowGridLines)
            {
                //背景格子线
                Visual gridLines = DrawingGridLines();
                AddVisual(gridLines);
            }
        }

        private Visual DrawingGridLines()
        {
            DrawingVisual dv = new DrawingVisual();

            using (DrawingContext dc = dv.RenderOpen())
            {
                Pen pen = new Pen(Brushes.Gray, 2);

                double h = 0.0, v = 0.0;
                //横线
                while (v < base.ActualHeight)
                {
                    dc.DrawLine(pen, new Point(0, v), new Point(base.ActualWidth, v));
                    v += 20;
                }
                //竖线
                while (h < base.ActualWidth)
                {
                    dc.DrawLine(pen, new Point(h, 0), new Point(h, base.ActualHeight));
                    h += 20;
                }
            }

            return dv;
        }
        #endregion

    }
}

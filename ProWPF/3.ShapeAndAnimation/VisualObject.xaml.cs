using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.Generic;

namespace ProWPF.ShapeAndAnimation
{
    /// <summary>
    /// VisualObjcet.xaml 的交互逻辑
    /// </summary>
    public partial class VisualObject : Window
    {
        private Brush drawingBrush = Brushes.AliceBlue;
        private Brush selectedDrawingBrush = Brushes.LightGoldenrodYellow;
        private Pen drawingPen = new Pen(Brushes.SteelBlue, 3);
        private Size squareSize = new Size(50, 50);
        private Brush selectionSquareBrush = Brushes.Transparent;
        private Pen selectionSquarePen = new Pen(Brushes.Black, 2);

        //拖动状态
        private bool isDragging = false;
        //记录选中的可视化对象
        private DrawingVisual selectedVisual;
        //记录用户单击点和正方形左上角之间的距离
        private Vector clickOffset;

        //选择框可视化对象
        private DrawingVisual selectionSquare;
        //跟踪正在选择的操作
        private bool isMultiSelecting = false;
        //跟踪多选选择框的左上角
        private Point selectionSquareTopLeft;
       
        public VisualObject()
        {
            InitializeComponent();
        }
       
        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pointClicked = e.GetPosition(this.drawingCanvas);

            if (this.rbAdd.IsChecked == true)
            {
                DrawingVisual visual = new DrawingVisual();
                DrawSquare(visual, pointClicked, false);
                this.drawingCanvas.AddVisual(visual);
            }
            else if (this.rbDelete.IsChecked == true)
            {
                DrawingVisual visual = this.drawingCanvas.GetVisual(pointClicked);
                if (visual != null) this.drawingCanvas.RemoveVisual(visual);
            }
            else if (this.rbSelectMove.IsChecked == true)
            {
                DrawingVisual visual = this.drawingCanvas.GetVisual(pointClicked);
                if (visual != null)
                {
                    Point topLeftCorner = new Point(visual.ContentBounds.TopLeft.X + drawingPen.Thickness / 2, visual.ContentBounds.TopLeft.Y + drawingPen.Thickness / 2);
                    DrawSquare(visual, topLeftCorner, true);    //绘制选中状态下的方块样式

                    clickOffset = topLeftCorner - pointClicked; //鼠标点M到方块左上角O的向量 OM=(M.x-O.x，M.y-O.y)
                    isDragging = true;

                    //如果选中项发生改变，则清除选中状态，将方块恢复至之前的样式，如果重复点击自身就不改变
                    if (selectedVisual != null && selectedVisual != visual)
                    {
                        ClearSelection();
                    }

                    selectedVisual = visual;
                }
            }
            else if (this.rbSelectMultiple.IsChecked == true)
            {
                selectionSquare = new DrawingVisual();
                this.drawingCanvas.AddVisual(selectionSquare);

                selectionSquareTopLeft = pointClicked;
                isMultiSelecting = true;

                this.drawingCanvas.CaptureMouse();  //捕获鼠标，防止鼠标移除Canvas无法监听到MouseLeftButtonUp事件，否则可能同时绘制两个选择框。
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point pointDragged = e.GetPosition(this.drawingCanvas) + clickOffset;   //加上向量为实际的方块左上角位置
                DrawSquare(selectedVisual, pointDragged, true);
            }
            else if (isMultiSelecting)
            {
                Point pointDragged = e.GetPosition(this.drawingCanvas);
                DrawSelectionSquare(selectionSquareTopLeft, pointDragged);
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
            }
            else if (isMultiSelecting)
            {
                RectangleGeometry geometry = new RectangleGeometry(new Rect(selectionSquareTopLeft, e.GetPosition(this.drawingCanvas)));
                List<DrawingVisual> visualsInRegion = this.drawingCanvas.GetVisuals(geometry);

                MessageBox.Show($"框选了{visualsInRegion.Count}个方框！");

                isMultiSelecting = false;                
                this.drawingCanvas.RemoveVisual(selectionSquare);    //移除选中框
                this.drawingCanvas.ReleaseMouseCapture();   //释放鼠标
            }
        }
     
        private void DrawSquare(DrawingVisual visual, Point topLeftCorner, bool isSelected)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                Brush brush = drawingBrush;
                if (isSelected) brush = selectedDrawingBrush;
                dc.DrawRectangle(brush, drawingPen, new Rect(topLeftCorner, squareSize));
            }
        }

        private void ClearSelection()
        {
            Point topLeftCorner = new Point(selectedVisual.ContentBounds.TopLeft.X + drawingPen.Thickness / 2, selectedVisual.ContentBounds.TopLeft.Y + drawingPen.Thickness / 2);
            DrawSquare(selectedVisual, topLeftCorner, false);
            selectedVisual = null;
        }

        //绘制选择框
        private void DrawSelectionSquare(Point point1, Point point2)
        {
            selectionSquarePen.DashStyle = DashStyles.Dash;

            using (DrawingContext dc = selectionSquare.RenderOpen())
            {
                dc.DrawRectangle(selectionSquareBrush, selectionSquarePen, new Rect(point1, point2));
            }
        }

        //Rectangle用于绘制自身的渲染代码
        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    Pen pen = base.GetPen();
        //    drawingContext.DrawRoundedRectangle(base.Fill, pen, this._rect, this.RadiuX, this.RadiuY);
        //}
        //
    }
}

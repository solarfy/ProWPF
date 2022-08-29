using System;
using System.ComponentModel;
using System.Reflection;

namespace ProWPF
{
    static class Chapters
    {
        #region Basic        

        [Description("Grid面板中共享尺寸组")]
        public const string SharedSizeGroup = "1.Basic/SharedSizeGroup.xaml";

        [Description("WrapPanel面板布局")]
        public const string ModularContent = "1.Basic/ModularContent.xaml";

        [Description("事件路由策略（冒泡、隧道）")]
        public const string RoutingStrategy = "1.Basic/RoutingStrategy.xaml";

        [Description("自定义依赖属性、路由事件")]
        public const string CustomControl = "1.Basic/CustomControl.xaml";

        [Description("处理按键事件")]
        public const string KeyboardEvent = "1.Basic/KeyboardEvent.xaml";

        [Description("鼠标事件")]
        public const string MouseEvent = "1.Basic/MouseEvent.xaml";

        #endregion

        #region Advanced

        [Description("文本")]
        public const string TextText = "2.Advanced/TextText.xaml";

        [Description("光标")]
        public const string MouseCursor = "2.Advanced/MouseCursor.xaml";

        [Description("记忆符（访问键）；能够为链接的控件设置焦点的快捷键")]
        public const string LabelTarget = "2.Advanced/LabelTarget.xaml";

        [Description("工具提示")]
        public const string ToolTips = "2.Advanced/ToolTips.xaml";

        [Description("弹窗")]
        public const string Popups = "2.Advanced/Popups.xaml";

        [Description("滚动视图")]
        public const string ScrollViewers = "2.Advanced/ScrollViewers.xaml";

        [Description("扩展区域")]
        public const string Expanders = "2.Advanced/Expanders.xaml";

        [Description("文本控件")]
        public const string TextBoxes = "2.Advanced/TextBoxes.xaml";

        [Description("列表控件")]
        public const string ListColors = "2.Advanced/ListColors.xaml";

        [Description("基于范围的控件")]
        public const string RangeControl = "2.Advanced/RangeControl.xaml";

        [Description("日期控件")]
        public const string DateControl = "2.Advanced/DateControl.xaml";

        [Description("窗口间的交互")]
        public const string WindowTracker = "2.Advanced/WindowTracker.xaml";

        [Description("自定义Application类")]
        public const string CustomApplication = "2.Advanced/CustomApplication.xaml";

        [Description("单实例应用程序")]
        public const string SingleApplication = "2.Advanced/SingleApplication.xaml";

        [Description("注册文件类型")]
        public const string FileRegistration = "2.Advanced/FileRegistration.xaml";

        [Description("程序集资源")]
        public const string AssemblyResource = "2.Advanced/AssemblyResource.xaml";

        [Description("WPF全球化")]
        public const string WPFGlobalization = "2.Advanced/WPFGlobalization.xaml";

        [Description("关于绑定")]
        public const string AboutBinding = "2.Advanced/AboutBinding.xaml";

        [Description("关于命令")]
        public const string AboutCommand = "2.Advanced/AboutCommand.xaml";

        [Description("跟踪和翻转命令")]
        public const string CommandHistory = "2.Advanced/CommandHistory.xaml";

        [Description("自定义带命令的TextBox")]
        public const string CommandTextBox = "2.Advanced/CommandTextBox.xaml";

        [Description("对象资源")]
        public const string ObjectResource = "2.Advanced/ObjectResource.xaml";

        [Description("样式和行为")]
        public const string StyleAndBehavior = "2.Advanced/StyleAndBehavior.xaml";
        #endregion

        #region ShapeAndAnimation
        [Description("使用Viewbox控件缩放形状")]
        public const string ViewboxResize = "3.ShapeAndAnimation/ViewboxResize.xaml";

        [Description("多边形和折线")]
        public const string PolygonAndPolyline = "3.ShapeAndAnimation/PolygonAndPolyline.xaml";

        [Description("关于画刷")]
        public const string AboutBrush = "3.ShapeAndAnimation/AboutBrush.xaml";

        [Description("关于变换")]
        public const string AboutTransform = "3.ShapeAndAnimation/AboutTransform.xaml";

        [Description("透明与透明掩码")]
        public const string AboutTransparent = "3.ShapeAndAnimation/AboutTransparent.xaml";

        [Description("路径和几何图形")]
        public const string PathAndGeometry = "3.ShapeAndAnimation/PathAndGeometry.xaml";

        [Description("图画--无交互的轻量级图形")]
        public const string AboutDrawing = "3.ShapeAndAnimation/AboutDrawing.xaml";

        [Description("可视化对象")]
        public const string VisualObject = "3.ShapeAndAnimation/VisualObject.xaml";

        [Description("效果（模糊、阴影、像素着色器）")]
        public const string MediaEffects = "3.ShapeAndAnimation/MediaEffects.xaml";

        [Description("生成位图")]
        public const string DrawBitmap = "3.ShapeAndAnimation/DrawBitmap.xaml";

        [Description("动画类")]
        public const string AnimationTypes = "3.ShapeAndAnimation/AnimationTypes.xaml";

        [Description("基础动画")]
        public const string BasicAnimation = "3.ShapeAndAnimation/BasicAnimation.xaml";

        [Description("动画缓动")]
        public const string AnimationEasing = "3.ShapeAndAnimation/AnimationEasing.xaml";

        [Description("高级动画")]
        public const string AdvancedAnimation = "3.ShapeAndAnimation/AdvancedAnimation.xaml";

        [Description("帧动画视图")]
        public const string PerFrameAnimationsView = "3.ShapeAndAnimation/PerFrameAnimationsView.xaml";

        [Description("拦截炸弹")]
        public const string BombDropper = "3.ShapeAndAnimation/BombDropper.xaml";
        #endregion

        #region TemplateAndCustom

        [Description("逻辑树与可视化树")]
        private const string LogicalAndVisual = "4.TemplateAndCustom/LogicalAndVisual.xaml";

        [Description("控件模板浏览器")]
        private const string ControlTemplateBrowser = "4.TemplateAndCustom/ControlTemplateBrowser.xaml";

        [Description("自定义按钮模板")]
        private const string CustomButtonTemplate = "4.TemplateAndCustom/CustomButtonTemplate.xaml";

        [Description("切换样式")]
        private const string SwitchStyle = "4.TemplateAndCustom/SwitchStyle.xaml";

        [Description("自定义LisBox样式")]
        private const string CustomListBox = "4.TemplateAndCustom/CustomListBox.xaml";

        [Description("自定义控件展示")]
        private const string CustomControlExample = "4.TemplateAndCustom/CustomControlExample.xaml";
        #endregion

        #region Data

        [Description("绑定到Product对象")]
        private const string BindingProductObject = "5.Data/BindingProductObject.xaml";

        [Description("绑定到对象集合")]
        private const string BindingToCollection = "5.Data/BindingToCollection.xaml";

        [Description("绑定到ADO.NET对象")]
        private const string BindingToTable = "5.Data/BindingToTable.xaml";

        [Description("提高大列表性能")]
        private const string ImproveLargeListPerformance = "5.Data/ImproveLargeListPerformance.xaml";

        [Description("数据验证")]
        private const string DataValidation = "5.Data/DataValidation.xaml";

        [Description("数据提供者")]
        private const string DataProvider = "5.Data/DataProvider.xaml";

        [Description("数据转换")]
        private const string DataConversion = "5.Data/DataConversion.xaml";

        [Description("列表控件")]
        private const string ListControl = "5.Data/ListControl.xaml";

        [Description("数据模板")]
        private const string DataTemplates = "5.Data/DataTemplates.xaml";

        [Description("数据视图")]
        private const string DataView = "5.Data/DataView.xaml";

        [Description("关于ListView")]
        private const string AboutListView = "5.Data/AboutListView.xaml";

        [Description("关于TreeView")]
        private const string AboutTreeView = "5.Data/AboutTreeView.xaml";

        [Description("关于AboutDataGrid")]
        private const string AboutDataGrid = "5.Data/AboutDataGrid.xaml";

        #endregion

        /// <summary>
        /// 获取指定章节的描述
        /// </summary>
        /// <param name="chapter">章节名称（nameof(...)）</param>
        /// <returns></returns>
        public static string GetChapterDescription(string chapter)
        {
            Type type = typeof(Chapters);

            FieldInfo filed = type.GetField(chapter);   //获得指定的公共字段

            if (filed != null)
            {
                DescriptionAttribute description = filed.GetCustomAttribute<DescriptionAttribute>();
                return description.Description;
            }

            return chapter;     //若没找到则返回该字符串
        }

        public static string Startup = AboutDataGrid;
    }
}

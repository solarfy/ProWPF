using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CustomControlLibrary
{
    public class ColorListBox : ListBox
    {
        public ColorListBox()
        {            
            this.Initialized += ColorListBox_Initialized;       //放置在Initalized中，如果放置在Load中，会执行两次TabControl一次，TabItem切换时一次
        }

        private void ColorListBox_Initialized(object sender, EventArgs e)
        {
            PropertyInfo[] props;
            
            if (string.IsNullOrEmpty(ColorItmesString))
            {
                props = typeof(Colors).GetProperties(); //如果没有设置颜色集合，则使用Colors类中所有的颜色
            }
            else
            {
                string[] colorNames = ColorItmesString.Split(',');
                props = new PropertyInfo[colorNames.Length];

                for (int i = 0; i < colorNames.Length; i++)
                {
                    props[i] = typeof(Colors).GetProperty(colorNames[i]);
                }
            }

            foreach (PropertyInfo prop in props)
            {
                ColorListBoxItem item = new ColorListBoxItem();
                item.Text = prop.Name;
                item.Color = (Color)prop.GetValue(null, null);
                item.IsDisplayText = IsDisplayColorName;
                this.Items.Add(item);
            }

            this.SelectedValuePath = nameof(Color);

            if (Orientation == Orientation.Horizontal) PlacementHorizontal();
        }

        //注：如果使用绑定请使用ListBox.SelectedValue属性
        public Color SelectedColor
        {
            set => this.SelectedValue = value;
            get => (null != this.SelectedValue) ? (Color)this.SelectedValue : Colors.Transparent;
        }
        
        public bool IsDisplayColorName { get; set; }

        public Orientation Orientation { get; set; }

        //要显示的颜色集合用“,”分隔 如：Red,Blue,Yellow,Green
        public string ColorItmesString { get; set; }

        //水平放置颜色方块
        private void PlacementHorizontal()
        {
            ItemsPanelTemplate itemsPanel = new ItemsPanelTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(WrapPanel));
            factory.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
            factory.SetValue(WrapPanel.MarginProperty, new Thickness(4));
            itemsPanel.VisualTree = factory;

            this.ItemsPanel = itemsPanel;
        }
    }

    public class ColorListBoxItem : ListBoxItem
    {
        private string str;
        private Rectangle rect;
        private TextBlock text;

        public ColorListBoxItem()
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            this.Content = stack;

            //建立矩形，以显示颜色
            rect = new Rectangle();
            rect.Width = 16;
            rect.Height = 16;
            rect.Margin = new Thickness(2);
            rect.Stroke = SystemColors.WindowTextBrush;
            stack.Children.Add(rect);

            //建立TextBlock，以显示颜色名称
            text = new TextBlock();
            text.VerticalAlignment = VerticalAlignment.Center;
            text.Visibility = IsDisplayText ? Visibility.Visible : Visibility.Collapsed;
            stack.Children.Add(text);
        }

        public string Text
        {
            set
            {
                str = value;
                string strSpace = str[0].ToString();

                for (int i = 1; i < str.Length; i++)
                {
                    strSpace += (char.IsUpper(str[i]) ? " " : "") + str[i].ToString();
                }

                text.Text = strSpace;
            }

            get => str;
        }

        public Color Color
        {
            set { rect.Fill = new SolidColorBrush(value); }
            get
            {
                SolidColorBrush brush = rect.Fill as SolidColorBrush;
                return brush == null ? Colors.Transparent : brush.Color;
            }
        }

        public bool IsDisplayText { get; set; }

        //当项目被选中
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            text.FontWeight = FontWeights.Bold;
        }
        //当项目被反选
        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            text.FontWeight = FontWeights.Regular;
        }

        public override string ToString()
        {
            return str;
        }

    }
}
